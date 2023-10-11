namespace IPCServer
{
    partial class IPCServerForm
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
            this.lbHeader = new System.Windows.Forms.Label();
            this.lbStringsFromClient = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbHeader
            // 
            this.lbHeader.AutoSize = true;
            this.lbHeader.Location = new System.Drawing.Point(12, 9);
            this.lbHeader.Name = "lbHeader";
            this.lbHeader.Size = new System.Drawing.Size(105, 12);
            this.lbHeader.TabIndex = 0;
            this.lbHeader.Text = "클라이언트 메시지";
            // 
            // lbStringsFromClient
            // 
            this.lbStringsFromClient.FormattingEnabled = true;
            this.lbStringsFromClient.ItemHeight = 12;
            this.lbStringsFromClient.Location = new System.Drawing.Point(14, 24);
            this.lbStringsFromClient.Name = "lbStringsFromClient";
            this.lbStringsFromClient.Size = new System.Drawing.Size(358, 124);
            this.lbStringsFromClient.TabIndex = 1;
            // 
            // IPCServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.lbStringsFromClient);
            this.Controls.Add(this.lbHeader);
            this.Name = "IPCServerForm";
            this.Text = "IPC Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IPCServerForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbHeader;
        private System.Windows.Forms.ListBox lbStringsFromClient;
    }
}

