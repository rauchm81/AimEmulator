namespace AimEmulator
{
    partial class Form1
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
            this.textBoxComPortSend = new System.Windows.Forms.TextBox();
            this.listBoxData = new System.Windows.Forms.ListBox();
            this.sendButtonConnect = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.receiveButtonConnect = new System.Windows.Forms.Button();
            this.textBoxComPortReceive = new System.Windows.Forms.TextBox();
            this.checkBoxUseFile = new System.Windows.Forms.CheckBox();
            this.textBoxReceiveFile = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxComPortSend
            // 
            this.textBoxComPortSend.Location = new System.Drawing.Point(6, 6);
            this.textBoxComPortSend.Name = "textBoxComPortSend";
            this.textBoxComPortSend.Size = new System.Drawing.Size(100, 20);
            this.textBoxComPortSend.TabIndex = 0;
            this.textBoxComPortSend.Text = "COM1";
            // 
            // listBoxData
            // 
            this.listBoxData.FormattingEnabled = true;
            this.listBoxData.Location = new System.Drawing.Point(6, 35);
            this.listBoxData.Name = "listBoxData";
            this.listBoxData.Size = new System.Drawing.Size(420, 368);
            this.listBoxData.TabIndex = 1;
            // 
            // sendButtonConnect
            // 
            this.sendButtonConnect.Location = new System.Drawing.Point(112, 6);
            this.sendButtonConnect.Name = "sendButtonConnect";
            this.sendButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.sendButtonConnect.TabIndex = 2;
            this.sendButtonConnect.Text = "start";
            this.sendButtonConnect.UseVisualStyleBackColor = true;
            this.sendButtonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(440, 448);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBoxComPortSend);
            this.tabPage1.Controls.Add(this.listBoxData);
            this.tabPage1.Controls.Add(this.sendButtonConnect);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(432, 408);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Senden";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.textBoxReceiveFile);
            this.tabPage2.Controls.Add(this.checkBoxUseFile);
            this.tabPage2.Controls.Add(this.dataGridView);
            this.tabPage2.Controls.Add(this.receiveButtonConnect);
            this.tabPage2.Controls.Add(this.textBoxComPortReceive);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(432, 422);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Empfangen";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.Location = new System.Drawing.Point(7, 34);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(419, 382);
            this.dataGridView.TabIndex = 2;
            // 
            // receiveButtonConnect
            // 
            this.receiveButtonConnect.Location = new System.Drawing.Point(114, 7);
            this.receiveButtonConnect.Name = "receiveButtonConnect";
            this.receiveButtonConnect.Size = new System.Drawing.Size(75, 23);
            this.receiveButtonConnect.TabIndex = 1;
            this.receiveButtonConnect.Text = "connect";
            this.receiveButtonConnect.UseVisualStyleBackColor = true;
            this.receiveButtonConnect.Click += new System.EventHandler(this.receiveButtonConnect_Click);
            // 
            // textBoxComPortReceive
            // 
            this.textBoxComPortReceive.Location = new System.Drawing.Point(7, 7);
            this.textBoxComPortReceive.Name = "textBoxComPortReceive";
            this.textBoxComPortReceive.Size = new System.Drawing.Size(100, 20);
            this.textBoxComPortReceive.TabIndex = 0;
            this.textBoxComPortReceive.Text = "COM1";
            // 
            // checkBoxUseFile
            // 
            this.checkBoxUseFile.AutoSize = true;
            this.checkBoxUseFile.Location = new System.Drawing.Point(195, 11);
            this.checkBoxUseFile.Name = "checkBoxUseFile";
            this.checkBoxUseFile.Size = new System.Drawing.Size(51, 17);
            this.checkBoxUseFile.TabIndex = 3;
            this.checkBoxUseFile.Text = "Datei";
            this.checkBoxUseFile.UseVisualStyleBackColor = true;
            // 
            // textBoxReceiveFile
            // 
            this.textBoxReceiveFile.Location = new System.Drawing.Point(244, 9);
            this.textBoxReceiveFile.Name = "textBoxReceiveFile";
            this.textBoxReceiveFile.Size = new System.Drawing.Size(182, 20);
            this.textBoxReceiveFile.TabIndex = 4;
            this.textBoxReceiveFile.Text = "output_2010-08-28_12-42-30.log";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 472);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "AimEmulator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxComPortSend;
        private System.Windows.Forms.ListBox listBoxData;
        private System.Windows.Forms.Button sendButtonConnect;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox textBoxComPortReceive;
        private System.Windows.Forms.Button receiveButtonConnect;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.TextBox textBoxReceiveFile;
        private System.Windows.Forms.CheckBox checkBoxUseFile;
    }
}

