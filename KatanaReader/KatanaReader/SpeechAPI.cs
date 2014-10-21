using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Speech.Synthesis;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;

namespace KatanaReader
{


    public class SpeechAPI
    {
#region gobals
        public SpeechSynthesizer Speak = new SpeechSynthesizer();

        public RichTextBox rtbLocal;
        public RichTextBox rtbBackup;

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, uint wMsg,
                                       UIntPtr wParam, IntPtr lParam);
 
        public enum AutoCopyStates { PlayAtBeginging, PlayAtEnd, ClearPlay }
        
        public int PlayOffset;

        int progressBarStartLocation;
        int progressBarEndLocation;

        string clipboardText;

        public event EventHandler<SpeakStartedEventArgs> SpeechStarted;
        public event EventHandler<SpeakProgressEventArgs> SpeechProgress;
        public event EventHandler<SpeakCompletedEventArgs> SpeechCompleted;
        public event EventHandler<BookmarkReachedEventArgs> SpeechBookmarkReached;
        public event EventHandler<StateChangedEventArgs> SpeechStateChanged;
#endregion

        public SpeechAPI()
        {
            Speak.SpeakStarted += new EventHandler<SpeakStartedEventArgs>(Speak_SpeakStarted);
            Speak.SpeakProgress += new EventHandler<SpeakProgressEventArgs>(Speak_SpeakProgress);
            Speak.SpeakCompleted += new EventHandler<SpeakCompletedEventArgs>(Speak_SpeakCompleted);
            Speak.BookmarkReached += new EventHandler<BookmarkReachedEventArgs>(Speak_BookmarkReached);
            Speak.StateChanged += new EventHandler<StateChangedEventArgs>(Speak_StateChanged);

            //no more cross threading issues (only when I break out speech in serpate file
            Control.CheckForIllegalCrossThreadCalls = false;
            
            //inital setup
            InitalSetup();
        }
                
#region Properties
        private double progress;
        public double Progress
        {
            get { return progress; }
            set { progress = value; }
        }
        public int Rate
        {
            get { return Speak.Rate; }
            set { Speak.Rate = value; }
        }
        public int Volume
        {
            get { return Speak.Volume; }
            set { Speak.Volume = value; }
        }
        public List<string> InstalledVoices
        {
            get
            {
                List<string> ListedVoices = new List<string>();

                foreach (System.Speech.Synthesis.InstalledVoice Voice in Speak.GetInstalledVoices())
                {
                    ListedVoices.Add(Voice.VoiceInfo.Name);
                }
                return ListedVoices;
            }

        }
        public AutoCopyStates AutoCopyMode
        {
            get
            {
                if (Properties.Settings.Default.AutoCopyOptions == 0) { return AutoCopyStates.PlayAtBeginging; }
                else if (Properties.Settings.Default.AutoCopyOptions == 1) { return AutoCopyStates.PlayAtEnd; }
                else if (Properties.Settings.Default.AutoCopyOptions == 2) { return AutoCopyStates.ClearPlay; }
                else { return AutoCopyStates.ClearPlay; }
            }   
            set
            {
                if (AutoCopyStates.PlayAtBeginging == value) { Properties.Settings.Default.AutoCopyOptions = 0; }
                else if (AutoCopyStates.PlayAtEnd == value) { Properties.Settings.Default.AutoCopyOptions = 1; }
                else if (AutoCopyStates.ClearPlay == value) { Properties.Settings.Default.AutoCopyOptions = 2; }
                else { Properties.Settings.Default.AutoCopyOptions = 2; }
                Properties.Settings.Default.Save();
            }
        }
        public bool AutoCopyEnable
        {
            get { return Properties.Settings.Default.AutoCopyEnable; }
            set { Properties.Settings.Default.AutoCopyEnable = value; }
        }

        public SynthesizerState State
        {
            get { return Speak.State; }
        }
        public void SelectVoice(string ivoice)
        {
            //?????? try catch maybe
            try
            {
                Speak.SelectVoice(ivoice);
            }
            catch
            {
                //do nothing
            }
        }

#endregion

#region Events

        void Speak_SpeakStarted(object sender, SpeakStartedEventArgs e)
        {
            //Start of Speak

            //Make Copy of RichTextBox for flicker free Unhightlighting
            rtbBackup = rtbPassbyValue(rtbLocal);

            //pass on message to update Forms
            SpeechStarted(sender,e);
        }
        void Speak_SpeakProgress(object sender, SpeakProgressEventArgs e)
        {
            //plays normal/click at start/0  
            //Play from autoautocopy clearplay at start/0
            //Play from ClipBoard button
            //Plays from AutoPlay with Beginging
            //all other plays start at offset

            if (e.CharacterPosition + e.CharacterCount <= rtbLocal.TextLength &&
                 rtbLocal.Text.Substring(e.CharacterPosition, e.CharacterCount) == e.Text)
            {
                //highlight word & previous
                UnHighLightPreviousWord(e.CharacterPosition);
                HighLightWord(e.CharacterPosition, e.CharacterCount);

                //update progress bar (2/4 ways)
                if (AutoCopyEnable == true && AutoCopyMode == AutoCopyStates.PlayAtBeginging)
                {
                    UpdateProgress(e.CharacterPosition, progressBarEndLocation);
                }
                else
                {
                    UpdateProgress(e.CharacterPosition, rtbLocal.TextLength);
                }

                //scroll to correct line
                int pWordLine = rtbLocal.GetLineFromCharIndex(SentenceUtil.FindPreviousWord(rtbLocal.Text, e.CharacterPosition - 1));
                int nWordLine = rtbLocal.GetLineFromCharIndex(SentenceUtil.FindNextWord(rtbLocal.Text, e.CharacterPosition));
                if (pWordLine != nWordLine)
                {
                    ScrollToCursor(e.CharacterPosition);
                }
            }
            else
            {
                //plays with offset 
                //Play normal/click with start after 0
                //Autoplayfrom playend

                int CorrectPlayPosition = e.CharacterPosition + PlayOffset;

                //highlight word & previous
                UnHighLightPreviousWord(CorrectPlayPosition);
                HighLightWord(CorrectPlayPosition, e.CharacterCount);

                //update progress bar
                if (AutoCopyEnable == true && AutoCopyMode == AutoCopyStates.PlayAtEnd)
                {
                    int temptotal = progressBarEndLocation - progressBarStartLocation;
                    UpdateProgress(e.CharacterPosition, temptotal);
                }
                else
                {
                    UpdateProgress(e.CharacterPosition, rtbLocal.TextLength);
                }

                //if lines are differnt then scroll to correct line
                int pWordLine = rtbLocal.GetLineFromCharIndex(SentenceUtil.FindPreviousWord(rtbLocal.Text, CorrectPlayPosition - 1));
                int nWordLine = rtbLocal.GetLineFromCharIndex(SentenceUtil.FindNextWord(rtbLocal.Text, CorrectPlayPosition));
                if (pWordLine != nWordLine)
                {
                    ScrollToCursor(CorrectPlayPosition);
                }
                
                //why is this here??? 4 ways to play reduced to two with this
                //UpdateProgress(e.CharacterPosition, rtbLocal.TextLength);
            }
            //pass on Progress to MainForms
            SpeechProgress(sender, e);
        }
        void Speak_SpeakCompleted(object sender, SpeakCompletedEventArgs e)
        {
            // Finshed Reading either by stop or End
            //MUST UnHightLight All Words
            
            //Update Progressbar after Stop
            progress = 0;

            //new Way back via PassbyValue and restore text then done
            int tempCousor = rtbLocal.SelectionStart;
            rtbLocal.Text = rtbBackup.Text;
            rtbLocal.SelectionStart = tempCousor;

            //Old Ways Flickering before doubleBuffer and click and drag highlights text in blue
            //UnHighLightAllWords();
            //UnHighLight();

            //send on message to MainFroms
            SpeechCompleted(sender, e);
        }
        void Speak_BookmarkReached(object sender, BookmarkReachedEventArgs e)
        {
            //do nothing
            //SpeechReached(sender, e);
        }
        void Speak_StateChanged(object sender, StateChangedEventArgs e)
        {
            //updates the labels of change
            SpeechStateChanged(sender, e);
        }

#endregion

 
#region SpeechCommands
        public void InitalSetup()
        {
            this.SelectVoice(Properties.Settings.Default.VoiceName);
            this.Volume = (int)Properties.Settings.Default.VoiceVolume;
            this.Rate = (int)Properties.Settings.Default.VoiceSpeed;
        }

#endregion


#region AutoCopyCommands

        public void ClipBoardPlay(RichTextBox iRichTextBox, string Clipboard)
        {
            // Start of Auto & ClipBoard Play, PassByReference RichTextBox
            rtbLocal = iRichTextBox;
            ////////PassByValue
            ////////rtbLocal = rtbPassbyValue(iRichTextBox); 

            clipboardText = Clipboard;
            AutoCopyCommandPlay();
        }

        private void AutoCopyCommandPlay()
        {
            if (AutoCopyEnable == true)
            {

                Stop();

                if (AutoCopyMode == AutoCopyStates.PlayAtBeginging)
                {
                    rtbLocal.Text = clipboardText + "\n\n" + rtbLocal.Text;
                    progressBarStartLocation = 0;
                    progressBarEndLocation = clipboardText.Length;
                    //progressbarAutoPlayAtEnd = false;
                    //progressbarAutoPlayAtBegining = true;
                    AutoCopyPlayBeinging(0, clipboardText.Length);
                }
                else if (AutoCopyMode == AutoCopyStates.PlayAtEnd)
                {
                    int oldLenght = rtbLocal.TextLength;
                    rtbLocal.Text = rtbLocal.Text + "\n\n" + clipboardText;
                    progressBarStartLocation = oldLenght;
                    progressBarEndLocation = rtbLocal.TextLength;
                    //progressbarAutoPlayAtEnd = true;
                    //progressbarAutoPlayAtBegining = false;
                    AutoCopyPlayEnd(oldLenght);
                }
                else if (AutoCopyMode == AutoCopyStates.ClearPlay)
                {
                    rtbLocal.Text = clipboardText;
                    AutoCopyPlayClear();
                }
            }
        }

        private void AutoCopyPlayClear()
        {
            Speak.SpeakAsync(rtbLocal.Text);
        }

        private void AutoCopyPlayBeinging(int StartOfInsertedText, int EndOfInsertedText)
        {
            Speak.SpeakAsync(rtbLocal.Text.Substring(StartOfInsertedText, EndOfInsertedText));
        }

        private void AutoCopyPlayEnd(int OrginalTextEnd)
        {
            PlayOffset = OrginalTextEnd;
            int readLenght = rtbLocal.TextLength - OrginalTextEnd;
            Speak.SpeakAsync(rtbLocal.Text.Substring(OrginalTextEnd, readLenght));
        }

#endregion

#region PlayCommands
        public void Play(RichTextBox iRichTextBox)
        {
            // Start of Play, PassByReference RichTextBox
            rtbLocal = iRichTextBox;
            ////////PassByValue
            ////////rtbLocal = rtbPassbyValue(iRichTextBox);

            
            if (Speak.State == SynthesizerState.Ready)
            {
                //play offset is used when you do not start from the 0 but from prevouse sentance and 
                // there are problems in tracking the highlihghing

                PlayOffset = SentenceUtil.FindPreviousSentence(rtbLocal.Text, rtbLocal.SelectionStart);
                ScrollToCursor(PlayOffset);
                Speak.SpeakAsync(rtbLocal.Text.Substring(PlayOffset));
            }
            else if (Speak.State == SynthesizerState.Speaking)
            {
                Speak.Pause();
                
            }
            else if (Speak.State == SynthesizerState.Paused)
            {
                Speak.Resume();
                
            }
        }

        public void Pause()
        {
            if (Speak.State == SynthesizerState.Ready)
            {
                //do nothing
            }
            else if (Speak.State == SynthesizerState.Speaking)
            {
                Speak.Pause();
                
            }
            else if (Speak.State == SynthesizerState.Paused)
            {
                Speak.Resume();
                
            }
        }
        public void Stop()
        {
            if (Speak.State == SynthesizerState.Ready)
            {
                //do nothing
            }
            else if (Speak.State == SynthesizerState.Speaking)
            {
                //progressbarAutoPlayAtEnd = false;
                //progressbarAutoPlayAtBegining = false;
                Speak.SpeakAsyncCancelAll();
                //UnHighLightAllWords();
            }
            else if (Speak.State == SynthesizerState.Paused)
            {
                //progressbarAutoPlayAtEnd = false;
                //progressbarAutoPlayAtBegining = false;
                Speak.SpeakAsyncCancelAll();
                //UnHighLightAllWords();
            }
            
        }

#endregion

#region Highlight & UnHightlight

        private void HighLightWord(int start, int length)
        {
            //only ran from SpeakProgress
            rtbLocal.Select(start, length);
            rtbLocal.SelectionBackColor = Color.Yellow;
        }
        private void UnHighLightPreviousWord(int pWordEnd)
        {
            //only ran from SpeakProgress
            int pWordStart = SentenceUtil.FindPreviousWord(rtbLocal.Text, pWordEnd - 1);
            if (pWordStart == -1) pWordStart = 0;
            int pWordLenght = pWordEnd - pWordStart;
            rtbLocal.SelectionBackColor = Color.White;
            rtbLocal.Select(pWordStart, pWordLenght);
            rtbLocal.SelectionBackColor = Color.White;
        }
        void UnHighLight()
        {
            //old way to UNHIGHTLIGHT
            rtbLocal.SelectionBackColor = Color.White;
            rtbLocal.SelectAll();
            rtbLocal.DeselectAll();
        }
        private void UnHighLightAllWords()
        {
            //old way to UNHIGHTLIGHT
            int tempcursorstart = rtbLocal.SelectionStart;
            rtbLocal.SelectionBackColor = Color.White;
            rtbLocal.SelectAll();
            rtbLocal.SelectionBackColor = Color.White;
            rtbLocal.DeselectAll();
            rtbLocal.Select(tempcursorstart, 0);
        }
        public void ScrollToCursor(int cursor)
        {
            Point top = new Point(0, 0);
            Point bottom = new Point(rtbLocal.ClientSize.Width, rtbLocal.ClientSize.Height);
            
            int TopVisibleLine = rtbLocal.GetLineFromCharIndex(rtbLocal.GetCharIndexFromPosition(top));
            int ButtomVisibleLine = rtbLocal.GetLineFromCharIndex(rtbLocal.GetCharIndexFromPosition(bottom));

            double PixelsPerline = bottom.Y /Math.Abs(TopVisibleLine -ButtomVisibleLine);

            int CurrentLine = rtbLocal.GetLineFromCharIndex(cursor);
            int VisibleLineDiff = ButtomVisibleLine - TopVisibleLine;
            int middleLine = TopVisibleLine + (int)((double)VisibleLineDiff / 2.0);

            //scroll down POS numbers 
            if (CurrentLine > middleLine)
            {
                int diff = CurrentLine - middleLine;
                if (diff < 5) { ScrollByPixels(diff, PixelsPerline); }
                else { ScrollByLines(diff); }
            }
            //scroll up NEG numbers 
            if (CurrentLine < TopVisibleLine)
            {
                int diff = CurrentLine - middleLine;
                if (Math.Abs(diff) < 5) { ScrollByPixels(diff, PixelsPerline); }
                else { ScrollByLines(diff); }
            }

        }

        private void ScrollByLines(int DiffToScroll)
        {
            // Long Scroll & Slow
            //used only when there are 5 or more lines to scroll
            int TotalTimeInterval;
            TotalTimeInterval = 260;
            int JumpTime = TotalTimeInterval / DiffToScroll;

            if (DiffToScroll > 0)
            {
                for (int i = 0; i <= DiffToScroll; i++)
                {
                    SendMessage(rtbLocal.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(1));
                    Thread.Sleep(JumpTime);
                }
            }
            else
            {
                for (int i = 0; i >= DiffToScroll; i--)
                {
                    SendMessage(rtbLocal.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(-1));
                    Thread.Sleep(Math.Abs(JumpTime));
                }
            }
            
        }

        private void ScrollByPixels(int diffToScroll,double PixelsPerLine)
        {
            // Short Scroll & Fast
            //used only for 5 or less lines need to be scrolled
            double dtotalPixels = (double)diffToScroll * PixelsPerLine;
            int totalpixels = Convert.ToInt32(dtotalPixels);
            int TotalTimeInterval, JumpTime;
 
            TotalTimeInterval = 120;
            JumpTime = TotalTimeInterval / Math.Abs(totalpixels);
            ScrollByPixel bob = new ScrollByPixel();
   
            if (totalpixels > 0)
            {
                for (int i = 0; i <= diffToScroll; i++)
                {
                    for (int j = 0; j <= PixelsPerLine; j++)
                    {
                        bob.scroll(rtbLocal.Handle, 1);
                        Thread.Sleep(JumpTime);
                    }
                    //locks in scroll after stop scroll of 1 line of pixels (scroll frame does not lock in when stopped if not used)
                    SendMessage(rtbLocal.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(1));
                    SendMessage(rtbLocal.Handle, (uint)0x00B6, (UIntPtr)0, (IntPtr)(-1));
                    //aslso set styles to double buffer to avoid flicker in these lines; ControlStyles.DoubleBuffer
                }
                
            }
            else
            {
                // NOT USED
                //this is not used because it will not scroll up upless it is out of frame of richtextbox but then it uses scrollByLine
                for (int i = 0; i >= totalpixels; i--)
                {
                    bob.scroll(rtbLocal.Handle, -1);
                    Thread.Sleep(Math.Abs(JumpTime));
                }
            }
            
            
        
        }
        #endregion


#region miscellaneous

        
        private void UpdateProgress(int CurrentLocaiton, int total)
        {
            //ran from speak progress with 4 different way to run, keeps track of % done of read
            //updates internal progress read
            double precent = 100 * ((double)CurrentLocaiton / (double)total);
            Progress = precent;
            // ???? use to to update the progressbar it's self
        }

        private void UpdateStatusLabel()
        {
            //if (Speak.State == SynthesizerState.Paused)
            //{
            //    toolStripStatusLabelPlayingMode.Text = "Paused";
            //}
            //else if (Speak.State == SynthesizerState.Ready)
            //{
            //    toolStripStatusLabelPlayingMode.Text = "Ready";
            //}
            //else if (Speak.State == SynthesizerState.Speaking)
            //{
            //    toolStripStatusLabelPlayingMode.Text = "Speaking";
            //}
        }
        
        public RichTextBox rtbPassbyValue(RichTextBox iRTB)
        {
            //used to create a copy of richtextbox instead of passbyrefence
            RichTextBox local = new RichTextBox();
            local = new System.Windows.Forms.RichTextBox();
            local.Anchor = iRTB.Anchor;
            local.BorderStyle = iRTB.BorderStyle;
            System.Drawing.Font iFont = new Font(iRTB.Font.Name, iRTB.Font.Size, iRTB.Font.Style, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            local.Font = iFont;
            local.Location = new System.Drawing.Point(iRTB.Location.X, iRTB.Location.Y);
            local.Name = "rtbLocal";
            local.Size = new Size(iRTB.Size.Width, iRTB.Size.Height);
            local.TabIndex = iRTB.TabIndex;
            local.Text = iRTB.Text;
            return local;
        
        }
#endregion

    }
}
