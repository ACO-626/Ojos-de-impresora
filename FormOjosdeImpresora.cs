
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
using Emgu.CV.Util;
using Emgu.CV.Features2D;
using Emgu.CV.Flann;
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
        Rectangle rect2;
        Point StartROI;
        bool cortando=false;
        bool MouseDown=false;
        Image<Bgr, byte> extrusor;
        Image<Bgr, byte> extrusorAux;
        bool hotend;
        

        //MatchHotend
        bool matching = false;
        Image<Bgr, byte> imgScene;
        Rectangle r;

        //DetectarCama
        Image<Gray, byte> imgCama;
        Image<Gray, byte> imgCamaAux;

        //DetectarCama2
        bool cameando = false;
        bool cortandoCama = false;
        Image<Bgr, byte> realCama;
        Image<Bgr, byte> realCamaAux;
        bool cama;
        Rectangle rCama;

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
                        //FBMatcher();
                        //FLANNMatcher();
                        //FBMatcher();
                        //FLANNMatcher();
                        //detectarCama();
                        matchCama();
                        pictureVideo.Image = imgScene.ToBitmap();
                        await Task.Delay(1000 / 70);
                    }
                    else
                    {
                        pictureVideo.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                        //pictureCama.Image = mframe.ToImage<Bgr, byte>().ToBitmap();
                        
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
            if(cortandoCama)
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
            if(cortandoCama)
            {
                int width = Math.Max(StartROI.X, e.X) - Math.Min(StartROI.X, e.X);
                int Height = Math.Max(StartROI.Y, e.Y) - Math.Min(StartROI.Y, e.Y);
                rect2 = new Rectangle(Math.Min(StartROI.X, e.X), Math.Min(StartROI.Y, e.Y), width, Height);
                Refresh();
            }
        }

        private void pictureVideo_Paint(object sender, PaintEventArgs e)
        {
            if (MouseDown && cortando)
            {
                using (Pen pen = new Pen(Color.Red))
                {
                    pen.Width = 3;
                    e.Graphics.DrawRectangle(pen, rect);
                }
            }else if(MouseDown && cortandoCama)
            {
                using (Pen pen = new Pen(Color.Red))
                {
                    pen.Width = 3;
                    e.Graphics.DrawRectangle(pen, rect2);
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
            if(cortandoCama)
            {
                cortandoCama = false;
                MouseDown = false;
                ObtenerCama();
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

        #region Simple matchCabezal
        //Detección de Cabezal por simple match
        private void MatchHotend()
        {
            imgScene = mframe.ToImage<Bgr, byte>();
            imgScene.Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear);
            var template = extrusor;
            Mat imgOut = new Mat();
            CvInvoke.MatchTemplate(imgScene, template, imgOut, Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);
            double minVal = 0.0;
            double maxVal = 0.0;
            Point minLoc = new Point();
            Point maxLoc = new Point();
            CvInvoke.MinMaxLoc(imgOut, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            r = new Rectangle(minLoc, template.Size);            
            
            pictureExtrusor.Image = extrusorAux.ToBitmap();
            imgScene.ROI = r;
            extrusorAux = imgScene.Copy();
            imgScene.ROI = Rectangle.Empty;
            CvInvoke.Rectangle(imgScene, r, new Bgra(255, 168, 0, 0).MCvScalar, 2);
            CvInvoke.PutText(imgScene, "Carro", new Point((r.Left+r.Right)/2, (r.Top+r.Bottom)/2), Emgu.CV.CvEnum.FontFace.HersheyPlain,0.95, new MCvScalar(255, 168, 0));

      
            //pictureVideo.Image = imgScene.ToBitmap();
            
        }
        #endregion

        #region Ver
        private void btnVer_Click(object sender, EventArgs e)
        {
            if(hotend ==true && cama==true)
            {

                matching = true;
            }                           
            else
            {
                MessageBox.Show("Aun faltan configuraciones para porder ayudarte","Falta información",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }


        #endregion

        #region FBMatcher
        private void FBMatcher()
        {
            try
            {
                var imgScene = mframe.ToImage<Bgr, byte>();
                var template = extrusor;
                var vp = PrcessImageFB(template,imgScene.Convert<Gray,byte>());
                if(vp != null)
                {
                    CvInvoke.Polylines(imgScene, vp,true, new MCvScalar(255), 5);
                }

                pictureVideo.Image = imgScene.ToBitmap();

            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
 
        }
       private static VectorOfPoint PrcessImageFB(Image<Bgr,byte> template, Image<Gray,byte> sceneImage)
        {
            try
            {
                VectorOfPoint finalPonts = null;
                Mat homography = null;
                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPounts = new VectorOfKeyPoint();
                Mat templateDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();
                Mat mask = new Mat();
                int k = 2;
                double uniquenesthreshold = 0.80;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                Brisk featureDetector = new Brisk();
                featureDetector.DetectAndCompute(template, null, templateKeyPoints, templateDescriptor, false);
                featureDetector.DetectAndCompute(sceneImage, null, sceneKeyPounts, sceneDescriptor, false);

                BFMatcher matcher = new BFMatcher(DistanceType.Hamming);
                matcher.Add(templateDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k, mask);
                mask = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenesthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPounts, matches, mask, 1.5, 20);
                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints, sceneKeyPounts, matches, mask, 5);
                }
                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                    new PointF(rect.Left,rect.Bottom),
                    new PointF(rect.Right,rect.Bottom),
                    new PointF(rect.Right,rect.Top),
                    new PointF(rect.Left,rect.Top)
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPonts = new VectorOfPoint(points);
                }
                
                return finalPonts;
            }
            catch(Exception ex)
            {
                VectorOfPoint finalPonts = null;
                return finalPonts;
                throw new Exception(ex.Message);
            }


        }
        #endregion

        #region FlanMqatcher
        private void FLANNMatcher()
        {
            
            
                var imgScene = mframe.ToImage<Bgr, byte>();
                var template = extrusor;
                var vp = PrcessImageFLann(template, imgScene.Convert<Gray, byte>());
                if (vp != null)
                {
                    CvInvoke.Polylines(imgScene, vp, true, new MCvScalar(255), 5);
                }

                pictureVideo.Image = imgScene.ToBitmap();


        }

        private static VectorOfPoint PrcessImageFLann(Image<Bgr, byte> template, Image<Gray, byte> sceneImage)
        {
            try
            {
                VectorOfPoint finalPonts = null;
                Mat homography = null;
                VectorOfKeyPoint templateKeyPoints = new VectorOfKeyPoint();
                VectorOfKeyPoint sceneKeyPounts = new VectorOfKeyPoint();
                Mat templateDescriptor = new Mat();
                Mat sceneDescriptor = new Mat();
                Mat mask = new Mat();
                int k = 2;
                double uniquenesthreshold = 0.80;
                VectorOfVectorOfDMatch matches = new VectorOfVectorOfDMatch();

                KAZE featureDetector = new KAZE();
                featureDetector.DetectAndCompute(template, null, templateKeyPoints, templateDescriptor, false);
                featureDetector.DetectAndCompute(sceneImage, null, sceneKeyPounts, sceneDescriptor, false);

                //Matching

                KdTreeIndexParams ip = new KdTreeIndexParams();
                //var ip = new AutotunedIndexParams();
                //var ip = new LinearIndexParams();
                SearchParams sp = new SearchParams();
                FlannBasedMatcher matcher = new FlannBasedMatcher(ip,sp);

                matcher.Add(templateDescriptor);
                matcher.KnnMatch(sceneDescriptor, matches, k, mask);
                mask = new Mat(matches.Size, 1, Emgu.CV.CvEnum.DepthType.Cv8U, 1);
                mask.SetTo(new MCvScalar(255));

                Features2DToolbox.VoteForUniqueness(matches, uniquenesthreshold, mask);

                int count = Features2DToolbox.VoteForSizeAndOrientation(templateKeyPoints, sceneKeyPounts, matches, mask, 1.5, 20);
                if (count >= 4)
                {
                    homography = Features2DToolbox.GetHomographyMatrixFromMatchedFeatures(templateKeyPoints, sceneKeyPounts, matches, mask, 5);
                }
                if (homography != null)
                {
                    Rectangle rect = new Rectangle(Point.Empty, template.Size);
                    PointF[] pts = new PointF[]
                    {
                    new PointF(rect.Left,rect.Bottom),
                    new PointF(rect.Right,rect.Bottom),
                    new PointF(rect.Right,rect.Top),
                    new PointF(rect.Left,rect.Top)
                    };
                    pts = CvInvoke.PerspectiveTransform(pts, homography);
                    Point[] points = Array.ConvertAll<PointF, Point>(pts, Point.Round);
                    finalPonts = new VectorOfPoint(points);
                }
                return finalPonts;
            }
            catch (Exception ex)
            {
                VectorOfPoint finalPonts = null;
                return finalPonts;
                throw new Exception(ex.Message);
            }


        }

        #endregion

        #region DetectarCama
        private void detectarCama()
        {
            imgCama = imgScene.Convert<Gray, byte>();
            imgCamaAux = new Image<Gray, byte>(imgCama.Width, imgCama.Height);
            for (int i = 2*imgCama.Height/3; i < imgCama.Height; i++)
            {
                for (int j = 0; j < imgCama.Width; j++)
                {
                   
                    
                        imgCamaAux[i, j] = imgCama[i, j];
                    
                        
                }
            }
            imgCama = imgCamaAux.Canny(40, 200);

            pictureBox4.Image = imgCama.ToBitmap();
            Emgu.CV.Util.VectorOfVectorOfPoint contours = new Emgu.CV.Util.VectorOfVectorOfPoint();
            Mat mat = new Mat();
            CvInvoke.FindContours(imgCama, contours, mat, Emgu.CV.CvEnum.RetrType.External, Emgu.CV.CvEnum.ChainApproxMethod.ChainApproxSimple);

            for (int i = 0; i < contours.Size; i++)
            {
                Rectangle cajaBlob = CvInvoke.BoundingRectangle(contours[i]);
                var area = CvInvoke.ContourArea(contours[i]);
                if (area > 1500 && !r.Contains(cajaBlob) && cajaBlob.Bottom>r.Bottom)
                {
                    CvInvoke.DrawContours(imgScene, contours, i, new MCvScalar(255, 200, 0), 3);
                }

            }
            
            pictureVideo.Image = imgScene.ToBitmap();



        }
        #endregion

        #region detectar cama
        private void btnCama_Click(object sender, EventArgs e)
        {
            if (pictureVideo.Image != null)
            {

                MessageBox.Show("Siga las instrucciones para indicar la cama caliente", "Indicar cama caliente", MessageBoxButtons.OK);
                lbMensaje.Text = "Encierra la cama caliente de tu impresora haciendo click y arrastrando sobre la imagen";
                lbMensaje.Visible = true;

                pictureVideo.Image = new Image<Bgr, byte>(new Bitmap(pictureVideo.Image)).Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear).ToBitmap();
                video.Dispose();
                pausa = true;

                cameando = true;
                cortandoCama = true;

            }
            else
            {
                MessageBox.Show("Debe tener una cámara activa o video", "Sin imagen", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ObtenerCama()
        {
            if (rect2 != Rectangle.Empty)
            {
                var img = new Image<Bgr, byte>(new Bitmap(pictureVideo.Image));
                //var img = mframe.ToImage<Bgr, byte>();
                img.Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear);
                img.ROI = rect2;
                var imgROI = img.Copy();
                img.ROI = Rectangle.Empty;

                MostrarCamara();
                realCama= new Image<Bgr, byte>(imgROI.ToBitmap());
                realCamaAux = realCama;
                lbMensaje.Visible = false;
                cama = true;
                pictureCama.Image = realCama.ToBitmap();
            }
            else
            {
                MessageBox.Show("Debe seleccionar un área válida para el extrusor, volver a intentar", "Extrusor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void matchCama()
        {
            if(!hotend)
            {
                imgScene = mframe.ToImage<Bgr, byte>();
                imgScene.Resize(pictureVideo.Width, pictureVideo.Height, Emgu.CV.CvEnum.Inter.Linear);
            }
            
            var template = realCama;
            Mat imgOut = new Mat();
            CvInvoke.MatchTemplate(imgScene, template, imgOut, Emgu.CV.CvEnum.TemplateMatchingType.SqdiffNormed);
            double minVal = 0.0;
            double maxVal = 0.0;
            Point minLoc = new Point();
            Point maxLoc = new Point();
            CvInvoke.MinMaxLoc(imgOut, ref minVal, ref maxVal, ref minLoc, ref maxLoc);
            rCama = new Rectangle(minLoc, template.Size);

            pictureCama.Image = realCamaAux.ToBitmap();
            imgScene.ROI = rCama;
            realCamaAux = imgScene.Copy();
            imgScene.ROI = Rectangle.Empty;

            CvInvoke.Rectangle(imgScene, rCama, new Bgra(0, 190, 0, 0).MCvScalar, 2);
            CvInvoke.PutText(imgScene, "Contacto", new Point(r.Left+5, r.Bottom - 5), Emgu.CV.CvEnum.FontFace.HersheyPlain, 0.95, new MCvScalar(255, 255, 255));
            CvInvoke.PutText(imgScene, "Cama", new Point(rCama.Left, rCama.Bottom - 5), Emgu.CV.CvEnum.FontFace.HersheyPlain, 0.95, new MCvScalar(0, 190, 0));

            //pictureVideo.Image = imgScene.ToBitmap();
            
        }

        #endregion
    }
}
