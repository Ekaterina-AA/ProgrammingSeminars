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

namespace RGU.DistibutedSystems.Launcher.App.View.Controls
{
    public partial class NumKeyboard : UserControl
    {
        #region nested
        public class CommandViewModel
        {
            public string _content { get; set; }
            public ICommand _command { get; set; }

            public CommandViewModel(string content, ICommand command)
            {
                _content = content;
                _command = command;
            }
        }
        public ObservableCollection<CommandViewModel> Commands { get; }
        #endregion
        public NumKeyboard()
        {
            InitializeComponent();
            Commands = new ObservableCollection<CommandViewModel>
            {
                new CommandViewModel("1", ClickOnNumber),
                new CommandViewModel("2", ClickOnNumber),
                new CommandViewModel("3", ClickOnNumber),
                new CommandViewModel("4", ClickOnNumber),
                new CommandViewModel("5", ClickOnNumber),
                new CommandViewModel("6", ClickOnNumber),
                new CommandViewModel("7", ClickOnNumber),
                new CommandViewModel("8", ClickOnNumber),
                new CommandViewModel("9", ClickOnNumber)
            };
        }

        #region properties
        public static readonly DependencyProperty ClickOnNumberProperty = DependencyProperty.Register(nameof(ClickOnNumber), typeof(ICommand), typeof(NumKeyboard), new PropertyMetadata(null));
        public static readonly DependencyProperty ClickOnCProperty = DependencyProperty.Register(nameof(ClickOnC), typeof(ICommand), typeof(NumKeyboard), new PropertyMetadata(null));
        public static readonly DependencyProperty StyleOfNumberButtonProperty = DependencyProperty.Register(nameof(StyleOfNumberButton), typeof(Style), typeof(NumKeyboard), new PropertyMetadata());
        public static readonly DependencyProperty StyleOfCButtonProperty = DependencyProperty.Register(nameof(StyleOfCButton), typeof(Style), typeof(NumKeyboard), new PropertyMetadata());

        #endregion

        #region getset

        public ICommand StyleOfNumberButton
        {
            get => (ICommand)GetValue(StyleOfNumberButtonProperty);
            set => SetValue(StyleOfNumberButtonProperty, value);
        }

        public ICommand StyleOfCButton
        {
            get => (ICommand)GetValue(StyleOfCButtonProperty);
            set => SetValue(StyleOfCButtonProperty, value);
        }

        public ICommand ClickOnNumber
        {
            get => (ICommand)GetValue(ClickOnNumberProperty);
            set => SetValue(ClickOnNumberProperty, value);
        }

        public ICommand ClickOnC
        {
            get => (ICommand)GetValue(ClickOnCProperty);
            set => SetValue(ClickOnCProperty, value);
        }

        #endregion

        #region commands
        #endregion
    }
}
