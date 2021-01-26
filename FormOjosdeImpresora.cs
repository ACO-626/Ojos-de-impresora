
#region Bibliotecas
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Management;
#endregion

namespace Ojos_de_impresora
{
    public partial class FormOjosImpresora : Form
    {
        #region Globales
        //Camara
        VideoCapture video;
        private int indexCamara = 100;
        bool pausa = false;
        public int IndexCamara { get => indexCamara; set => indexCamara = value; }
        Mat mframe;


        //ModoConexión Arduino
        private byte puerto;
        public byte Puerto { get => puerto; set => puerto = value; }


        //Seleccionar Extrusor
        Rectangle rect;
        Point StartROI;
        bool cortando=false;
        bool MouseDown;
        Image<Bgr, byte> extrusor;
        Image<Bgr, byte> extrusorAux;
        bool hotend;

        //MatchHotend
        bool matching = false;

        #endregion

        #region Inicialización
        public FormOjosImpresora()
        {
            InitializeComponent();
            rect = Rectangle.Empty;
            video = new VideoCapture(0);
        }

        public static List<string> GetAllConnectedCameras()
        {
            var cameraNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    cameraNames.Add(device["Caption"].ToString());
                }
            }

            return cameraNames;
        }

        #endregion

        #region MétodoMostrarCanara
        public async void MostrarCamara()
        {
            video = new VideoCapture(IndexCamara);
            pausa = false;
            while (!pausa)
            {
                mframe = new Mat();
                video.Read(mframe);
                video.Grab();
                if (!mframe.IsEmpty)
                {
                    if(hotend && matching)
                    {
                        MatchHotend();
                        await Task.Delay(1000 / 60);
                    }
                    else
                    {
                        pictureVideo.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                        pictureBox3.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                        pictureBox4.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                        await Task.Delay(1000 / 60);
                    }
                    
                } else
                {
                    break;
                }

            }
        }
        #endregion

        #region Cámara
        private void btnCam_Click(object sender, EventArgs e)
        {
            video.Stop();
            video.Dispose();
            pausa = true;
            Form ventanaSelectCamara = new FormSelectCamera();
            AddOwnedForm(ventanaSelectCamara);
            ventanaSelectCamara.Show();

        }
        #endregion

        #region ModoArduino
        private void btnArd_Click(object sender, EventArgs e)
        {
            Form ventanaModoArduino = new FormModeArduino();
            AddOwnedForm(ventanaModoArduino);
            ventanaModoArduino.Show();
        }
        #endregion

        #region Seleccionar Extrusor
        private void btnExt_Click(object sender, EventArgs e)
        {
            if (pictureVideo.Image != null)
            {

                
                MessageBox.Show("Siga las instrucciones para indicar el cabezal de extrusión", "Indicar el cabezal", MessageBoxButtons.OK);
                lbMensaje.Text = "Encierra el HotEnd de tu impresora haciendo click y arrastrando sobre la imagen:";
                lbMensaje.Visible = true;
                
                pictureVideo.Image = new Image<Bgr, byte>(new Bitmap(pictureVideo.Image)).Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear).ToBitmap();                
                video.Dispose();
                pausa = true;
                
                cortando = true;

            }
            else
            {
                MessageBox.Show("Debe tener una cámara activa o video", "Sin imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
        private void pictureVideo_MouseDown(object sender, MouseEventArgs e)
        {
            if (cortando)
            {
                MouseDown = true;
                StartROI = e.Location;
            }
        }

        private void pictureVideo_MouseMove(object sender, MouseEventArgs e)
        {
            if (cortando)
            {
                int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
                int Height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
                rect = new Rectangle(Math.Min(StartROI.X, e.X), Math.Min(StartROI.Y, e.Y), width, Height);
                Refresh();
            }
        }

        private void pictureVideo_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown)
            {
                using (Pen pen = new Pen(Color.Red))
                {
                    pen.Width = 3;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }
        }

        private void pictureVideo_MouseUp(object sender, MouseEventArgs e)
        {
            if (cortando)
            {
                cortando = false;
                MouseDown = false;
                ObtenerExtrusor();

            }


        }

        private void ObtenerExtrusor()
        {
            if (rect != Rectangle.Empty)
            {
                var img = new Image<Bgr, byte>(new Bitmap(pictureVideo.Image));
                img.Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear);
                img.ROI = rect;
                var imgROI = img.Copy();
                img.ROI = Rectangle.Empty;
                
                MostrarCamara();
                extrusor = new Image<Bgr, byte>(imgROI.ToBitmap());
                extrusorAux = extrusor;
                lbMensaje.Visible = false;
                hotend = true;
                pictureExtrusor.Image = extrusor.ToBitmap();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un área válida para el extrusor, volver a intentar", "Extrusor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        #endregion

        private void btnVer_Click(object sender, EventArgs e)
        {
            if(hotend ==true)
            {
                matching = true;
            }else
            {
                MessageBox.Show("Aun faltan configuraciones para porder ayudarte","Falta información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        private void MatchHotend()
        {
            var imgScene = mframe.ToImage<Bgr,byte>();
            imgScene.Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear);
            var template = extrusor;
            Mat imgOut = new Mat();
            CvInvoke.MatchTemplate(imgScene, template, imgOut, Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);
            double minVal = 0.0;
            double maxVal = 0.0;
            Point minLoc = new Point();
            Point maxLoc = new Point();
            CvInvoke.MinMaxLoc(imgOut, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            Rectangle r = new Rectangle(minLoc, template.Size);
            CvInvoke.Rectangle(imgScene, r, new MCvScalar(255, 0, 0), 3);
            pictureVideo.Image = imgScene.ToBitmap();
            pictureExtrusor.Image = extrusorAux.ToBitmap();
            imgScene.ROI = r;            
            extrusorAux = imgScene.Copy();
            imgScene.ROI = Rectangle.Empty;
        }


       

    }
}
