using System;
using System.ComponentModel;
using banditoth.MAUI.Multilanguage.Interfaces;
using Microsoft.Maui.Controls;

namespace banditoth.MAUI.Multilanguage
{
    public class TranslationBinder : BindableObject
    {
        private readonly ITranslator translator;

        public TranslationBinder(ITranslator translator)
        {
            this.translator = translator;
        }

        public string this[string text] => translator.GetTranslation(text);

        public void Invalidate()
        {
            Dispatcher.Dispatch(() =>
            {
                OnPropertyChanged(null);
            });
        }
    }
}

