using System;
using System.Collections.Generic;
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
using static RGU.DistibutedSystems.Launcher.App.View.Controls.MessageDialog;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls
{
    /// <summary>
    /// Логика взаимодействия для MessageDialog.xaml
    /// </summary>
    public partial class MessageDialog : UserControl
    {
        #region constructor
        public MessageDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region properties
        public static readonly DependencyProperty DialogCornerRadiusProperty = DependencyProperty.Register(nameof(DialogCornerRadius), typeof(CornerRadius), typeof(MessageDialog), new PropertyMetadata(new CornerRadius(0.0)));
        public static readonly DependencyProperty DialogOpacityProperty = DependencyProperty.Register(nameof(DialogOpacity), typeof(double), typeof(MessageDialog), new PropertyMetadata(0.4));
        public static readonly DependencyProperty DialogClickCommandProperty = DependencyProperty.Register(nameof(DialogClickCommand), typeof(ICommand), typeof(MessageDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty DialogTypeProperty = DependencyProperty.Register(nameof(DialogType), typeof(DialogTypes), typeof(MessageDialog), new PropertyMetadata(DialogTypes.NoOptions, OnDialogTypeChanged));
        public static readonly DependencyProperty ContentFontSizeProperty = DependencyProperty.Register(nameof(ContentFontSize), typeof(int), typeof(MessageDialog), new PropertyMetadata(22));
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(nameof(Text), typeof(string), typeof(MessageDialog), new PropertyMetadata("Wait,please..."));
        public static readonly DependencyProperty ScrollColorProperty = DependencyProperty.Register(nameof(ScrollColor), typeof(Brush), typeof(MessageDialog), new PropertyMetadata(Brushes.Red));
        public static DependencyProperty IsOkVisibleProperty = DependencyProperty.Register(nameof(IsOkVisible), typeof(Visibility), typeof(MessageDialog), new PropertyMetadata(Visibility.Hidden));
        public static DependencyProperty IsYesVisibleProperty = DependencyProperty.Register(nameof(IsYesVisible), typeof(Visibility), typeof(MessageDialog), new PropertyMetadata(Visibility.Hidden));
        public static DependencyProperty IsCancelVisibleProperty = DependencyProperty.Register(nameof(IsCancelVisible), typeof(Visibility), typeof(MessageDialog), new PropertyMetadata(Visibility.Hidden));
        public static DependencyProperty IsNoVisibleProperty = DependencyProperty.Register(nameof(IsNoVisible), typeof(Visibility), typeof(MessageDialog), new PropertyMetadata(Visibility.Hidden));
        public static readonly DependencyProperty OkClickCommandProperty = DependencyProperty.Register(nameof(OkClickCommand), typeof(ICommand), typeof(MessageDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty YesClickCommandProperty = DependencyProperty.Register(nameof(YesClickCommand), typeof(ICommand), typeof(MessageDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty NoClickCommandProperty = DependencyProperty.Register(nameof(NoClickCommand), typeof(ICommand), typeof(MessageDialog), new PropertyMetadata(null));
        public static readonly DependencyProperty CancelClickCommandProperty = DependencyProperty.Register(nameof(CancelClickCommand), typeof(ICommand), typeof(MessageDialog), new PropertyMetadata(null));

        #endregion
        #region OnDialogTypeChanged
        private static void OnDialogTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateButtonVisibility(d);
        }

        private static void UpdateButtonVisibility(DependencyObject obj)
        {
            var dialogType = (DialogTypes)obj.GetValue(DialogTypeProperty);
            var messageDlg = (MessageDialog)obj;

            messageDlg.IsOkVisible = dialogType == DialogTypes.Ok || dialogType == DialogTypes.OkCancel ? Visibility.Visible : Visibility.Collapsed;
            messageDlg.IsYesVisible = dialogType == DialogTypes.YesNo ? Visibility.Visible : Visibility.Collapsed;
            messageDlg.IsCancelVisible = dialogType == DialogTypes.OkCancel ? Visibility.Visible : Visibility.Collapsed;
            messageDlg.IsNoVisible = dialogType == DialogTypes.YesNo ? Visibility.Visible : Visibility.Collapsed;
        }

        #endregion

        #region getset

        public ICommand OkClickCommand
        {
            get => (ICommand)GetValue(OkClickCommandProperty);
            set => SetValue(OkClickCommandProperty, value);
        }
        public ICommand NoClickCommand
        {
            get => (ICommand)GetValue(NoClickCommandProperty);
            set => SetValue(NoClickCommandProperty, value);
        }
        public ICommand YesClickCommand
        {
            get => (ICommand)GetValue(YesClickCommandProperty);
            set => SetValue(YesClickCommandProperty, value);
        }
        public ICommand CancelClickCommand
        {
            get => (ICommand)GetValue(CancelClickCommandProperty);
            set => SetValue(CancelClickCommandProperty, value);
        }
        public Visibility IsYesVisible
        {
            get => (Visibility)GetValue(IsYesVisibleProperty);
            set => SetValue(IsYesVisibleProperty, value);
        }
        public Visibility IsNoVisible
        {
            get => (Visibility)GetValue(IsNoVisibleProperty);
            set => SetValue(IsNoVisibleProperty, value);
        }
        public Visibility IsCancelVisible
        {
            get => (Visibility)GetValue(IsCancelVisibleProperty);
            set => SetValue(IsCancelVisibleProperty, value);
        }
        public Visibility IsOkVisible
        {
            get => (Visibility)GetValue(IsOkVisibleProperty);
            set => SetValue(IsOkVisibleProperty, value);
        }
        public CornerRadius DialogCornerRadius
        {
            get =>(CornerRadius)GetValue(DialogCornerRadiusProperty);
            set =>SetValue(DialogCornerRadiusProperty, value);
        }

        public Brush ScrollColor
        {
            get => (Brush)GetValue(ScrollColorProperty);
            set => SetValue(ScrollColorProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public DialogTypes DialogType
        {
            get => (DialogTypes)GetValue(DialogTypeProperty);
            set => SetValue(DialogTypeProperty, value);
        }
        public int ContentFontSize
        {
            get => (int)GetValue(ContentFontSizeProperty);
            set => SetValue(ContentFontSizeProperty, value);
        }

        public double DialogOpacity
        {
            get => (double)GetValue(DialogOpacityProperty);
            set => SetValue(DialogOpacityProperty, value);
        }

        public ICommand DialogClickCommand
        {
            get => (ICommand)GetValue(DialogClickCommandProperty);  
            set => SetValue(DialogClickCommandProperty, value);
        }
        #endregion

        #region commands
        #endregion

        #region DialogTypes
        public enum DialogTypes
        {
            Ok,
            YesNo,
            OkCancel,
            NoOptions
        }
        #endregion
    }
}
