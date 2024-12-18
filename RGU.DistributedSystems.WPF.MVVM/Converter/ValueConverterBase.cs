using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Markup;

namespace RGU.DistributedSystems.WPF.MVVM.Converter
{
    public abstract class ValueConverterBase<TValueConverter>: MarkupExtension,
    IValueConverter
        where TValueConverter : new()
    {
        private static readonly Lazy<TValueConverter> _instance;

        static ValueConverterBase()
        {
            _instance = new Lazy<TValueConverter>(() => new TValueConverter());
        }

        public override object ProvideValue(
            IServiceProvider serviceProvider)
        {
            return _instance.Value;
        }
        public abstract object? Convert(
        object value,
        Type targetType,
        object? parameter,
        CultureInfo culture);

        /// <inheritdoc cref="IValueConverter.ConvertBack" />
        public virtual object ConvertBack(
            object? value,
            Type targetTypes,
            object? parameter,
            CultureInfo culture)
        {
            throw new NotSupportedException("Reverse conversion is not supported");
        }
    }
}
