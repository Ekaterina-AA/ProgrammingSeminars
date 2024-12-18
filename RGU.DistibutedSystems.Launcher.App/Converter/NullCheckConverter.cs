using RGU.DistributedSystems.Launcher.App.Converter;
using RGU.DistributedSystems.WPF.MVVM.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGU.DistibutedSystems.Launcher.App.Converter
{
    public sealed class NullCheckConverter : ValueConverterBase<NullCheckConverter>
    {
        public override object? Convert(
            object? value,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            return value== null;
        }
            
    }
}
