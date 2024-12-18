using RGU.DistributedSystems.UI.Attached;
using RGU.DistributedSystems.WPF.MVVM.Command;
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
using System.Windows.Shapes;

namespace RGU.DistibutedSystems.Launcher.App.View.Controls
{
    
    public partial class CustomDialogHost : UserControl
    {
        #region properties

        public static readonly DependencyProperty DialogCornerRadiusProperty = DependencyProperty.Register(nameof(DialogCornerRadius), typeof(CornerRadius), typeof(CustomDialogHost), new PropertyMetadata(new CornerRadius(0.0)));
        public static readonly DependencyProperty DialogOpacityProperty = DependencyProperty.Register("DialogOpacity", typeof(double), typeof(CustomDialogHost), new PropertyMetadata(0.4));
        public static readonly DependencyProperty DialogClickCommandProperty = DependencyProperty.Register("DialogClickCommand", typeof(ICommand), typeof(CustomDialogHost), new PropertyMetadata(null));
        public static readonly DependencyProperty CloseDialogCommandProperty = DependencyProperty.Register(nameof(CloseDialogCommand), typeof(ICommand), typeof(CustomDialogHost));
        #endregion

        #region constuctors

        public CustomDialogHost()
        {
            InitializeComponent();
        }
        
        #endregion

        #region get_set_props

        public ICommand CloseDialogCommand
        {
            get =>
                (ICommand)GetValue(CloseDialogCommandProperty);

            set =>
                SetValue(CloseDialogCommandProperty, value);
        }

        public CornerRadius DialogCornerRadius
        {
            get =>
                (CornerRadius)GetValue(DialogCornerRadiusProperty);

            set =>
                SetValue(DialogCornerRadiusProperty, value);
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


    }
}

