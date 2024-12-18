using System.Windows;
using System.Windows.Navigation;
using DryIoc;
using RGU.DistibutedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.DialogAware;

namespace RGU.DistibutedSystems.Launcher.App.Utils;

/// <summary>
/// 
/// </summary>
internal sealed class NavigationManagerDialogAware:
    IDialogAware
{

    #region Fields

    private readonly Dictionary<Type, Func<Window>> _viewTypeToViewMappings;

    private readonly IResolver _resolver;

    #endregion

    #region Constructors

    public NavigationManagerDialogAware()
    {
        _viewTypeToViewMappings = new Dictionary<Type, Func<Window>>();
        _resolver = App.Container;
    }

    #endregion

    #region Methods

    public NavigationManagerDialogAware AddMapping<TView, TViewModel>()
        where TView :
            Window
        where TViewModel :
            DialogViewModelBase
    {
        _viewTypeToViewMappings.Add(typeof(TViewModel), () => (_resolver.Resolve(typeof(TView)) as Window)!);

        return this;
    }

    #endregion

    #region 

    public bool ShowDialog(
        DialogAwareParameters dialogParameters)
    {
        if (!_viewTypeToViewMappings.TryGetValue(dialogParameters.DialogType, out var dialogWindowFactory))
        {
            throw new ArgumentOutOfRangeException(nameof(dialogParameters), "Factory for dialog was not registred!");
        }

        var dialogControl = default(Window);
        var dialogControlViewModel = (dialogControl = dialogWindowFactory()).DataContext as DialogViewModelBase;
        if (dialogControlViewModel is null)
        {
            throw new ArgumentException(nameof(dialogParameters), "Invalid dialog view model type, or view model does not exist");
        }
        dialogControlViewModel.Parameters = dialogParameters;
        return dialogControl.ShowDialog() ?? false;
    }

    #endregion

}