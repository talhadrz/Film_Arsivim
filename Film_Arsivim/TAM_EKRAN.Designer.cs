namespace Film_Arsivim
{
    partial class Tam_Ekran
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
            this.button1 = new System.Windows.Forms.Button();
            this.web2 = new Microsoft.Web.WebView2.WinForms.WebView2();
            ((System.ComponentModel.ISupportInitialize)(this.web2)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button1.Location = new System.Drawing.Point(1, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(147, 40);
            this.button1.TabIndex = 0;
            this.button1.Text = "< Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // web2
            // 
            this.web2.AllowExternalDrop = true;
            this.web2.CreationProperties = null;
            this.web2.DefaultBackgroundColor = System.Drawing.Color.White;
            this.web2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.web2.Location = new System.Drawing.Point(0, 0);
            this.web2.Name = "web2";
            this.web2.Size = new System.Drawing.Size(728, 529);
            this.web2.TabIndex = 1;
            this.web2.ZoomFactor = 1D;
            // 
            // Tam_Ekran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 529);
            this.Controls.Add(this.web2);
            this.Controls.Add(this.button1);
            this.Name = "Tam_Ekran";
            this.Text = "TAM EKRAN";
            this.Load += new System.EventHandler(this.Tam_Ekran_Load);
            ((System.ComponentModel.ISupportInitialize)(this.web2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        public Microsoft.Web.WebView2.WinForms.WebView2 web2;
    }
}