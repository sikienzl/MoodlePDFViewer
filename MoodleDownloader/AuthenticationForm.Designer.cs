namespace MoodleDownloader
{
    partial class AuthenticationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthenticationForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBenutzername = new System.Windows.Forms.Label();
            this.lblPasswort = new System.Windows.Forms.Label();
            this.txtBoxBenutzername = new System.Windows.Forms.TextBox();
            this.txtBoxPasswort = new System.Windows.Forms.TextBox();
            this.bttnSubmit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.bttnSubmit);
            this.groupBox1.Controls.Add(this.txtBoxPasswort);
            this.groupBox1.Controls.Add(this.txtBoxBenutzername);
            this.groupBox1.Controls.Add(this.lblPasswort);
            this.groupBox1.Controls.Add(this.lblBenutzername);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(375, 82);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // lblBenutzername
            // 
            this.lblBenutzername.AutoSize = true;
            this.lblBenutzername.Location = new System.Drawing.Point(6, 26);
            this.lblBenutzername.Name = "lblBenutzername";
            this.lblBenutzername.Size = new System.Drawing.Size(88, 13);
            this.lblBenutzername.TabIndex = 0;
            this.lblBenutzername.Text = "lblBenutzername:";
            // 
            // lblPasswort
            // 
            this.lblPasswort.AutoSize = true;
            this.lblPasswort.Location = new System.Drawing.Point(6, 49);
            this.lblPasswort.Name = "lblPasswort";
            this.lblPasswort.Size = new System.Drawing.Size(63, 13);
            this.lblPasswort.TabIndex = 1;
            this.lblPasswort.Text = "lblPasswort:";
            // 
            // txtBoxBenutzername
            // 
            this.txtBoxBenutzername.Location = new System.Drawing.Point(100, 23);
            this.txtBoxBenutzername.Name = "txtBoxBenutzername";
            this.txtBoxBenutzername.Size = new System.Drawing.Size(172, 20);
            this.txtBoxBenutzername.TabIndex = 2;
            // 
            // txtBoxPasswort
            // 
            this.txtBoxPasswort.Location = new System.Drawing.Point(100, 46);
            this.txtBoxPasswort.Name = "txtBoxPasswort";
            this.txtBoxPasswort.Size = new System.Drawing.Size(172, 20);
            this.txtBoxPasswort.TabIndex = 3;
            // 
            // bttnSubmit
            // 
            this.bttnSubmit.Location = new System.Drawing.Point(278, 46);
            this.bttnSubmit.Name = "bttnSubmit";
            this.bttnSubmit.Size = new System.Drawing.Size(84, 19);
            this.bttnSubmit.TabIndex = 4;
            this.bttnSubmit.Text = "button1";
            this.bttnSubmit.UseVisualStyleBackColor = true;
            this.bttnSubmit.Click += new System.EventHandler(this.bttnSubmit_Click);
            // 
            // AuthenticationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(399, 101);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "AuthenticationForm";
            this.ShowIcon = false;
            this.Text = "AuthenticationForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button bttnSubmit;
        private System.Windows.Forms.TextBox txtBoxPasswort;
        private System.Windows.Forms.TextBox txtBoxBenutzername;
        private System.Windows.Forms.Label lblPasswort;
        private System.Windows.Forms.Label lblBenutzername;
    }
}