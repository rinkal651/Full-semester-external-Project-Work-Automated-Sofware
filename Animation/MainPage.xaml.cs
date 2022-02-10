using System;
using System.Collections.Generic;
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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App_Report2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            DoubleAnimation anima = new DoubleAnimation
            {
                EnableDependentAnimation = true,
                To = 96,
                Duration = new Duration(new TimeSpan(0, 0, 1)),
                AutoReverse = true,
                RepeatBehavior = new RepeatBehavior(3)
            };
            Storyboard.SetTarget(anima, sender as Button);
            Storyboard.SetTargetProperty(anima, "FontSize");
            Storyboard storyboard = new Storyboard();
            storyboard.Children.Add(anima);
            storyboard.Begin();
        }
    }
}
