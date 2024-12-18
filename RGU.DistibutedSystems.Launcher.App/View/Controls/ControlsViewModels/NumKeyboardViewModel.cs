using RGU.DistributedSystems.WPF.MVVM.Command;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls.ControlsViewModels
{
    #region constructor
    class NumKeyboardViewModel : ViewModelBase
    {
        public NumKeyboardViewModel()
        {
            Commands = new ObservableCollection<string>
            {
                "1",
                "2",
                "3",
                "4",
                "5",
                "6",
                "7",
                "8",
                "9"
            };
            _clickOnNumberCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ClickOnNumberCommandAction((string)prop!)));
            _clickOnCCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnCCommandAction()));

        }

        #endregion

        #region fields
        private readonly Lazy<ICommand> _clickOnNumberCommand;
        private readonly Lazy<ICommand> _clickOnCCommand;
        private string _numericKeyboardString;
        private ObservableCollection<string> _commands;
        #endregion

        #region properties

        public ICommand ClickOnNumberCommand =>
       _clickOnNumberCommand.Value;

        public ICommand ClickOnCCommand =>
           _clickOnCCommand.Value;
        public ObservableCollection<string> Commands
        {
            get => _commands;
            set
            {
                _commands = value;
                RaisePropertyChanged(nameof(Commands));
            }
        }
        public string NumericKeyboardString
        {
            get =>
                _numericKeyboardString;

            private set
            {
                _numericKeyboardString = value;
                RaisePropertyChanged(nameof(NumericKeyboardString));
            }
        }
        #endregion

        #region commands
        private void ClickOnNumberCommandAction([CallerMemberName] string prop = "")
        {
            NumericKeyboardString += prop;
            System.Windows.MessageBox.Show(NumericKeyboardString);
        }

        private void ClickOnCCommandAction()
        {
            if (NumericKeyboardString.Length > 0)
                NumericKeyboardString = NumericKeyboardString.Remove(NumericKeyboardString.Length - 1);
            System.Windows.MessageBox.Show(NumericKeyboardString);
        }
        #endregion
    }


}
