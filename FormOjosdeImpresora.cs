
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
       


        //ModoConexión Arduino
        private byte puerto;
        public byte Puerto { get => puerto; set => puerto = value; }


        //Seleccionar Extrusor
        Rectangle rect;
        Point StartROI;
        bool Escogiendo;
        bool MouseDown;

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
            while(!pausa)
            {
                Mat mframe = new Mat();
                video.Read(mframe);
                video.Grab();
                if(!mframe.IsEmpty)
                {
                    pictureVideo.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                    pictureBox2.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                    pictureBox3.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                    pictureBox4.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                    await Task.Delay(1000 / 60);
                }else
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
            
            video.Dispose();
            pausa = true;

            
        }
#endregion
    }
}
