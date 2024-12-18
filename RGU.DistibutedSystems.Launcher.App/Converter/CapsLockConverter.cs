using RGU.DistributedSystems.WPF.MVVM.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup.Localizer;


namespace RGU.DistibutedSystems.Launcher.App.Converter
{
    public sealed class CapsLockConverter: MultiValueConverterBase<CapsLockConverter>
    {

        #region RGU.DistributedSystems.WPF.MVVM.MultiValueConverterBase<CapsLockConverter> overrides

        public override object? Convert(
        object?[] values,
        Type targetType,
        object? parameter,
        CultureInfo culture)
        {
            // Проверяем количество значений
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values! Expected 2 values.");
            }
            bool operand = (bool)values[0];
            string letter = values[1].ToString();

            if (operand == true) return letter.ToUpper();
            else return letter.ToLower();
            
        }
        #endregion
    }
}
