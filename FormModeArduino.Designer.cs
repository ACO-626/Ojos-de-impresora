namespace Ojos_de_impresora
{
    partial class FormModeArduino
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormModeArduino));
            this.btnUSB = new System.Windows.Forms.PictureBox();
            this.btnBlue = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.comboPortUSBB = new System.Windows.Forms.ComboBox();
            this.comboPuertoBlue = new System.Windows.Forms.ComboBox();
            this.btnConectarUsb = new System.Windows.Forms.Button();
            this.lbPuertoBlue = new System.Windows.Forms.Label();
            this.btnConecBlue = new System.Windows.Forms.Button();
            this.lbCancelBlue = new System.Windows.Forms.Label();
            this.lbCancelUSB = new System.Windows.Forms.Label();
            this.lbPuertoUSB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnUSB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUSB
            // 
            this.btnUSB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUSB.Image = ((System.Drawing.Image)(resources.GetObject("btnUSB.Image")));
            this.btnUSB.Location = new System.Drawing.Point(48, 60);
            this.btnUSB.Name = "btnUSB";
            this.btnUSB.Size = new System.Drawing.Size(239, 222);
            this.btnUSB.TabIndex = 0;
            this.btnUSB.TabStop = false;
            this.btnUSB.Click += new System.EventHandler(this.btnUSB_Click);
            // 
            // btnBlue
            // 
            this.btnBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBlue.Image = ((System.Drawing.Image)(resources.GetObject("btnBlue.Image")));
            this.btnBlue.Location = new System.Drawing.Point(331, 60);
            this.btnBlue.Name = "btnBlue";
            this.btnBlue.Size = new System.Drawing.Size(239, 222);
            this.btnBlue.TabIndex = 1;
            this.btnBlue.TabStop = false;
            this.btnBlue.Click += new System.EventHandler(this.btnBlue_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.ErrorImage = null;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(576, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // comboPortUSBB
            // 
            this.comboPortUSBB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPortUSBB.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPortUSBB.FormattingEnabled = true;
            this.comboPortUSBB.Location = new System.Drawing.Point(394, 129);
            this.comboPortUSBB.Name = "comboPortUSBB";
            this.comboPortUSBB.Size = new System.Drawing.Size(137, 33);
            this.comboPortUSBB.TabIndex = 3;
            this.comboPortUSBB.Visible = false;
            // 
            // comboPuertoBlue
            // 
            this.comboPuertoBlue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPuertoBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboPuertoBlue.FormattingEnabled = true;
            this.comboPuertoBlue.Location = new System.Drawing.Point(105, 129);
            this.comboPuertoBlue.Name = "comboPuertoBlue";
            this.comboPuertoBlue.Size = new System.Drawing.Size(137, 33);
            this.comboPuertoBlue.TabIndex = 4;
            this.comboPuertoBlue.Visible = false;
            // 
            // btnConectarUsb
            // 
            this.btnConectarUsb.BackColor = System.Drawing.Color.White;
            this.btnConectarUsb.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConectarUsb.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConectarUsb.ForeColor = System.Drawing.Color.Teal;
            this.btnConectarUsb.Location = new System.Drawing.Point(394, 169);
            this.btnConectarUsb.Name = "btnConectarUsb";
            this.btnConectarUsb.Size = new System.Drawing.Size(137, 44);
            this.btnConectarUsb.TabIndex = 6;
            this.btnConectarUsb.Text = "Conectar";
            this.btnConectarUsb.UseVisualStyleBackColor = false;
            this.btnConectarUsb.Visible = false;
            // 
            // lbPuertoBlue
            // 
            this.lbPuertoBlue.AutoSize = true;
            this.lbPuertoBlue.Font = new System.Drawing.Font("Proxy 1", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuertoBlue.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPuertoBlue.Location = new System.Drawing.Point(107, 81);
            this.lbPuertoBlue.Name = "lbPuertoBlue";
            this.lbPuertoBlue.Size = new System.Drawing.Size(135, 34);
            this.lbPuertoBlue.TabIndex = 7;
            this.lbPuertoBlue.Text = "PUERTO";
            this.lbPuertoBlue.Visible = false;
            // 
            // btnConecBlue
            // 
            this.btnConecBlue.BackColor = System.Drawing.Color.White;
            this.btnConecBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConecBlue.Font = new System.Drawing.Font("Montserrat", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConecBlue.ForeColor = System.Drawing.Color.Teal;
            this.btnConecBlue.Location = new System.Drawing.Point(105, 169);
            this.btnConecBlue.Name = "btnConecBlue";
            this.btnConecBlue.Size = new System.Drawing.Size(137, 44);
            this.btnConecBlue.TabIndex = 11;
            this.btnConecBlue.Text = "Conectar";
            this.btnConecBlue.UseVisualStyleBackColor = false;
            this.btnConecBlue.Visible = false;
            // 
            // lbCancelBlue
            // 
            this.lbCancelBlue.AutoSize = true;
            this.lbCancelBlue.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCancelBlue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancelBlue.ForeColor = System.Drawing.Color.Red;
            this.lbCancelBlue.Location = new System.Drawing.Point(147, 216);
            this.lbCancelBlue.Name = "lbCancelBlue";
            this.lbCancelBlue.Size = new System.Drawing.Size(56, 15);
            this.lbCancelBlue.TabIndex = 12;
            this.lbCancelBlue.Text = "Cancelar";
            this.lbCancelBlue.Visible = false;
            this.lbCancelBlue.Click += new System.EventHandler(this.lbCancelBlue_Click);
            // 
            // lbCancelUSB
            // 
            this.lbCancelUSB.AutoSize = true;
            this.lbCancelUSB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbCancelUSB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCancelUSB.ForeColor = System.Drawing.Color.Red;
            this.lbCancelUSB.Location = new System.Drawing.Point(433, 216);
            this.lbCancelUSB.Name = "lbCancelUSB";
            this.lbCancelUSB.Size = new System.Drawing.Size(56, 15);
            this.lbCancelUSB.TabIndex = 13;
            this.lbCancelUSB.Text = "Cancelar";
            this.lbCancelUSB.Visible = false;
            this.lbCancelUSB.Click += new System.EventHandler(this.lbCancelUSB_Click);
            // 
            // lbPuertoUSB
            // 
            this.lbPuertoUSB.AutoSize = true;
            this.lbPuertoUSB.Font = new System.Drawing.Font("Proxy 1", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPuertoUSB.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lbPuertoUSB.Location = new System.Drawing.Point(396, 81);
            this.lbPuertoUSB.Name = "lbPuertoUSB";
            this.lbPuertoUSB.Size = new System.Drawing.Size(135, 34);
            this.lbPuertoUSB.TabIndex = 14;
            this.lbPuertoUSB.Text = "PUERTO";
            this.lbPuertoUSB.Visible = false;
            // 
            // FormModeArduino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumSeaGreen;
            this.ClientSize = new System.Drawing.Size(618, 327);
            this.Controls.Add(this.lbPuertoUSB);
            this.Controls.Add(this.lbCancelUSB);
            this.Controls.Add(this.lbCancelBlue);
            this.Controls.Add(this.btnConecBlue);
            this.Controls.Add(this.lbPuertoBlue);
            this.Controls.Add(this.btnConectarUsb);
            this.Controls.Add(this.comboPuertoBlue);
            this.Controls.Add(this.comboPortUSBB);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.btnBlue);
            this.Controls.Add(this.btnUSB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormModeArduino";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "btnClose";
            ((System.ComponentModel.ISupportInitialize)(this.btnUSB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox btnUSB;
        private System.Windows.Forms.PictureBox btnBlue;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.ComboBox comboPortUSBB;
        private System.Windows.Forms.ComboBox comboPuertoBlue;
        private System.Windows.Forms.Button btnConectarUsb;
        private System.Windows.Forms.Label lbPuertoBlue;
        private System.Windows.Forms.Button btnConecBlue;
        private System.Windows.Forms.Label lbCancelBlue;
        private System.Windows.Forms.Label lbCancelUSB;
        private System.Windows.Forms.Label lbPuertoUSB;
    }
}