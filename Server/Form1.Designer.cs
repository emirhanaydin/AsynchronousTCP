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
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.textBoxSendToAll = new System.Windows.Forms.TextBox();
            this.buttonSendToAll = new System.Windows.Forms.Button();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(548, 289);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(100, 52);
            this.buttonStartServer.TabIndex = 0;
            this.buttonStartServer.Text = "Start Server";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.buttonStartServer_Click);
            // 
            // textBoxSendToAll
            // 
            this.textBoxSendToAll.Enabled = false;
            this.textBoxSendToAll.Location = new System.Drawing.Point(12, 289);
            this.textBoxSendToAll.Multiline = true;
            this.textBoxSendToAll.Name = "textBoxSendToAll";
            this.textBoxSendToAll.Size = new System.Drawing.Size(318, 51);
            this.textBoxSendToAll.TabIndex = 1;
            // 
            // buttonSendToAll
            // 
            this.buttonSendToAll.Enabled = false;
            this.buttonSendToAll.Location = new System.Drawing.Point(336, 289);
            this.buttonSendToAll.Name = "buttonSendToAll";
            this.buttonSendToAll.Size = new System.Drawing.Size(100, 52);
            this.buttonSendToAll.TabIndex = 2;
            this.buttonSendToAll.Text = "Send to All";
            this.buttonSendToAll.UseVisualStyleBackColor = true;
            this.buttonSendToAll.Click += new System.EventHandler(this.buttonSendToAll_Click);
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Enabled = false;
            this.buttonStopServer.Location = new System.Drawing.Point(442, 289);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(100, 52);
            this.buttonStopServer.TabIndex = 3;
            this.buttonStopServer.Text = "Stop Server";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.BackColor = System.Drawing.Color.White;
            this.textBoxLog.Location = new System.Drawing.Point(12, 12);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(637, 271);
            this.textBoxLog.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 353);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.buttonSendToAll);
            this.Controls.Add(this.textBoxSendToAll);
            this.Controls.Add(this.buttonStartServer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Asynchronous TCP Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.TextBox textBoxSendToAll;
        private System.Windows.Forms.Button buttonSendToAll;
        private System.Windows.Forms.Button buttonStopServer;
        private System.Windows.Forms.TextBox textBoxLog;
    }
}

