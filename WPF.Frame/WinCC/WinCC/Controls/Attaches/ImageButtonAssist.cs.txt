using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WinCC.Controls.Attaches
{
    public class ImageButtonAssist
    {


        public static string GetImageSource(DependencyObject obj)
        {
            return (string)obj.GetValue(ImageSourceProperty);
        }

        public static void SetImageSource(DependencyObject obj, string value)
        {
            obj.SetValue(ImageSourceProperty, value);
        }

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.RegisterAttached("ImageSource", typeof(string), typeof(ImageButtonAssist));






        public static int GetImageWidth(DependencyObject obj)
        {
            return (int)obj.GetValue(ImageWidthProperty);
        }

        public static void SetImageWidth(DependencyObject obj, int value)
        {
            obj.SetValue(ImageWidthProperty, value);
        }

        // Using a DependencyProperty as the backing store for ImageWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageWidthProperty =
            DependencyProperty.RegisterAttached("ImageWidth", typeof(int), typeof(ImageButtonAssist), new PropertyMetadata(12));




        public static int GetImageHeight(DependencyObject obj)
        {
            return (int)obj.GetValue(ImageHeightProperty);
        }

        public static void SetImageHeight(DependencyObject obj, int value)
        {
            obj.SetValue(ImageHeightProperty, value);
        }

        // Using a DependencyProperty as the backing store for ImageHeight.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageHeightProperty =
            DependencyProperty.RegisterAttached("ImageHeight", typeof(int), typeof(ImageButtonAssist), new PropertyMetadata(12));

    }
}
