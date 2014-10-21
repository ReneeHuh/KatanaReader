using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpeechLib;
namespace KatanaReader
{
    class SAPISpeech
    {
        //public SpVoice speech = new SpVoice();
        //public SpeechLib.ISpeechObjectTokens arryVoices;

        //public int Rate
        //{
        //    get { return speech.Rate; }
        //    set { speech.Rate = value; }
        //}

        //public int Volume
        //{
        //    get { return speech.Volume; }
        //    set { speech.Volume = value; }
        //}
        ////public int Pitch
        ////{
        ////    get { return speech.spv}
        ////}


        //public void Play(string x)
        //{
        //    if (speech.Status.RunningState != SpeechRunState.SRSEIsSpeaking)
        //    {
        //        speech.Speak(x, SpeechVoiceSpeakFlags.SVSFlagsAsync);
        //        //speech.Pause();
        //    }
        //    else
        //    {
        //        speech.Pause();
        //    }

            
        //}

        //public void Pause()
        //{
        //    if (speech.Status.RunningState == SpeechRunState.SRSEIsSpeaking)
        //    {
        //        speech.Pause();
        //    }
        //    else
        //    {
        //        speech.Resume();
        //    }
        //}
        //public void Resume()
        //{
        //    speech.Speak("", SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
        //}
        //public string[] GetVoices()
        //{
        //    //string[] arryVoices;
        //    //string[] arryVoicesNames;
        //    SpeechLib.ISpeechObjectTokens arryVoices = speech.GetVoices();
            
        //    string[] arryVoicesNames = new string[arryVoices.Count];
            
        //    for (int i = 0; i < arryVoices.Count - 1; i++)
        //    {
        //       arryVoicesNames[i] =  arryVoices.Item(i).GetDescription();
        //    }

        //    return arryVoicesNames;
        //}

        ////change voice 
        ////get status
        ////word event
        ////pitch

    }
}
