using DryIoc;
using System.Windows;

using RGU.DistibutedSystems.Launcher.App.ViewModel.Dialogs;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls.Dialogs
{
    /// <summary>
    /// Логика взаимодействия для MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : Window
    {
        public MessageDialog()
        {
            InitializeComponent();

            DataContext = App.Container.Resolve<MessageDialogViewModel>();
        }
    }
}
