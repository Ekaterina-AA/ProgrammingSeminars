using RGU.DistibutedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.DialogAware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RGU.DistibutedSystems.Launcher.App.ViewModel.Dialogs
{
    internal sealed class MessageDialogViewModel:
        DialogViewModelBase
    {

        private ICommand _yesCommand;

        public static class Parameters
        {

            public const string YesCommand = nameof(YesCommand);

            public const string NoCommand = nameof(NoCommand);

        }

        public ICommand YesCommand
        {
            get =>
                _yesCommand;

            set
            {
                _yesCommand = value ?? throw new ArgumentNullException(nameof(value));
                RaisePropertyChanged(nameof(YesCommand));
            }
        }

        protected override void HandleParameters(
            DialogAwareParameters parameters)
        {
            YesCommand = (parameters[Parameters.YesCommand] as ICommand);
        }
    }
}
