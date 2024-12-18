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
    public sealed class BitwiseAndConverter: MultiValueConverterBase<BitwiseAndConverter>
    {

        #region Nested
        public enum Operators
        {
            Not,
            And,
            Or,
            Xor
        }

        #endregion

        #region RGU.DistributedSystems.WPF.MVVM.MultiValueConverterBase<ArithmeticConverter> overrides

        public override object? Convert(
            object?[] values,
            Type targetType,
            object? parameter,
            CultureInfo culture)
        {
            ArgumentNullException.ThrowIfNull(parameter);

            if (!Enum.IsDefined(typeof(Operators), parameter))
            {
                throw new ArgumentNullException();
            }

            var @operator = (Operators)parameter;
            if (values.Length == 1 && @operator == Operators.Not)
            {
                dynamic Operand = values[0];
                return !Operand;

            }
            else if (values.Length == 2)
            {
                dynamic leftOperand = values[0];
                dynamic rightOperand = values[1];

                switch (@operator)
                {
                    case Operators.And:
                        return leftOperand && rightOperand;
                    case Operators.Or:
                        return leftOperand || rightOperand;
                    case Operators.Xor:
                        return leftOperand ^ rightOperand;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(parameter));
                }
            }
            else
            {
                throw new ArgumentException("Invalid count of values!");
            }
        }
        #endregion
    }
}
