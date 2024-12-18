using RGU.DistributedSystems.WPF.MVVM.DialogAware;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;

namespace RGU.DistibutedSystems.WPF.MVVM.DialogAware
{
    public abstract class DialogViewModelBase:
        ViewModelBase
    {

        protected DialogViewModelBase()
        {

        }

        private bool _dialogResult;

        public DialogAwareParameters Parameters
        {
            set
            {
                HandleParameters(value ?? throw new ArgumentNullException(nameof(value)));
            }
        }

        protected virtual void HandleParameters(
            DialogAwareParameters parameters)
        {

        }

        public bool DialogResult
        {
            get => _dialogResult;
            set
            {
                _dialogResult = value;
                RaisePropertyChanged(nameof(DialogResult));
            }
        }

    }
}
