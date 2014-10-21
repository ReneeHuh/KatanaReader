namespace KatanaReader
{
    partial class Mainform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            this.cbAutoCopyOptions = new System.Windows.Forms.ComboBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelWelcome = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPlayingMode = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressBarReading = new System.Windows.Forms.ToolStripProgressBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printPreviewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reDoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.katanaReadercomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutKatanaReaderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btAutoCopy = new System.Windows.Forms.Button();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.btVoiceOptions = new System.Windows.Forms.Button();
            this.btPlayClear = new System.Windows.Forms.Button();
            this.btNextSentence = new System.Windows.Forms.Button();
            this.btPreviousSentence = new System.Windows.Forms.Button();
            this.btExportToWav = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.btPause = new System.Windows.Forms.Button();
            this.btPlay = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAutoCopyOptions
            // 
            this.cbAutoCopyOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbAutoCopyOptions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAutoCopyOptions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAutoCopyOptions.FormattingEnabled = true;
            this.cbAutoCopyOptions.Items.AddRange(new object[] {
            "Paste & Play at Beginging",
            "Paste & Play at End",
            "Clear, Paste & Play"});
            this.cbAutoCopyOptions.Location = new System.Drawing.Point(146, 531);
            this.cbAutoCopyOptions.Name = "cbAutoCopyOptions";
            this.cbAutoCopyOptions.Size = new System.Drawing.Size(208, 29);
            this.cbAutoCopyOptions.TabIndex = 0;
            this.cbAutoCopyOptions.SelectedIndexChanged += new System.EventHandler(this.cbAutoCopyOptiun_SelectedIndexChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.GripMargin = new System.Windows.Forms.Padding(30, 2, 2, 2);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelWelcome,
            this.toolStripStatusLabelPlayingMode,
            this.toolStripStatusLabel1,
            this.toolStripProgressBarReading});
            this.statusStrip1.Location = new System.Drawing.Point(0, 563);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1083, 24);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelWelcome
            // 
            this.toolStripStatusLabelWelcome.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabelWelcome.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelWelcome.Name = "toolStripStatusLabelWelcome";
            this.toolStripStatusLabelWelcome.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripStatusLabelWelcome.Size = new System.Drawing.Size(173, 19);
            this.toolStripStatusLabelWelcome.Text = "Welcome To KatanaReader";
            // 
            // toolStripStatusLabelPlayingMode
            // 
            this.toolStripStatusLabelPlayingMode.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabelPlayingMode.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelPlayingMode.Name = "toolStripStatusLabelPlayingMode";
            this.toolStripStatusLabelPlayingMode.Padding = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.toolStripStatusLabelPlayingMode.Size = new System.Drawing.Size(104, 19);
            this.toolStripStatusLabelPlayingMode.Text = "Playing Mode";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(689, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripProgressBarReading
            // 
            this.toolStripProgressBarReading.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripProgressBarReading.Name = "toolStripProgressBarReading";
            this.toolStripProgressBarReading.Size = new System.Drawing.Size(100, 18);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.controlsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1083, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.printToolStripMenuItem,
            this.printPreviewToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // printPreviewToolStripMenuItem
            // 
            this.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem";
            this.printPreviewToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.printPreviewToolStripMenuItem.Text = "Print Preview";
            this.printPreviewToolStripMenuItem.Click += new System.EventHandler(this.printPreviewToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.unDoToolStripMenuItem,
            this.reDoToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.selectAllToolStripMenuItem,
            this.clearAllToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // unDoToolStripMenuItem
            // 
            this.unDoToolStripMenuItem.Name = "unDoToolStripMenuItem";
            this.unDoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.unDoToolStripMenuItem.Text = "UnDo";
            this.unDoToolStripMenuItem.Click += new System.EventHandler(this.unDoToolStripMenuItem_Click);
            // 
            // reDoToolStripMenuItem
            // 
            this.reDoToolStripMenuItem.Name = "reDoToolStripMenuItem";
            this.reDoToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.reDoToolStripMenuItem.Text = "ReDo";
            this.reDoToolStripMenuItem.Click += new System.EventHandler(this.reDoToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // clearAllToolStripMenuItem
            // 
            this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
            this.clearAllToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.clearAllToolStripMenuItem.Text = "Clear All";
            this.clearAllToolStripMenuItem.Click += new System.EventHandler(this.clearAllToolStripMenuItem_Click);
            // 
            // controlsToolStripMenuItem
            // 
            this.controlsToolStripMenuItem.Name = "controlsToolStripMenuItem";
            this.controlsToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.controlsToolStripMenuItem.Text = "Controls";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.optionsToolStripMenuItem.Text = "Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.katanaReadercomToolStripMenuItem,
            this.aboutKatanaReaderToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.contentsToolStripMenuItem.Text = "Contents";
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.registerToolStripMenuItem.Text = "Register";
            // 
            // katanaReadercomToolStripMenuItem
            // 
            this.katanaReadercomToolStripMenuItem.Name = "katanaReadercomToolStripMenuItem";
            this.katanaReadercomToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.katanaReadercomToolStripMenuItem.Text = "KatanaReader.com";
            // 
            // aboutKatanaReaderToolStripMenuItem
            // 
            this.aboutKatanaReaderToolStripMenuItem.Name = "aboutKatanaReaderToolStripMenuItem";
            this.aboutKatanaReaderToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.aboutKatanaReaderToolStripMenuItem.Text = "About KatanaReader";
            this.aboutKatanaReaderToolStripMenuItem.Click += new System.EventHandler(this.aboutKatanaReaderToolStripMenuItem_Click);
            // 
            // btAutoCopy
            // 
            this.btAutoCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btAutoCopy.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btAutoCopy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAutoCopy.Location = new System.Drawing.Point(13, 531);
            this.btAutoCopy.Name = "btAutoCopy";
            this.btAutoCopy.Size = new System.Drawing.Size(127, 29);
            this.btAutoCopy.TabIndex = 4;
            this.btAutoCopy.Text = "AutoCopy OFF";
            this.btAutoCopy.UseVisualStyleBackColor = false;
            this.btAutoCopy.Click += new System.EventHandler(this.btAutoCopy_Click);
            // 
            // rtbMain
            // 
            this.rtbMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbMain.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMain.Location = new System.Drawing.Point(13, 108);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(1058, 417);
            this.rtbMain.TabIndex = 6;
            this.rtbMain.Text = "";
            this.rtbMain.TextChanged += new System.EventHandler(this.rtbMain_TextChanged);
            this.rtbMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.rtbMain_MouseDown);
            // 
            // btVoiceOptions
            // 
            this.btVoiceOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btVoiceOptions.BackgroundImage = global::KatanaReader.Properties.Resources.voiceoptions;
            this.btVoiceOptions.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btVoiceOptions.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btVoiceOptions.Location = new System.Drawing.Point(996, 28);
            this.btVoiceOptions.Name = "btVoiceOptions";
            this.btVoiceOptions.Size = new System.Drawing.Size(75, 73);
            this.btVoiceOptions.TabIndex = 21;
            this.btVoiceOptions.UseVisualStyleBackColor = true;
            this.btVoiceOptions.Click += new System.EventHandler(this.btVoiceOptions_Click);
            // 
            // btPlayClear
            // 
            this.btPlayClear.BackgroundImage = global::KatanaReader.Properties.Resources.ClipPlay;
            this.btPlayClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPlayClear.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlayClear.Location = new System.Drawing.Point(419, 28);
            this.btPlayClear.Name = "btPlayClear";
            this.btPlayClear.Size = new System.Drawing.Size(75, 75);
            this.btPlayClear.TabIndex = 19;
            this.btPlayClear.UseVisualStyleBackColor = true;
            this.btPlayClear.Click += new System.EventHandler(this.button4_Click);
            // 
            // btNextSentence
            // 
            this.btNextSentence.BackgroundImage = global::KatanaReader.Properties.Resources.next;
            this.btNextSentence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btNextSentence.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btNextSentence.Location = new System.Drawing.Point(338, 28);
            this.btNextSentence.Name = "btNextSentence";
            this.btNextSentence.Size = new System.Drawing.Size(75, 73);
            this.btNextSentence.TabIndex = 18;
            this.btNextSentence.UseVisualStyleBackColor = true;
            this.btNextSentence.Click += new System.EventHandler(this.btNextSentence_Click);
            // 
            // btPreviousSentence
            // 
            this.btPreviousSentence.BackgroundImage = global::KatanaReader.Properties.Resources.Prevous;
            this.btPreviousSentence.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPreviousSentence.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPreviousSentence.Location = new System.Drawing.Point(257, 28);
            this.btPreviousSentence.Name = "btPreviousSentence";
            this.btPreviousSentence.Size = new System.Drawing.Size(75, 73);
            this.btPreviousSentence.TabIndex = 17;
            this.btPreviousSentence.UseVisualStyleBackColor = true;
            this.btPreviousSentence.Click += new System.EventHandler(this.btPreviousSentence_Click);
            // 
            // btExportToWav
            // 
            this.btExportToWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btExportToWav.BackgroundImage = global::KatanaReader.Properties.Resources.wmploc_DLL_I02dc_0409;
            this.btExportToWav.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btExportToWav.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btExportToWav.Location = new System.Drawing.Point(915, 28);
            this.btExportToWav.Name = "btExportToWav";
            this.btExportToWav.Size = new System.Drawing.Size(75, 73);
            this.btExportToWav.TabIndex = 9;
            this.btExportToWav.UseVisualStyleBackColor = true;
            this.btExportToWav.Click += new System.EventHandler(this.btExportToWav_Click);
            // 
            // btStop
            // 
            this.btStop.BackgroundImage = global::KatanaReader.Properties.Resources.stop;
            this.btStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btStop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btStop.Location = new System.Drawing.Point(175, 28);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 75);
            this.btStop.TabIndex = 8;
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // btPause
            // 
            this.btPause.BackgroundImage = global::KatanaReader.Properties.Resources.pause;
            this.btPause.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPause.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPause.Location = new System.Drawing.Point(94, 28);
            this.btPause.Name = "btPause";
            this.btPause.Size = new System.Drawing.Size(75, 75);
            this.btPause.TabIndex = 7;
            this.btPause.UseVisualStyleBackColor = true;
            this.btPause.Click += new System.EventHandler(this.btPause_Click);
            // 
            // btPlay
            // 
            this.btPlay.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btPlay.BackgroundImage = global::KatanaReader.Properties.Resources.play;
            this.btPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btPlay.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPlay.Location = new System.Drawing.Point(12, 27);
            this.btPlay.Name = "btPlay";
            this.btPlay.Size = new System.Drawing.Size(75, 75);
            this.btPlay.TabIndex = 5;
            this.btPlay.UseVisualStyleBackColor = true;
            this.btPlay.Click += new System.EventHandler(this.btPlay_Click);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1083, 587);
            this.Controls.Add(this.btVoiceOptions);
            this.Controls.Add(this.btPlayClear);
            this.Controls.Add(this.btNextSentence);
            this.Controls.Add(this.btPreviousSentence);
            this.Controls.Add(this.btExportToWav);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btPause);
            this.Controls.Add(this.rtbMain);
            this.Controls.Add(this.btPlay);
            this.Controls.Add(this.btAutoCopy);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.cbAutoCopyOptions);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Mainform";
            this.Text = "Katana Reader 0.8";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Mainform_FormClosing);
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbAutoCopyOptions;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem controlsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPlayingMode;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reDoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem katanaReadercomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutKatanaReaderToolStripMenuItem;
        private System.Windows.Forms.Button btAutoCopy;
        private System.Windows.Forms.Button btPlay;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.Button btPause;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Button btExportToWav;
        private System.Windows.Forms.Button btPreviousSentence;
        private System.Windows.Forms.Button btNextSentence;
        private System.Windows.Forms.Button btPlayClear;
        private System.Windows.Forms.ToolStripMenuItem printPreviewToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelWelcome;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBarReading;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btVoiceOptions;


        

         

    }



}


