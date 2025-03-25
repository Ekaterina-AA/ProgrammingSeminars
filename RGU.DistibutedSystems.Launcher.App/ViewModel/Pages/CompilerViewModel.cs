using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Threading;
using RGU.DistibutedSystems.Launcher.App.Utils;
using RGU.DistibutedSystems.Launcher.App.ViewModel.Dialogs;
using RGU.DistributedSystems.WPF.MVVM.Command;
using RGU.DistributedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.Navigation;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;
using static RGU.DistibutedSystems.Launcher.App.ViewModel.Pages.TargetToNavigatePageViewModel;

namespace RGU.DistibutedSystems.Launcher.App.ViewModel.Pages
{

    internal class CompilerViewModel: PageViewModelBase
    {

        #region Fields

        private readonly Lazy<ICommand> _navigateBackCommand;
        private readonly IDialogAware _dialogAware;
        private readonly Lazy<ICommand> _clickOnNumberCommand;
        private readonly Lazy<ICommand> _clickOnCCommand;
        private readonly Lazy<ICommand> _clickOnPlayCommand;
        private readonly Lazy<ICommand> _clickOnFolderCommand;

        private string _compilerCommand;


        #endregion

        #region Constructors

        public CompilerViewModel(
            NavigationManager navigationManager,
            IDialogAware dialogAware) :
                base(navigationManager)
        {
            _dialogAware = dialogAware ?? throw new ArgumentNullException(nameof(dialogAware));
            _navigateBackCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NavigateBack()));
            _clickOnNumberCommand = new Lazy<ICommand>(() => new RelayCommand((prop) => ClickOnNumberActionCompiler((string)prop!)));
            _clickOnCCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnCActionCompiler()));
            _clickOnPlayCommand = new Lazy<ICommand>(() => new RelayCommand(((prop) => ClickOnPlayActionCompiler((string)prop!)));
            _clickOnFolderCommand = new Lazy<ICommand>(() => new RelayCommand(_ => ClickOnFolderActionCompiler()));

            CompilerCommand = "";
        }

        #endregion

        #region Properties

        public string CompilerCommand
        { 
            get => _compilerCommand;
            set
            {
                _compilerCommand = value;
                RaisePropertiesChanged(nameof(CompilerCommand));
            }
        }
        public ICommand NavigateBackCommand =>
            _navigateBackCommand.Value;

        public ICommand ClickOnNumberAction =>
            _clickOnNumberCommand.Value;

        public ICommand ClickOnCAction =>
            _clickOnCCommand.Value;
        public ICommand ClickOnPlayAction =>
            _clickOnPlayCommand.Value;

        public ICommand ClickOnFolderAction =>
            _clickOnFolderCommand.Value;


        #endregion

        #region Methods
        private void NavigateBack()
        {
            NavigationManager.Navigate(NavigationContext.Builder
                .Create()
                .From<CompilerViewModel>()
                .To<HelloWPFPageViewModel>()
                .Build());
        }

        private void ClickOnCActionCompiler()
        {
            if (CompilerCommand.Length > 0)
                CompilerCommand = CompilerCommand.Remove(CompilerCommand.Length - 1);
        }

        private void ClickOnNumberActionCompiler([CallerMemberName] string prop = "")
        {
            CompilerCommand += prop;
        }

        private void ClickOnPlayActionCompiler([CallerMemberName] string prop = "")
        {
            if (prop.Length != 37)
            {
                System.Windows.MessageBox.Show("wrong amount of symbols, try again");
                throw new ArgumentException("wrong amount of symbols");
            }

            string cleanedInput = prop.Replace("<", "").Replace(">", "").Replace(",", "");

            if (!Regex.IsMatch(cleanedInput, "^[01]+$"))
            {
                System.Windows.MessageBox.Show("wrong symbols, try again");
                throw new ArgumentException("wrong symbols");
            }

            int memoryStreamString =;


        }

        private void ClickOnFolderActionCompiler()
        {

        }
        #endregion
    }
}
