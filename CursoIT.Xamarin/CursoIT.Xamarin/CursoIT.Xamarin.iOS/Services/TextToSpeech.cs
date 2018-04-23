using AVFoundation;
using CursoIT.Xamarin.Interfaces;
using CursoIT.Xamarin.iOS.Services;
using Xamarin.Forms; 

[assembly: Dependency(typeof(TextToSpeech))]
namespace CursoIT.Xamarin.iOS.Services
{
    class TextToSpeech : ITextToSpeech
    {

        public void Speak(string text)
        {
            var speechSynthesizer = new AVSpeechSynthesizer();
            var speechUtterance = new AVSpeechUtterance(text)
            {
                Rate = AVSpeechUtterance.MaximumSpeechRate / 4,
                Voice = AVSpeechSynthesisVoice.FromLanguage("en-US"),
                Volume = 0.5f,
                PitchMultiplier = 1.0f
            };

            speechSynthesizer.SpeakUtterance(speechUtterance);
        }
    }
}