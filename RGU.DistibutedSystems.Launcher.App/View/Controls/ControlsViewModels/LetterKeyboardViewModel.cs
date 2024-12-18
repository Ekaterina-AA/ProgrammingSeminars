using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using RGU.DistributedSystems.WPF.MVVM.Command;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls.ControlsViewModels
{
    class LetterKeyboardViewModel: ViewModelBase
    {
        #region constructor
        public LetterKeyboardViewModel() 
        {
            CapsLockOnProp = false;

            #region alphabet

            //CommandsLatin = new ObservableCollection<string>("abcdefghijklmnopqrstuvwxyz ".Select(char.ToString));

            CommandsLatin = new ObservableCollection<string>
            {
              "a",
              "b",
              "c",
              "d",
              "e",
              "f",
              "g",
              "h",
              "i",
              "j",
              "k",
              "l",
              "m",
              "n",
              "o",
              "p",
              "q",
              "r",
              "s",
              "t",
              "u",
              "v",
              "w",
              "x",
              "y",
              "z",
              " "
            };
           
            CommandsRussian = new ObservableCollection<string>
            {
               "а",
               "б",
               "в",
               "г",
               "д",
               "е",
               "ё",
               "ж",
               "з",
               "и",
               "й",
               "к",
               "л",
               "м",
               "н",
               "о",
               "п",
               "р",
               "с",
               "т",
               "у",
               "ф",
               "х",
               "ц",
               "ч",
               "ш",
               "щ",
               "ъ",
               "ы",
               "ь",
               "э",
               "ю",
               "я",
               " "
            };
            #endregion

            _clickOnChangeLanguageCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnChangeLanguageCommandAction()));
            _clickOnCaplsLockCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnCaplsLockCommandAction()));
            _clickOnLetterCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ClickOnLetterCommandAction((string)prop!)));
            _clickOnCCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnCCommandAction()));
            _clickOnEnterCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnEnterCommandAction()));
            Commands = CommandsLatin;
            
            
            LetterKeyboardString = "";
        }
        #endregion

        #region fields
        private readonly Lazy<ICommand> _clickOnChangeLanguageCommand;
        private readonly Lazy<ICommand> _clickOnCaplsLockCommand;
        private bool _capsLockOn;

        private ObservableCollection<string> _commands;
        private ObservableCollection<string> _commandsLatin;
        private ObservableCollection<string> _commandsRussian;
        private readonly Lazy<ICommand> _clickOnLetterCommand;
        private readonly Lazy<ICommand> _clickOnCCommand;
        private readonly Lazy<ICommand> _clickOnEnterCommand;

        private Style _capsLockStyle;

        private string _letterKeyboardString;
#       endregion

        #region Properties
        public ICommand ClickOnCaplsLockCommand
            => _clickOnCaplsLockCommand.Value;
        public ICommand ClickOnEnterCommand
            => _clickOnEnterCommand.Value;

        public ICommand ClickOnChangeLanguageCommand
            => _clickOnChangeLanguageCommand.Value;
        public ICommand ClickOnLetterCommand =>
       _clickOnLetterCommand.Value;

        public ICommand ClickOnCCommand =>
           _clickOnCCommand.Value;

        public string LetterKeyboardString
        {
            get =>
                _letterKeyboardString;

            private set
            {
                _letterKeyboardString = value;
                RaisePropertyChanged(nameof(LetterKeyboardString));
            }
        }

        public bool CapsLockOnProp
        {
            get => _capsLockOn;
            set
            {
                _capsLockOn = value;
                RaisePropertiesChanged(nameof(CapsLockOnProp));
            }
        }
        public Style CapsLockStyle
        {
            get => _capsLockStyle;
            set
            {
                _capsLockStyle = value;
                RaisePropertiesChanged(nameof(CapsLockStyle));
            }
        }

        public ObservableCollection<string> CommandsRussian
        {
            get => _commandsRussian;
            set
        {
                _commandsRussian = value;
                RaisePropertyChanged(nameof(CommandsRussian));
            }
        }

        public ObservableCollection<string> CommandsLatin
        {
            get => _commandsLatin;
            set
            {
                _commandsLatin = value;
                RaisePropertyChanged(nameof(CommandsLatin));
            }
        }

        public ObservableCollection<string> Commands
        {
            get => _commands;
            set
            {
                _commands = value;
                RaisePropertyChanged(nameof(Commands));
            }
        }
        #endregion

        #region commands

        private void ClickOnChangeLanguageCommandAction()
        {
            Commands = CommandsLatin == Commands ? CommandsRussian : CommandsLatin;
        }

        private void ClickOnCaplsLockCommandAction()
        {
            CapsLockOnProp = !CapsLockOnProp;
        }

        private void ClickOnLetterCommandAction([CallerMemberName] string prop = "")
        {
            LetterKeyboardString += prop;
            System.Windows.MessageBox.Show(LetterKeyboardString);
        }

        private void ClickOnCCommandAction()
        {
            if (LetterKeyboardString.Length > 0)
                LetterKeyboardString = LetterKeyboardString.Remove(LetterKeyboardString.Length - 1);
            System.Windows.MessageBox.Show(LetterKeyboardString);
        }

        private void ClickOnEnterCommandAction()
        {
           if(System.Windows.MessageBox.Show("Enter?", "", MessageBoxButton.YesNo) == MessageBoxResult.No) 
           {
                MessageBox.Show("Ну и ладно");
           }
        }
        #endregion


    }
}
