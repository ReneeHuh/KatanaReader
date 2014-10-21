using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.IO;
using System.Runtime.InteropServices;

namespace KatanaReader
{

    public partial class Mainform : Form
    {
#region gobals

        public SpeechAPI Speak = new SpeechAPI();

        ClipboardMonitor myClipboard = new ClipboardMonitor();

        public bool textchanged = false;
        public string filepath = null;

        private string clipboardText1;
        private string clipboardText2;

#endregion 
        
#region Loading & Closing Forms

        public Mainform()
        {
            SetStyle(ControlStyles.UserPaint | ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            InitializeComponent();
        }
        
        private void Mainform_Load(object sender, EventArgs e)
        {
            //clipboard 
            myClipboard.ClipboardChanged += new EventHandler<ClipboardChangedEventArgs>(myClipboard_ClipboardChanged);

            //speechAPI events
            Speak.SpeechStarted += new EventHandler<SpeakStartedEventArgs>(Speak_SpeakStarted);
            Speak.SpeechProgress += new EventHandler<SpeakProgressEventArgs>(Speak_SpeakProgress);
            Speak.SpeechCompleted += new EventHandler<SpeakCompletedEventArgs>(Speak_SpeakCompleted);
            Speak.SpeechBookmarkReached += new EventHandler<BookmarkReachedEventArgs>(Speak_BookmarkReached);
            Speak.SpeechStateChanged +=new EventHandler<StateChangedEventArgs>(Speak_SpeechStateChanged);
            //reading file and setting to rtbMain text
            StreamReader streamReader = new StreamReader("text.txt");
            string text = streamReader.ReadToEnd();
            streamReader.Close();

            rtbMain.Text = text;
        }

        private void Mainform_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (textchanged == true)
            //{
            //    SaveFirst();
            //}
        }
#endregion

#region Events & highlighting      
        
        void Speak_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            toolStripProgressBarReading.Value = (int)Speak.Progress;
            UpdateStatusLabel();
        }

        void Speak_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            toolStripProgressBarReading.Value = (int)Speak.Progress;
            UpdateStatusLabel();

        }

        void Speak_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {

            toolStripProgressBarReading.Value = (int)Speak.Progress;
            UpdateStatusLabel();
            
        }


        void Speak_BookmarkReached(object sender, BookmarkReachedEventArgs e)
        {
            //AddEventText("Bookmark reached: " + e.Bookmark);
        }
        private void Speak_SpeechStateChanged(object sender, StateChangedEventArgs e)
        { 
            if(Speak.State == SynthesizerState.Ready)
            {
                btPlay.Enabled=true;
                btPause.Enabled=false;
                btStop.Enabled=false;
                btNextSentence.Enabled=false;
                btPreviousSentence.Enabled=false;
            }
            else 
            {
                btPlay.Enabled = true;
                btPause.Enabled = true;
                btStop.Enabled = true;
                btNextSentence.Enabled = true;
                btPreviousSentence.Enabled = true;
            }
            
        }

        //clipboard task
        public void myClipboard_ClipboardChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AutoCopyEnable == true)
            {
                clipboardText2 = clipboardText1;
                clipboardText1 = Clipboard.GetText();

                if (clipboardText1 != clipboardText2)
                {
                    Speak.ClipBoardPlay(rtbMain, clipboardText1);
                }
                else
                {
                    //do nothing
                }
            }

        }

#endregion


#region Buttons




        private void rtbMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (Speak.State == SynthesizerState.Speaking)
            {
                Speak.Stop();
            }
            base.OnMouseDown(e);
        }
       
        private void btPlay_Click(object sender, EventArgs e)
        {
            Speak.Play(rtbMain);
        }

        private void btPause_Click(object sender, EventArgs e)
        {
            Speak.Pause();
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            Speak.Stop();
        }

        private void btPreviousSentence_Click(object sender, EventArgs e)
        {
            Speak.Stop();
            int pSen = SentenceUtil.FindPreviousSentence(rtbMain.Text,rtbMain.SelectionStart);
            rtbMain.SelectionStart = pSen;
            Speak.Play(rtbMain);
        }

        private void btNextSentence_Click(object sender, EventArgs e)
        {
            Speak.Stop();
            int nSen = SentenceUtil.FindNextSentence(rtbMain.Text,rtbMain.SelectionStart);
            rtbMain.SelectionStart = nSen;
            Speak.Play(rtbMain);
        }

        private void btExportToWav_Click(object sender, EventArgs e)
        {
            ExportForm exportfrm = new ExportForm();
            exportfrm.readText = rtbMain.Text;
            exportfrm.Rate = Speak.Rate;
            exportfrm.ShowDialog();
            if (Speak.State == SynthesizerState.Ready) rtbMain.Focus();
        }


        private void btAutoCopy_Click(object sender, EventArgs e)
        {
            if (Speak.AutoCopyEnable == true)
            {
                Properties.Settings.Default.AutoCopyEnable = false;
                AutoCopyUpdate();
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.AutoCopyEnable = true;
                AutoCopyUpdate();
                Properties.Settings.Default.Save();
            }
        }

        private void btVoiceOptions_Click(object sender, EventArgs e)
        {
            VoiceOptionsForm myVoiceOptions = new VoiceOptionsForm();
            myVoiceOptions.ShowDialog();
            //update Speak with new settings
            Speak.SelectVoice(Properties.Settings.Default.VoiceName);
            Speak.Volume = (int)Properties.Settings.Default.VoiceVolume;
            Speak.Rate = (int)Properties.Settings.Default.VoiceSpeed;
            if (Speak.State == SynthesizerState.Ready) rtbMain.Focus();
        }

        private void cbAutoCopyOptiun_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCopyOptions = cbAutoCopyOptions.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void btClipboard_Click(object sender, EventArgs e)
        {
            rtbMain.Text = Clipboard.GetText();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            rtbMain.Text = Clipboard.GetText();
            // add more options ie autocopyoptions
            Speak.Play(rtbMain);
        }
#endregion

#region Menu Strip
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Optionform myOptions = new Optionform();
            myOptions.ShowDialog();
        }

        private void aboutKatanaReaderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Aboutform myAbout = new Aboutform();
            myAbout.ShowDialog();
        }

        private void unDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Undo();
        }

        private void reDoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Paste();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //rtbMain.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.SelectAll();
        }

        private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbMain.Clear();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewCommand();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           OpenCommand();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCommand();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAsCommand();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Declare prntDoc as a new PrintDocument
            System.Drawing.Printing.PrintDocument prntDoc = new System.Drawing.Printing.PrintDocument();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ////Declare preview as a new PrintPreviewDialog
            //PrintPreviewDialog preview = new PrintPreviewDialog();
            ////Declare prntDoc_PrintPage as a new EventHandler for prntDoc's Print Page
            //prntDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(prntDoc_PrintPage);
            ////Set the PrintPreview's Document equal to prntDoc
            //preview.Document = prntDoc;
            ////Show the PrintPreview Dialog
            //if (preview.ShowDialog(this) == DialogResult.OK)
            //{
            //    //Generate the PrintPreview
            //    prntDoc.Print();
            //}
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #endregion


#region File Commands
        private void ShowOpenDialogBox()
        {
            OpenFileDialog openbox = new OpenFileDialog();
            openbox.Filter = "Text Files|*.txt|All|*.*";

            DialogResult results = openbox.ShowDialog();

            if (results == DialogResult.OK)
            {
                filepath = openbox.FileName;
                ReadFile(filepath);
                SetTitle(openbox.SafeFileName);
                textchanged = false;
            }
        }

        private void ReadFile(string fpath)
        {
            string ftext = File.ReadAllText(fpath);
            rtbMain.Text = ftext;
        }

        private void SaveFile(string fpath)
        {
            File.WriteAllText(fpath, rtbMain.Text);
        }

        private string SaveFirst()
        {
            DialogResult results = MessageBox.Show("Do you want to save your changes first?", "Save File?", MessageBoxButtons.YesNoCancel);

            if (results == DialogResult.Yes)
            {
                if (filepath == null)
                {
                    SaveFile(filepath);
                }
                else
                {
                    SaveCommand();
                }
            }
            else if (results == DialogResult.Cancel)
            {
                return "Cancel";
            }
            return "Nothing";
        }
        private void ShowSaveDialogBox()
        {
            SaveFileDialog savebox = new SaveFileDialog();
            savebox.Filter = "Text Files|*.txt|All|*.*";

            DialogResult results = savebox.ShowDialog();

            if (results == DialogResult.OK)
            {
                filepath = savebox.FileName;
                SaveFile(filepath);
                char[] period = {'.'};
                char[] slash = {'/'};
                string  fname = savebox.FileName;
                int indexperiod = fname.LastIndexOfAny(period);
                int indexslash = fname.LastIndexOfAny(slash);
                fname = fname.Substring(indexslash,(indexperiod-indexslash));
                SetTitle(fname);
            }
        }
        private void ClearState()
        {
            filepath = null;
            textchanged = false;

            rtbMain.Text = "";

            ResetTitle();

        }
        private void NewCommand()
        {
            if (textchanged == true)
            {
                string sf = SaveFirst();
                if (sf != "Cancel")
                {
                    ClearState();
                }
            }
            else
            {
                ClearState();
            }
        }

        private void OpenCommand()
        {
            if (textchanged == true)
            {
                SaveFirst();
                ShowOpenDialogBox();
            }
            else
            {
                ShowOpenDialogBox();
            }
        }

        private void SaveCommand()
        {
            if (filepath == null)
            {
                ShowSaveDialogBox();
            }
            else
            {
                SaveFile(filepath);
            }
        }

        private void SaveAsCommand()
        {
            ShowSaveDialogBox();
        }

        private void SetTitle(string x)
        {
            Mainform.ActiveForm.Text = "KatanaReader - " + x;
        }
        private void ResetTitle()
        {
            Mainform.ActiveForm.Text = "KatanaReader";
        }

#endregion

        void UpdateStatusLabel()
        {
            if (Speak.State == SynthesizerState.Paused)
            {
                toolStripStatusLabelPlayingMode.Text = "Paused";
            }
            else if (Speak.State == SynthesizerState.Ready)
            {
                toolStripStatusLabelPlayingMode.Text = "Ready";
            }
            else if (Speak.State == SynthesizerState.Speaking)
            {
                toolStripStatusLabelPlayingMode.Text = "Speaking";
            }
        }

        private void AutoCopyUpdate()
        {
            if (Properties.Settings.Default.AutoCopyEnable == true)
            {
                btAutoCopy.Text = "AutoCopy On";
                btAutoCopy.BackColor = System.Drawing.Color.LightGreen;
                cbAutoCopyOptions.Enabled = true;
            }
            else
            {
                btAutoCopy.Text = "AutoCopy Off";
                btAutoCopy.BackColor = System.Drawing.Color.White;
                cbAutoCopyOptions.Enabled = false;
            }
        }
       
        private void rtbMain_TextChanged(object sender, EventArgs e)
        {
            //textchanged = true;
        }





    }
}
