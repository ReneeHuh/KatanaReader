using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Speech.Synthesis;
using System.Threading;
using System.IO;

namespace KatanaReader
{
    public partial class ExportForm : Form
    {
        public ExportForm()
        {
            InitializeComponent();
        }

        public SpeechSynthesizer Speak = new SpeechSynthesizer();

        public int Rate
        {
            get
            {
                return Speak.Rate;
            }
            set
            {
                Speak.Rate = value;
            }
        }
        public string readText{get; set;}


        BackgroundWorker bgwWaveExport;

        string filename;

        

        private void ExportForm_Load(object sender, EventArgs e)
        {
            //create background worker
            bgwWaveExport = new BackgroundWorker();

            //add background worker events
            bgwWaveExport.DoWork += new DoWorkEventHandler(bgwWaveExport_DoWork);
            bgwWaveExport.ProgressChanged += new ProgressChangedEventHandler
                    (bgwWaveExport_ProgressChanged);
            bgwWaveExport.RunWorkerCompleted += new RunWorkerCompletedEventHandler
                    (bgwWaveExport_RunWorkerCompleted);
            bgwWaveExport.WorkerReportsProgress = true;
            bgwWaveExport.WorkerSupportsCancellation = true;

            //update voice options
            Speak.SelectVoice(Properties.Settings.Default.VoiceName);
            Speak.Volume = (int)Properties.Settings.Default.VoiceVolume;
            Speak.Rate = (int)Properties.Settings.Default.VoiceSpeed;

            //starts the tts process
            StartExport();
        }

        void Speak_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            //Progresss

            double progress;
            int total = readText.Length;
            total = ((int)((double)total * 1.05));
            int current = e.CharacterPosition;

            progress = ((double)current / (double)total) * 100;
            int iprogress = (int)progress;

            bgwWaveExport.ReportProgress(iprogress);
            //progressBar1.Value = (int)progress;
            //label1.Text = "Reading... " + (int)progress + "%";

        }

        private void StartExport()
        {
            //start 

            //open save file dialog box
            SaveFileDialog savebox = new SaveFileDialog();
            savebox.Filter = "MP3 Files|*.mp3|Wav Files|*.wav|All|*.*";

            //check if ok or  not
            DialogResult results = savebox.ShowDialog();

            if (results == DialogResult.OK)
            {
                filename = savebox.FileName;
                //btCancel.Enabled = true;

                //btExportToWav.Enabled = false;


                //string text = rtbMain.Text;
                //gtext = text;
                bgwWaveExport.RunWorkerAsync(readText);
            }
            else 
            {
                this.Close();
            }
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            if (bgwWaveExport.IsBusy)
            {
                bgwWaveExport.CancelAsync();

                //btExportToWav.Enabled = true;

                //MessageBox.Show("Exporting is Complete");
            }
        }

        void bgwWaveExport_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                label1.Text = "Task Cancelled.";
            }
            else if (e.Error != null)
            {
                label1.Text = "Error ";
            }
            else
            {
                label1.Text = "Task Completed...";

                btCancel.Visible = false;
                btClose.Visible = true;
                btOpenFile.Visible = true;
                btOpenFolder.Visible = true;


            }

            
            //btExportToWav.Enabled = true;
            //btCancel.Enabled = false;
        }


        void bgwWaveExport_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //added buffer to change to reading to saving
            progressBar1.Value = e.ProgressPercentage;

            if (e.ProgressPercentage < 95)
                label1.Text = "Reading......" + progressBar1.Value.ToString() + "%";
            else if (e.ProgressPercentage < 99 && e.ProgressPercentage > 95)
                label1.Text = "Saving......";
            else
                label1.Text = "Finsihed";

        }


        void bgwWaveExport_DoWork(object sender, DoWorkEventArgs e)
        {
            //input arg = text
            string argumentText = e.Argument as string;

            //create event to track speak change of word
            Speak.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(Speak_SpeakProgress);

            if (filename.LastIndexOf("wav") > 0)
            {
                //set default to wave then change back after done
                Speak.SetOutputToWaveFile(filename);
                //non asomtice speak
                Speak.Speak(argumentText);
                Speak.SetOutputToDefaultAudioDevice();

                bgwWaveExport.ReportProgress(95);
                Thread.Sleep(200);
                bgwWaveExport.ReportProgress(97);
                Thread.Sleep(200);
                bgwWaveExport.ReportProgress(99);
                Thread.Sleep(200);
                bgwWaveExport.ReportProgress(100);
            }
            else if (filename.LastIndexOf("mp3") > 0)
            {
                //temp wav file,set then reset default audio
                Speak.SetOutputToWaveFile("export.wav");
                Speak.Speak(argumentText);
                Speak.SetOutputToDefaultAudioDevice();

                bgwWaveExport.ReportProgress(95);

                bool waitFlag = true;

                string outfile = " -b 64 " + "export.wav " + filename;

                System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo();
                psi.FileName = "lame.exe";
                psi.Arguments = outfile;
                //psi.WorkingDirectory = pworkingDir;
                psi.WindowStyle = System.Diagnostics.ProcessWindowStyle.Minimized;
                System.Diagnostics.Process p = System.Diagnostics.Process.Start(psi);
                bgwWaveExport.ReportProgress(98);
                
                if (waitFlag)
                {
                    p.WaitForExit();
                    // wait for exit of called application
                }
                
                //File.Delete("export.wav");
                
                bgwWaveExport.ReportProgress(100);
                
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btOpenFolder_Click(object sender, EventArgs e)
        {
            string dir = System.IO.Path.GetDirectoryName(filename);
            System.Diagnostics.Process.Start(dir);

            //this.Close();
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(filename);
            //this.Close();
        }
    }
}
