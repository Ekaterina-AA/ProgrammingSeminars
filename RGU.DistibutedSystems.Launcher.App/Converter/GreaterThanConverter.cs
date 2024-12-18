using RGU.DistributedSystems.WPF.MVVM.Converter;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGU.DistibutedSystems.Launcher.App.Converter
{
    
    public sealed class GreaterThanConverter: MultiValueConverterBase<GreaterThanConverter>
    {
        #region Nested
        public enum Operators
        {
            LessThan,
            LessThanOrEqual,
            GreaterThanOrEqual,
            GreaterThan,
        }

        #endregion
        #region RGU.DistributedSystems.WPF.MVVM.MultiValueConverterBase<ArithmeticConverter> overrides

        public override object? Convert(
            object?[] values,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            if (values.Length != 2)
            {
                throw new ArgumentException("Invalid count of values!");
            }

            ArgumentNullException.ThrowIfNull(parameter);

            if (!Enum.IsDefined(typeof(Operators), parameter))
            {
                throw new ArgumentException("Invalid count of values!");
            }

            var @operator = (Operators)parameter;
            dynamic leftOperand = values[0];
            dynamic rightOperand = values[1];

            switch (@operator)
            {
                case Operators.LessThan:
                    return leftOperand < rightOperand;
                case Operators.LessThanOrEqual:
                    return leftOperand <= rightOperand;
                case Operators.GreaterThan:
                    return leftOperand > rightOperand;
                case Operators.GreaterThanOrEqual:
                    return leftOperand >= rightOperand;
                default:
                    throw new ArgumentOutOfRangeException(nameof(parameter));
            }
        }
            #endregion
    }
}
