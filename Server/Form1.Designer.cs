﻿namespace Server
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonAcceptIncomingConnection = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonAcceptIncomingConnection
            // 
            this.buttonAcceptIncomingConnection.Location = new System.Drawing.Point(12, 163);
            this.buttonAcceptIncomingConnection.Name = "buttonAcceptIncomingConnection";
            this.buttonAcceptIncomingConnection.Size = new System.Drawing.Size(207, 23);
            this.buttonAcceptIncomingConnection.TabIndex = 0;
            this.buttonAcceptIncomingConnection.Text = "Accept Incoming Connection";
            this.buttonAcceptIncomingConnection.UseVisualStyleBackColor = true;
            this.buttonAcceptIncomingConnection.Click += new System.EventHandler(this.buttonAcceptIncomingConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 198);
            this.Controls.Add(this.buttonAcceptIncomingConnection);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAcceptIncomingConnection;
    }
}
