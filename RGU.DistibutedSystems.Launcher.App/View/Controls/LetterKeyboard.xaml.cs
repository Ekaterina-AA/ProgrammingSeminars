using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DryIoc;
using RGU.DistibutedSystems.Launcher.App.View.Controls.ControlsViewModels;
using RGU.DistibutedSystems.Launcher.App.ViewModel.Pages;
using RGU.DistributedSystems.WPF.MVVM.ViewModel;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls
{
    public partial class LetterKeyboard : UserControl
    {
        #region constructor
        public LetterKeyboard()
        {
            InitializeComponent();
            DataContext = App.Container.Resolve<LetterKeyboardViewModel>();
        }
        #endregion

        #region properties_xaml.cs
        public static readonly DependencyProperty ClickOnLetterProperty = DependencyProperty.Register(nameof(ClickOnLetter), typeof(ICommand), typeof(LetterKeyboard), new PropertyMetadata(null));
        public static readonly DependencyProperty ClickOnCProperty = DependencyProperty.Register(nameof(ClickOnC), typeof(ICommand), typeof(LetterKeyboard), new PropertyMetadata(null));
        public static readonly DependencyProperty EnterButtonProperty = DependencyProperty.Register(nameof(EnterButton), typeof(ICommand), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty ChangeLanguageButtonProperty = DependencyProperty.Register(nameof(ChangeLanguageButton), typeof(ICommand), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty CapsLockButtonProperty = DependencyProperty.Register(nameof(CapsLockButton), typeof(ICommand), typeof(LetterKeyboard), new PropertyMetadata());

        public static readonly DependencyProperty StyleOfLetterButtonProperty = DependencyProperty.Register(nameof(StyleOfLetterButton), typeof(Style), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty StyleOfCButtonProperty = DependencyProperty.Register(nameof(StyleOfCButton), typeof(Style), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty StyleOfCapsLockButtonProperty = DependencyProperty.Register(nameof(StyleOfCapsLockButton), typeof(Style), typeof(LetterKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty StyleOfEnterButtonProperty = DependencyProperty.Register(nameof(StyleOfEnterButton), typeof(Style), typeof(LetterKeyboard), new PropertyMetadata());       
        #endregion

        #region getset_xaml.cs


        public ICommand ChangeLanguageButton
        {
            get => (ICommand)GetValue(ChangeLanguageButtonProperty);
            set =>SetValue(ChangeLanguageButtonProperty, value);
        }
        public ICommand CapsLockButton
        {
            get => (ICommand)GetValue(CapsLockButtonProperty);
            set => SetValue(CapsLockButtonProperty, value);
        }
        public ICommand EnterButton
        {
            get => (ICommand)GetValue(EnterButtonProperty);
            set => SetValue(EnterButtonProperty, value);
        }
        public Style StyleOfLetterButton
        {
            get => (Style)GetValue(StyleOfLetterButtonProperty);
            set => SetValue(StyleOfLetterButtonProperty, value);
        }

        public Style StyleOfCButton
        {
            get => (Style)GetValue(StyleOfCButtonProperty);
            set => SetValue(StyleOfCButtonProperty, value);
        }
        public Style StyleOfEnterButton
        {
            get => (Style)GetValue(StyleOfEnterButtonProperty);
            set => SetValue(StyleOfEnterButtonProperty, value);
        }
        public Style StyleOfCapsLockButton
        {
            get => (Style)GetValue(StyleOfCapsLockButtonProperty);
            set => SetValue(StyleOfCapsLockButtonProperty, value);
        }

        public ICommand ClickOnLetter
        {
            get => (ICommand)GetValue(ClickOnLetterProperty);
            set => SetValue(ClickOnLetterProperty, value);
        }

        public ICommand ClickOnC
        {
            get => (ICommand)GetValue(ClickOnCProperty);
            set => SetValue(ClickOnCProperty, value);
        }

        #endregion

    }
}
