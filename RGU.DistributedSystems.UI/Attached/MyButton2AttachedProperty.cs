using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace RGU.DistributedSystems.UI.Attached;

public class MyButton2AttachedProperty: Button
{
    public static object GetScaleX(
        DependencyObject obj)
    {
        return obj.GetValue(ScaleXProperty);
    }

    public static void SetScaleX(
        DependencyObject obj,
        double value)
    {
        obj.SetValue(ScaleXProperty, value);
    }

    public static readonly DependencyProperty ScaleXProperty = DependencyProperty.RegisterAttached("ScaleX", typeof(double), typeof(MyButton2AttachedProperty), new PropertyMetadata(1.0));

    public static object GetScaleY(
        DependencyObject obj)
    {
        return obj.GetValue(ScaleYProperty);
    }

    public static void SetScaleY(
        DependencyObject obj,
        double value)
    {
        obj.SetValue(ScaleYProperty, value);
    }

    public static readonly DependencyProperty ScaleYProperty = DependencyProperty.RegisterAttached("ScaleY", typeof(double), typeof(MyButton2AttachedProperty), new PropertyMetadata(1.0));


    public static ImageSource GetImageSource(
        DependencyObject obj)
    {
        return (ImageSource)obj.GetValue(ImageSourceProperty);
    }

    public static void SetImageSource(
        DependencyObject obj,
        ImageSource value)
    {
        obj.SetValue(ImageSourceProperty, value);
    }

    public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.RegisterAttached("ImageSource", typeof(ImageSource), typeof(MyButton2AttachedProperty), new PropertyMetadata(null));

    public static Brush GetScrollColor(
        DependencyObject obj)
    {
        return (Brush)obj.GetValue(ScrollColorProperty);
    }

    public static void SetScrollColor(
        DependencyObject obj,
        Brush value)
    {
        obj.SetValue(ScrollColorProperty, value);
    }

    public static readonly DependencyProperty ScrollColorProperty = DependencyProperty.RegisterAttached("ScrollColor", typeof(Brush), typeof(MyButton2AttachedProperty), new PropertyMetadata(Brushes.Red));

}
