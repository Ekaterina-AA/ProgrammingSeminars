using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;
using RGU.DistibutedSystems.WPF.MVVM.DialogAware;

namespace RGU.DistributedSystems.WPF.MVVM.DialogAware
{
    public sealed class DialogAwareContext:
        IDialogAware
    {


        private readonly Dictionary<Type, Window> _registredDialogs;

        private DialogAwareContext()
        {
            _registredDialogs = new Dictionary<Type, Window>();
        }

        public sealed class Builder
        {
            


        }

        public bool ShowDialog(
            DialogAwareParameters dialogParameters)
        {
            if (!_registredDialogs.TryGetValue(dialogParameters.DialogType, out var dialogControl))
            {
                throw new ArgumentOutOfRangeException(nameof(dialogParameters), "Dialog type was not registred!");
            }

            // var dialog = new Window
            // {
            //     DataContext = viewModel,
            //     Width = 300,
            //     Height = 200,
            //     Title = "Dialog",
            //     Content = new TextBlock
            //     {
            //         Text = Message
            //     },
            //     WindowStartupLocation = WindowStartupLocation.CenterScreen
            // };
            // 
            // dialog.Closing += (sender, e) =>
            // {
            //     DialogResult = dialog.DialogResult ?? false;
            // };

            var dialogControlViewModel = dialogControl.DataContext as DialogViewModelBase;
            if (dialogControlViewModel is null)
            {
                throw new ArgumentException(nameof(dialogParameters), "Invalid dialog view model type, or view model does not exist");
            }
            dialogControlViewModel.Parameters = dialogParameters;
            return dialogControl.ShowDialog() ?? false;
        }

    }
}
