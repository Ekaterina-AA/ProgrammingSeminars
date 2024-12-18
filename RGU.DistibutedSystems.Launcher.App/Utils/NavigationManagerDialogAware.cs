using System.Windows;
using System.Windows.Navigation;
using DryIoc;
using RGU.DistibutedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.DialogAware;

namespace RGU.DistibutedSystems.Launcher.App.Utils;

/// <summary>
/// 
/// </summary>
internal sealed class NavigationManagerDialogAware
{

    #region Fields
    private NavigationService? _navigationService;

    private readonly Dictionary<Type, Window> _viewTypeToViewMappings;

    private readonly IResolver _resolver;

    #endregion

    #region Constructors

    public NavigationManagerDialogAware()
    {
        _viewTypeToViewMappings = new Dictionary<Type, Window>();
        _resolver = App.Container;
    }

    #endregion

    #region Properties

    public NavigationService NavigationService
    {
        set
        {
            if (_navigationService is not null)
            {
                throw new InvalidOperationException("Navigation service already set to the instance of navigation manager");
            }

            _navigationService = value;
        }
    }

    #endregion

    #region Methods
    public NavigationManagerDialogAware AddMapping<TView, TViewModel>()
        where TView :
            Window
        where TViewModel :
            DialogViewModelBase
    {
        _viewTypeToViewMappings.Add(typeof(TViewModel), (_resolver.Resolve(typeof(TView)) as Window)!);

        return this;
    }

    #endregion

}