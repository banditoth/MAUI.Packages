using System;
using Microsoft.Maui;
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
                // https://github.com/dotnet/maui/issues/8824 - Xaml MarkupExtensios are not receiving all services from service collection
                Source = MAUIServiceProviderWorkaround.TranslatorBinder, // TODO: Get instance from serviceprovider
            };
            return binding;
        }

        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }
    }
}

