using RGU.DistributedSystems.WPF.MVVM.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGU.DistibutedSystems.Launcher.App.Converter
{
    class EqualityConverter : MultiValueConverterBase<EqualityConverter>
    {
        public override object? Convert(
        object?[] values,
        Type targetType,
        object? parameter,
        CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values! Expected 2 values.");
            }
            dynamic leftOperand = values[0];
            dynamic rightOperand = values[1];
            return leftOperand==rightOperand ;

        }
    }
}
