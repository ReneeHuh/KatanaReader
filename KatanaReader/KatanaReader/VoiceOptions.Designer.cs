namespace KatanaReader
{
    partial class VoiceOptionsForm
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.lblVoices = new System.Windows.Forms.Label();
            this.cbVoices = new System.Windows.Forms.ComboBox();
            this.lblVolume = new System.Windows.Forms.Label();
            this.lblSpeed = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.nudVolume = new System.Windows.Forms.NumericUpDown();
            this.nudSpeed = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(260, 61);
            this.trackBar1.Minimum = -10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(67, 45);
            this.trackBar1.TabIndex = 27;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBar1.Value = 5;
            // 
            // lblVoices
            // 
            this.lblVoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVoices.AutoSize = true;
            this.lblVoices.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoices.Location = new System.Drawing.Point(12, 9);
            this.lblVoices.Name = "lblVoices";
            this.lblVoices.Size = new System.Drawing.Size(59, 21);
            this.lblVoices.TabIndex = 26;
            this.lblVoices.Text = "Voices ";
            // 
            // cbVoices
            // 
            this.cbVoices.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbVoices.FormattingEnabled = true;
            this.cbVoices.Location = new System.Drawing.Point(82, 9);
            this.cbVoices.Name = "cbVoices";
            this.cbVoices.Size = new System.Drawing.Size(146, 21);
            this.cbVoices.TabIndex = 25;
            this.cbVoices.SelectedIndexChanged += new System.EventHandler(this.cbVoices_SelectedIndexChanged);
            // 
            // lblVolume
            // 
            this.lblVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVolume.AutoSize = true;
            this.lblVolume.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVolume.Location = new System.Drawing.Point(12, 70);
            this.lblVolume.Name = "lblVolume";
            this.lblVolume.Size = new System.Drawing.Size(64, 21);
            this.lblVolume.TabIndex = 22;
            this.lblVolume.Text = "Volume";
            // 
            // lblSpeed
            // 
            this.lblSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSpeed.AutoSize = true;
            this.lblSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSpeed.Location = new System.Drawing.Point(12, 40);
            this.lblSpeed.Name = "lblSpeed";
            this.lblSpeed.Size = new System.Drawing.Size(53, 21);
            this.lblSpeed.TabIndex = 21;
            this.lblSpeed.Text = "Speed";
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(281, 137);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 28;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // nudVolume
            // 
            this.nudVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudVolume.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::KatanaReader.Properties.Settings.Default, "VoiceVolume", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudVolume.Location = new System.Drawing.Point(82, 74);
            this.nudVolume.Name = "nudVolume";
            this.nudVolume.Size = new System.Drawing.Size(76, 20);
            this.nudVolume.TabIndex = 24;
            this.nudVolume.Value = global::KatanaReader.Properties.Settings.Default.VoiceVolume;
            this.nudVolume.ValueChanged += new System.EventHandler(this.nudVolume_ValueChanged);
            // 
            // nudSpeed
            // 
            this.nudSpeed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSpeed.DataBindings.Add(new System.Windows.Forms.Binding("Value", global::KatanaReader.Properties.Settings.Default, "VoiceSpeed", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nudSpeed.Location = new System.Drawing.Point(82, 44);
            this.nudSpeed.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudSpeed.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            -2147483648});
            this.nudSpeed.Name = "nudSpeed";
            this.nudSpeed.Size = new System.Drawing.Size(76, 20);
            this.nudSpeed.TabIndex = 23;
            this.nudSpeed.Value = global::KatanaReader.Properties.Settings.Default.VoiceSpeed;
            this.nudSpeed.ValueChanged += new System.EventHandler(this.nudSpeed_ValueChanged);
            // 
            // VoiceOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 172);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.lblVoices);
            this.Controls.Add(this.cbVoices);
            this.Controls.Add(this.nudVolume);
            this.Controls.Add(this.nudSpeed);
            this.Controls.Add(this.lblVolume);
            this.Controls.Add(this.lblSpeed);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VoiceOptionsForm";
            this.Text = "Voice Options";
            this.Load += new System.EventHandler(this.VoiceOptionsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudVolume)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label lblVoices;
        private System.Windows.Forms.ComboBox cbVoices;
        private System.Windows.Forms.NumericUpDown nudVolume;
        private System.Windows.Forms.NumericUpDown nudSpeed;
        private System.Windows.Forms.Label lblVolume;
        private System.Windows.Forms.Label lblSpeed;
        private System.Windows.Forms.Button btClose;
    }
}