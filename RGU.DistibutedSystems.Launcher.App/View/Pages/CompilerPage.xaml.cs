using System;
using System.Windows;
using System.Windows.Controls;
using DryIoc;

using RGU.DistibutedSystems.Launcher.App.ViewModel.Pages;

namespace RGU.DistibutedSystems.Launcher.App.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CompilerPage.xaml
    /// </summary>
    public partial class CompilerPage : Page
    {
        public CompilerPage()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<CompilerViewModel>();
            
        }
    }
}
