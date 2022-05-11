using System;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace banditoth.MAUI.Multilanguage
{
    [ContentProperty(nameof(Key))]
    public class TranslationExtension : IMarkupExtension<BindingBase>
    {
        public TranslationExtension()
        {

        }

        public string Key { get; set; }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Key}]",
                Source = serviceProvider.GetService(typeof(TranslationBinder)),
            };
            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}

