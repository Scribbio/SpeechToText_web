using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Speech.Recognition;
using System.Web;
using SpeechToTextPOC;

namespace SpeechToTextPOC
{
    class Recognizer
    {
        private readonly string _fileName;
        private readonly AsyncOperation _operation;
        private volatile RecognitionResult _result;
        private string language;

        public Recognizer(string language)
        {
            _operation = AsyncOperationManager.CreateOperation(null);
           
            _result = null;
            this.language = language;

            var worker = new Action(Run);
            worker.BeginInvoke(delegate (IAsyncResult result) {
                worker.EndInvoke(result);
            }, null);

        }

        private void Run()
        {
            try
            {
                SpeechRecognitionEngine engine = new SpeechRecognitionEngine(new System.Globalization.CultureInfo(language));
                //engine.SetInputToWaveFile(_fileName);
                engine.SetInputToDefaultAudioDevice();
                engine.LoadGrammar(new DictationGrammar());
                engine.BabbleTimeout = TimeSpan.FromSeconds(3.0);
                engine.EndSilenceTimeout = TimeSpan.FromSeconds(3.0);
                engine.EndSilenceTimeoutAmbiguous = TimeSpan.FromSeconds(1.0);
                engine.InitialSilenceTimeout = TimeSpan.FromSeconds(3.0);
                _result = engine.Recognize();
            }

            //Once the recording is done, _operation empties recorded speech
            finally
            {
                _operation.PostOperationCompleted(delegate {
                    RaiseCompleted();
                }, null);
            }
        }

        public RecognitionResult Result
        {
            get { return _result; }
        }

        public event EventHandler Completed;


        //Empties the EventArgs
        protected virtual void OnCompleted(EventArgs e)
        {
            if (Completed != null)
                Completed(this, e);
        }

        private void RaiseCompleted()
        {
            OnCompleted(EventArgs.Empty);
        }
    }
}