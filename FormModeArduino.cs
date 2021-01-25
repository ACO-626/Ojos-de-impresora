using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ojos_de_impresora
{
    public partial class FormModeArduino : Form
    {
        public FormModeArduino()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBlue_Click(object sender, EventArgs e)
        {
            btnUSB.Visible = false;
            lbPuertoBlue.Visible = true;
            comboPuertoBlue.Visible = true;
            btnConecBlue.Visible = true;
            lbCancelBlue.Visible = true;
        }
        private void lbCancelBlue_Click(object sender, EventArgs e)
        {
            btnBlue.Enabled = true;
            btnUSB.Visible = true;
            lbPuertoBlue.Visible = false;
            comboPuertoBlue.Visible = false;
            btnConecBlue.Visible = false;
            lbCancelBlue.Visible = false;
        }
        private void btnUSB_Click(object sender, EventArgs e)
        {
            btnBlue.Visible = false;
            btnUSB.Enabled = false;
            lbPuertoUSB.Visible = true;
            comboPortUSBB.Visible = true;
            btnConectarUsb.Visible = true;
            lbCancelUSB.Visible = true;
        }

        private void lbCancelUSB_Click(object sender, EventArgs e)
        {
            btnUSB.Enabled = true;
            btnBlue.Visible = true;
            lbPuertoUSB.Visible = false;
            comboPortUSBB.Visible = false;
            btnConectarUsb.Visible = false;
            lbCancelUSB.Visible = false;
        }
    }
}
