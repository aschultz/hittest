using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HitTesting
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();


            RegisterEvents(RootGrid);
            RegisterEvents(A);
            RegisterEvents(AA);
            RegisterEvents(B);
            RegisterEvents(BB);
        }

        void RegisterEvents(UIElement element)
        {
            element.PointerEntered += OnPointerEntered;
            element.PointerExited += OnPointerExited;
        }

        private void OnPointerEntered(object sender, PointerRoutedEventArgs e)
        {
            var elem = sender as FrameworkElement;
            var source = e.OriginalSource as FrameworkElement;

            Debug.WriteLine($"PointerEntered - Sender: {elem?.Name, -20} - Source: {source?.Name,-20}");

            var grid = elem as Grid;
            if (grid != null)
            {
                grid.Background = Darken(grid.Background as SolidColorBrush);
            }
        }

        private void OnPointerExited(object sender, PointerRoutedEventArgs e)
        {
            var elem = sender as FrameworkElement;
            var source = e.OriginalSource as FrameworkElement;

            Debug.WriteLine($"PointerExited  - Sender: {elem?.Name,-20} - Source: {source?.Name,-20}");

            var grid = elem as Grid;
            if (grid != null)
            {
                grid.Background = Lighten(grid.Background as SolidColorBrush);
            }
        }

        SolidColorBrush Darken(SolidColorBrush brush)
        {
            var color = brush.Color;
            color.R -= 50;
            color.G -= 50;
            color.B -= 50;
            brush.Color = color;
            return brush;
        }

        SolidColorBrush Lighten(SolidColorBrush brush)
        {
            var color = brush.Color;
            color.R += 50;
            color.G += 50;
            color.B += 50;
            brush.Color = color;
            return brush;
        }

    }
}
