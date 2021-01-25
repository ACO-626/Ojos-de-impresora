namespace Ojos_de_impresora
{
    partial class FormSelectCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectCamera));
            this.pictureCamara = new System.Windows.Forms.PictureBox();
            this.btnRight = new System.Windows.Forms.PictureBox();
            this.btnLeft = new System.Windows.Forms.PictureBox();
            this.lbNameCamara = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.PictureBox();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamara)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureCamara
            // 
            this.pictureCamara.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureCamara.Image = ((System.Drawing.Image)(resources.GetObject("pictureCamara.Image")));
            this.pictureCamara.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureCamara.InitialImage")));
            this.pictureCamara.Location = new System.Drawing.Point(130, 38);
            this.pictureCamara.Name = "pictureCamara";
            this.pictureCamara.Size = new System.Drawing.Size(288, 179);
            this.pictureCamara.TabIndex = 0;
            this.pictureCamara.TabStop = false;
            // 
            // btnRight
            // 
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.ErrorImage = null;
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.InitialImage = null;
            this.btnRight.Location = new System.Drawing.Point(441, 87);
            this.btnRight.Name = "btnRight";
            this.btnRight.Size = new System.Drawing.Size(41, 84);
            this.btnRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnRight.TabIndex = 1;
            this.btnRight.TabStop = false;
            this.btnRight.Click += new System.EventHandler(this.btnRight_Click);
            // 
            // btnLeft
            // 
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.Location = new System.Drawing.Point(66, 87);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.Size = new System.Drawing.Size(41, 84);
            this.btnLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLeft.TabIndex = 2;
            this.btnLeft.TabStop = false;
            this.btnLeft.Click += new System.EventHandler(this.btnLeft_Click);
            // 
            // lbNameCamara
            // 
            this.lbNameCamara.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNameCamara.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.lbNameCamara.Font = new System.Drawing.Font("Montserrat", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNameCamara.Location = new System.Drawing.Point(0, 220);
            this.lbNameCamara.Name = "lbNameCamara";
            this.lbNameCamara.Size = new System.Drawing.Size(544, 42);
            this.lbNameCamara.TabIndex = 3;
            this.lbNameCamara.Text = "CAMARA";
            this.lbNameCamara.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(510, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(24, 24);
            this.btnClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnClose.TabIndex = 4;
            this.btnClose.TabStop = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeleccionar.Location = new System.Drawing.Point(216, 279);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(119, 26);
            this.btnSeleccionar.TabIndex = 5;
            this.btnSeleccionar.Text = "SELECCIONAR";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // FormSelectCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(543, 317);
            this.ControlBox = false;
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lbNameCamara);
            this.Controls.Add(this.btnLeft);
            this.Controls.Add(this.btnRight);
            this.Controls.Add(this.pictureCamara);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSelectCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSelectCamera";
            ((System.ComponentModel.ISupportInitialize)(this.pictureCamara)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureCamara;
        private System.Windows.Forms.PictureBox btnRight;
        private System.Windows.Forms.PictureBox btnLeft;
        private System.Windows.Forms.Label lbNameCamara;
        private System.Windows.Forms.PictureBox btnClose;
        private System.Windows.Forms.Button btnSeleccionar;
    }
}