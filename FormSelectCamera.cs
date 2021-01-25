#region Bibliotecas
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Management;
#endregion

namespace Ojos_de_impresora
{
    public partial class FormSelectCamera : Form
    {
        int indice = 0;

        #region Inicialización
        public FormSelectCamera()
        {
            InitializeComponent();
            for (int i = 0; i < GetAllConnectedCameras().Count; i++)
            {
                indice = i;
            }
            try
            {
                lbNameCamara.Text = GetAllConnectedCameras()[indice].ToString();
            }
           catch(Exception)
            {
                MessageBox.Show("No se detectan cámaras conectadas");
            }
 

        }
        #endregion

        #region ObtenerCamaras
        public static List<string> GetAllConnectedCameras()
        {
            var cameraNames = new List<string>();
            using (var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PnPEntity WHERE (PNPClass = 'Image' OR PNPClass = 'Camera')"))
            {
                foreach (var device in searcher.Get())
                {
                    cameraNames.Add(device["Caption"].ToString());
                }
                cameraNames.Reverse();
            }

            return cameraNames;
        }
        #endregion

        #region Cerrar
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region Seleccionar
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            FormOjosImpresora formPadre =  Owner as FormOjosImpresora;
            formPadre.IndexCamara = indice;

            formPadre.MostrarCamara();
            
            this.Close();
        }
        #endregion

        #region Botones
        private void btnRight_Click(object sender, EventArgs e)
        {
            if(indice>=GetAllConnectedCameras().Count-1)
            {
                indice = 0;
            }else
            {
                indice++;
            }
            lbNameCamara.Text = GetAllConnectedCameras()[indice].ToString();
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
            if (indice <= 0 )
            {
                indice = GetAllConnectedCameras().Count-1;
            }
            else
            {
                indice--;
            }
            lbNameCamara.Text = GetAllConnectedCameras()[indice].ToString();
        }

        #endregion


    }
}
