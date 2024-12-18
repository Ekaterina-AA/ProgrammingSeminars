using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Threading;
using RGU.DistibutedSystems.Launcher.App.Utils;
using RGU.DistibutedSystems.Launcher.App.ViewModel.Dialogs;
using RGU.DistributedSystems.WPF.MVVM.Command;
using RGU.DistributedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.Navigation;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RGU.DistibutedSystems.Launcher.App.ViewModel.Pages;

/// <summary>
/// 
/// </summary>
internal sealed class TargetToNavigatePageViewModel:
    PageViewModelBase
{
    
    #region Nested
    
    /// <summary>
    /// 
    /// </summary>
    public sealed class StringWrapperViewModel:
        ViewModelBase
    {

        private string _value;

        public StringWrapperViewModel(
            string value)
        {
            Value = value;
        }

        public string Value
        {
            get =>
                _value;

            private set
            {
                _value = value;
                RaisePropertyChanged(nameof(Value));
            }
        }
        
    }

    public sealed class ModifiableIntViewModel:
        ViewModelBase
    {

        private int _value;
        private readonly Lazy<ICommand> _incrementCommand;
        private readonly Lazy<ICommand> _decrementCommand;

        public ModifiableIntViewModel()
        {
            Value = 0;
            _incrementCommand = new Lazy<ICommand>(() => new RelayCommand(_ => Increment()));
            _decrementCommand = new Lazy<ICommand>(() => new RelayCommand(_ => Decrement()));
        }
        
        public int Value
        {
            get =>
                _value;

            private set
            {
                _value = value;
                RaisePropertyChanged(nameof(Value));
            }
        }

        public ICommand IncrementCommand =>
            _incrementCommand.Value;

        public ICommand DecrementCommand =>
            _decrementCommand.Value;

        private void Increment()
        {
            ++Value;
        }

        private void Decrement()
        {
            --Value;
        }

    }

    #endregion
    
    #region Fields
    
    /// <summary>
    /// 
    /// </summary>
    private readonly Lazy<ICommand> _navigateBackCommand;

    private readonly Lazy<ICommand> _addStringWrapperCommand;
    
    private readonly Lazy<ICommand> _addModifiableIntCommand;

    private readonly Lazy<ICommand> _closeDialogCommand;

    private readonly Lazy<ICommand> _okDialogCommand;
    private readonly Lazy<ICommand> _noDialogCommand;
    private readonly Lazy<ICommand> _yesDialogCommand;
    private readonly Lazy<ICommand> _cancelDialogCommand;

<<<<<<< HEAD
=======
    private readonly Lazy<ICommand> _clickOnNumberCommand;
    private readonly Lazy<ICommand> _clickOnCCommand;
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f

    private ObservableCollection<ViewModelBase> _valuesToDisplay;

    private ObservableCollection<string> _strings;
    
    private ObservableCollection<StringWrapperViewModel> _stringsWrappers;

    private int _valueToAdd;

    private int _bindMePlease;

    private readonly DispatcherTimer _radiusCoeffUpdater;

    private double _radiusCoeff;

<<<<<<< HEAD
    private readonly DialogAwareContext _dialogAwareContext;

=======
    private string _numericKeyboardString;
    
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f
    #endregion

    

    #region Constructors

    /// <summary>
    /// 
    /// </summary>
    /// <param name="navigationManager"></param>
    public TargetToNavigatePageViewModel(
        NavigationManager navigationManager,
        DialogAwareContext dialogAwareContext):
            base(navigationManager)
    {
        _dialogAwareContext = dialogAwareContext ?? throw new ArgumentNullException(nameof(dialogAwareContext));

        _valueToAdd = 0;

        _okDialogCommand = new Lazy<ICommand>(() => new RelayCommand(_ => OkDialogCommandAction()));
        _noDialogCommand = new Lazy<ICommand>(()=> new RelayCommand(_ => NoDialogCommandAction()));
        _yesDialogCommand = new Lazy<ICommand>(() => new RelayCommand(_ => YesDialogCommandAction()));
        _cancelDialogCommand = new Lazy<ICommand>(() => new RelayCommand(_ => CancelDialogCommandAction()));

<<<<<<< HEAD
        
=======
        _clickOnNumberCommand = new Lazy<ICommand>(() => new RelayCommand(ClickOnNumberCommandAction));
        _clickOnCCommand = new Lazy<ICommand>(() => new RelayCommand(_=>ClickOnCCommandAction()));
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f

        _navigateBackCommand = new Lazy<ICommand>(() => new RelayCommand(_ => NavigateBack()));

        _addStringWrapperCommand = new Lazy<ICommand>(() => new RelayCommand(_ => AddStringWrapper()));
        
        _addModifiableIntCommand = new Lazy<ICommand>(() => new RelayCommand(_ => AddModifiableInt()));

        _closeDialogCommand = new Lazy<ICommand>(() => new RelayCommand(x => CloseDialogCommandAction()));

        ValuesToDisplay = new ObservableCollection<ViewModelBase>();
        
        Strings = new ObservableCollection<string> { "16", "126", "1236", "12346", "123456" };
        
        StringsWrappers = new ObservableCollection<StringWrapperViewModel> { new StringWrapperViewModel("1"), new StringWrapperViewModel("12"), new StringWrapperViewModel("123"), new StringWrapperViewModel("1234"), new StringWrapperViewModel("12345") };

        //_bindMePleaseUpdater = new DispatcherTimer(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, (s, e) => ++BindMePlease, Dispatcher.CurrentDispatcher);

        BindMePlease = 6;

        RadiusCoeff = -0.15;
<<<<<<< HEAD
=======
        NumericKeyboardString = "";
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f
        _radiusCoeffUpdater = new DispatcherTimer(TimeSpan.FromMilliseconds(500), DispatcherPriority.Normal, (s, e) => RadiusCoeff += 0.01, Dispatcher.CurrentDispatcher);
        _radiusCoeffUpdater.Start();
    }

    #endregion

    #region Properties
<<<<<<< HEAD
=======
    public ICommand ClickOnNumberCommand =>
       _clickOnNumberCommand.Value;

    public ICommand ClickOnCCommand =>
       _clickOnCCommand.Value;
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f

    public ICommand OkDialogCommand =>
        _okDialogCommand.Value;

    public ICommand NoDialogCommand =>
        _noDialogCommand.Value;

    public ICommand YesDialogCommand =>
        _yesDialogCommand.Value;

    public ICommand CancelDialogCommand =>
        _cancelDialogCommand.Value;
    /// <summary>
    /// 
    /// </summary>
    public ICommand NavigateBackCommand =>
        _navigateBackCommand.Value;
    
    /// <summary>
    /// 
    /// </summary>
    public ICommand AddStringWrapperCommand =>
        _addStringWrapperCommand.Value;
    
    /// <summary>
    /// 
    /// </summary>
    public ICommand AddModifiableIntCommand =>
        _addModifiableIntCommand.Value;

    public ICommand CloseDialogCommand =>
        _closeDialogCommand.Value;

    /// <summary>
    /// 
    /// </summary>
    /// 

<<<<<<< HEAD
    
    
=======
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
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f

    public ObservableCollection<StringWrapperViewModel> StringsWrappers
    {
        get =>
            _stringsWrappers;

        private set
        {
            _stringsWrappers = value;
            RaisePropertyChanged(nameof(StringsWrappers));
        }
    }

    public ObservableCollection<string> Strings
    {
        get =>
            _strings;

        private set
        {
            _strings = value;
            RaisePropertyChanged(nameof(Strings));
        }
    }

    public ObservableCollection<ViewModelBase> ValuesToDisplay
    {
        get =>
            _valuesToDisplay;

        set
        {
            _valuesToDisplay = value;
            RaisePropertyChanged(nameof(ValuesToDisplay));
        }
    }

    public int BindMePlease
    {
        get =>
            _bindMePlease;

        set
        {
            _bindMePlease = value;
            RaisePropertyChanged(nameof(BindMePlease));
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    public double RadiusCoeff
    {
        get =>
            _radiusCoeff;

        private set
        {
            _radiusCoeff = value;
            RaisePropertyChanged(nameof(RadiusCoeff));
        }
    }


    #endregion

    #region Methods

    /// <summary>
    /// 
    /// </summary>
    private void NavigateBack()
    {
        NavigationManager.Navigate(NavigationContext.Builder
            .Create()
            .From<TargetToNavigatePageViewModel>()
            .To<HelloWPFPageViewModel>()
            .Build());
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void AddStringWrapper()
    {
        ++_valueToAdd;
        ValuesToDisplay.Add(new StringWrapperViewModel(_valueToAdd.ToString()));
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void AddModifiableInt()
    {
        ValuesToDisplay.Add(new ModifiableIntViewModel());
    }
<<<<<<< HEAD
=======

    /// <summary>
    /// 
    /// </summary>
    private void CloseDialogCommandAction()
    {
        System.Windows.MessageBox.Show("dialog closing initiated...");
    }

    private void OkDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked ok");
    }
    private void NoDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked no");
    }
    private void YesDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked yes");
    }
    private void CancelDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked cancel");
    }

    private void ClickOnNumberCommandAction(object number)
    {
        NumericKeyboardString += number;
        System.Windows.MessageBox.Show(NumericKeyboardString);
    }

    private void ClickOnCCommandAction()
    {
        if (NumericKeyboardString.Length > 0)
            NumericKeyboardString= NumericKeyboardString.Remove(NumericKeyboardString.Length -1 );
        System.Windows.MessageBox.Show(NumericKeyboardString);
    }

    #endregion
>>>>>>> 59e79b253c986baf7d84debc626f6b26bee8372f

    /// <summary>
    /// 
    /// </summary>
    private void CloseDialogCommandAction()
    {
        System.Windows.MessageBox.Show("dialog closing initiated...");
    }

    private void OkDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked ok");
    }
    private void NoDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked no");
    }
    private void YesDialogCommandAction()
    {
        System.Windows.MessageBox.Show("You clicked yes");
    }
    private void CancelDialogCommandAction()
    {
        if (_dialogAwareContext.ShowDialog(DialogAwareParameters.Builder.Create()
            .ForDialogType<MessageDialogViewModel>()
            .AddParameter(MessageDialogViewModel.Parameters.YesCommand, YesDialogCommand)
            .AddParameter(MessageDialogViewModel.Parameters.NoCommand, NoDialogCommand)
            .Build()))
        {
            // TODO
        }

        System.Windows.MessageBox.Show("You clicked cancel");
    }
    #endregion
}