namespace PersonalSecretary
{
    partial class PointOfEntry
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PointOfEntry));
            this.LabelImg = new System.Windows.Forms.PictureBox();
            this.LabelText = new System.Windows.Forms.Label();
            this.StatusBar = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.webControl1 = new Awesomium.Windows.Forms.WebControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.LabelImg)).BeginInit();
            this.SuspendLayout();
            // 
            // LabelImg
            // 
            this.LabelImg.ErrorImage = ((System.Drawing.Image)(resources.GetObject("LabelImg.ErrorImage")));
            this.LabelImg.Image = ((System.Drawing.Image)(resources.GetObject("LabelImg.Image")));
            this.LabelImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("LabelImg.InitialImage")));
            this.LabelImg.Location = new System.Drawing.Point(50, 70);
            this.LabelImg.Name = "LabelImg";
            this.LabelImg.Size = new System.Drawing.Size(190, 210);
            this.LabelImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.LabelImg.TabIndex = 0;
            this.LabelImg.TabStop = false;
            // 
            // LabelText
            // 
            this.LabelText.AutoSize = true;
            this.LabelText.Font = new System.Drawing.Font("PF DinDisplay Pro", 34F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LabelText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(80)))), ((int)(((byte)(117)))));
            this.LabelText.Location = new System.Drawing.Point(289, 83);
            this.LabelText.Name = "LabelText";
            this.LabelText.Size = new System.Drawing.Size(236, 104);
            this.LabelText.TabIndex = 1;
            this.LabelText.Text = "Personal\n Secretary";
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = true;
            this.StatusBar.Font = new System.Drawing.Font("PF DinDisplay Pro", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(80)))), ((int)(((byte)(117)))));
            this.StatusBar.Location = new System.Drawing.Point(295, 187);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(13, 13);
            this.StatusBar.TabIndex = 2;
            this.StatusBar.Text = "1";
            // 
            // CloseButton
            // 
            this.CloseButton.Font = new System.Drawing.Font("PF DinDisplay Pro", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(80)))), ((int)(((byte)(117)))));
            this.CloseButton.Location = new System.Drawing.Point(534, 1);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 3;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(246, 203);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(302, 135);
            this.textBox1.TabIndex = 4;
            // 
            // webControl1
            // 
            this.webControl1.Location = new System.Drawing.Point(307, 27);
            this.webControl1.Size = new System.Drawing.Size(75, 23);
            this.webControl1.Source = new System.Uri("http://vk.com/", System.UriKind.Absolute);
            this.webControl1.TabIndex = 5;
            this.webControl1.DocumentReady += new Awesomium.Core.DocumentReadyEventHandler(this.Awesomium_Windows_Forms_WebControl_DocumentReady);
            // 
            // PointOfEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(238)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(560, 350);
            this.ControlBox = false;
            this.Controls.Add(this.webControl1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.LabelText);
            this.Controls.Add(this.LabelImg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PointOfEntry";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "s";
            this.Shown += new System.EventHandler(this.PointOfEntry_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.LabelImg)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox LabelImg;
        private System.Windows.Forms.Label LabelText;
        private System.Windows.Forms.Label StatusBar;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.TextBox textBox1;
        private Awesomium.Windows.Forms.WebControl webControl1;
    }
}