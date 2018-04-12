namespace MoodleDownloader
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.grpBoxKurse = new System.Windows.Forms.GroupBox();
            this.grpBoxAnzeige = new System.Windows.Forms.GroupBox();
            this.treeVwCourse = new System.Windows.Forms.TreeView();
            this.acroReaderShowPdf = new AxAcroPDFLib.AxAcroPDF();
            this.grpBoxKurse.SuspendLayout();
            this.grpBoxAnzeige.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.acroReaderShowPdf)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxKurse
            // 
            this.grpBoxKurse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxKurse.Controls.Add(this.treeVwCourse);
            this.grpBoxKurse.Location = new System.Drawing.Point(12, 12);
            this.grpBoxKurse.Name = "grpBoxKurse";
            this.grpBoxKurse.Size = new System.Drawing.Size(278, 563);
            this.grpBoxKurse.TabIndex = 0;
            this.grpBoxKurse.TabStop = false;
            this.grpBoxKurse.Text = "grpBoxKurse";
            // 
            // grpBoxAnzeige
            // 
            this.grpBoxAnzeige.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBoxAnzeige.Controls.Add(this.acroReaderShowPdf);
            this.grpBoxAnzeige.Location = new System.Drawing.Point(296, 12);
            this.grpBoxAnzeige.Name = "grpBoxAnzeige";
            this.grpBoxAnzeige.Size = new System.Drawing.Size(484, 563);
            this.grpBoxAnzeige.TabIndex = 1;
            this.grpBoxAnzeige.TabStop = false;
            this.grpBoxAnzeige.Text = "grpBoxAnzeige";
            // 
            // treeVwCourse
            // 
            this.treeVwCourse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeVwCourse.Location = new System.Drawing.Point(6, 19);
            this.treeVwCourse.Name = "treeVwCourse";
            this.treeVwCourse.Size = new System.Drawing.Size(266, 538);
            this.treeVwCourse.TabIndex = 0;
            this.treeVwCourse.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeVwCourse_AfterSelect);
            // 
            // acroReaderShowPdf
            // 
            this.acroReaderShowPdf.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.acroReaderShowPdf.Enabled = true;
            this.acroReaderShowPdf.Location = new System.Drawing.Point(6, 19);
            this.acroReaderShowPdf.Name = "acroReaderShowPdf";
            this.acroReaderShowPdf.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("acroReaderShowPdf.OcxState")));
            this.acroReaderShowPdf.Size = new System.Drawing.Size(472, 538);
            this.acroReaderShowPdf.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 587);
            this.Controls.Add(this.grpBoxAnzeige);
            this.Controls.Add(this.grpBoxKurse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.grpBoxKurse.ResumeLayout(false);
            this.grpBoxAnzeige.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.acroReaderShowPdf)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxKurse;
        private System.Windows.Forms.GroupBox grpBoxAnzeige;
        private System.Windows.Forms.TreeView treeVwCourse;
        private AxAcroPDFLib.AxAcroPDF acroReaderShowPdf;
    }
}

