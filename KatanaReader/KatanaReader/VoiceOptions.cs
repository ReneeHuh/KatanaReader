using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;

namespace KatanaReader
{
    public partial class VoiceOptionsForm : Form
    {
        public VoiceOptionsForm()
        {
            InitializeComponent();
        }

        public SpeechSynthesizer SpeakOptions = new SpeechSynthesizer();

        private void VoiceOptionsForm_Load(object sender, EventArgs e)
        {
            foreach (System.Speech.Synthesis.InstalledVoice Voice in SpeakOptions.GetInstalledVoices())
            {
                this.cbVoices.Items.Add(Voice.VoiceInfo.Name);

            }

            cbVoices.SelectedIndex = Properties.Settings.Default.VoiceSelectionIndex;

            nudSpeed.Value = Properties.Settings.Default.VoiceSpeed;

            nudVolume.Value = Properties.Settings.Default.VoiceVolume;
        }

        private void cbVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VoiceSelectionIndex = cbVoices.SelectedIndex;
            Properties.Settings.Default.VoiceName = cbVoices.Text;
            Properties.Settings.Default.Save();
        }

        private void nudSpeed_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VoiceSpeed = nudSpeed.Value;
            Properties.Settings.Default.Save();
        }

        private void nudVolume_ValueChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.VoiceVolume = nudVolume.Value;
            Properties.Settings.Default.Save();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
