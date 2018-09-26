using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using CursoIT.Xamarin.Droid.Services;
using CursoIT.Xamarin.Interfaces;
using Xamarin.Forms;
using DroidTts = Android.Speech.Tts;

[assembly: Xamarin.Forms.Dependency(typeof(TextToSpeech))]
namespace CursoIT.Xamarin.Droid.Services
{
    class TextToSpeech : Java.Lang.Object, ITextToSpeech, DroidTts.TextToSpeech.IOnInitListener
    {
        DroidTts.TextToSpeech speaker;
        string toSpeak;
        public void Speak(string text)
        {
            toSpeak = text;
            if (speaker == null)
            {
                MainActivity context = (MainActivity)Forms.Context;
                speaker = new DroidTts.TextToSpeech(context, this);
            }
            else
            {
                speaker.Speak(toSpeak, DroidTts.QueueMode.Flush, null, null);
            }
        }
        public void OnInit(DroidTts.OperationResult status)
        {
            if (status.Equals(DroidTts.OperationResult.Success))
            {
                speaker.Speak(toSpeak, DroidTts.QueueMode.Flush, null, null);
            }
        }
    }
}