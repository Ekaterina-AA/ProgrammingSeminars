using RGU.DistibutedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGU.DistributedSystems.WPF.MVVM.DialogAware
{
    public sealed class DialogAwareParameters
    {
        private readonly Dictionary<string, object?> _parameters;
        private readonly Type _dialogViewModelType;

        private DialogAwareParameters(
            Dictionary<string, object?> parameters,
            Type dialogViewModelType)
        {
            _parameters = parameters ?? throw new ArgumentNullException(nameof(parameters));
            _dialogViewModelType = dialogViewModelType ?? throw new ArgumentNullException(nameof(dialogViewModelType));
        }

        public Type DialogType =>
            _dialogViewModelType;

        public object? this[
            string parameterName] =>
                _parameters[parameterName];

        public sealed class Builder
        {

            private readonly Dictionary<string, object?> _parameters;
            private Type _dialogViewModelType;

            private Builder()
            {
                _parameters = new Dictionary<string, object?>();
            }

            public static Builder Create()
            {
                return new Builder();
            }

            public Builder ForDialogType<TViewModel>()
                where TViewModel: DialogViewModelBase
            {
                _dialogViewModelType = typeof(TViewModel);

                return this;
            }

            public Builder AddParameter(
                string name,
                object? value)
            {
                _parameters[name] = value;

                return this;
            }

            public DialogAwareParameters Build()
            {
                return new DialogAwareParameters(new Dictionary<string, object?>(_parameters), _dialogViewModelType); 
            }

        }
    }
}
