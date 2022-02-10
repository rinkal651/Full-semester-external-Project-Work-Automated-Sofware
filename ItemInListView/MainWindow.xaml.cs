using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Report2_Project
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    ///   
   
public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            ListView Fruits = new ListView();
            Fruits.Items.Add("Apricot");
            Fruits.Items.Add("Banana");
            Fruits.Items.Add("Cherry");
            Fruits.Items.Add("Orange");
            Fruits.Items.Add("Strawberry");

            // Add the ListView to a parent container in the visual tree (that you created in the corresponding XAML file).
          //  FruitsPanel.Children.Add(Fruits);
        }

     
        }


    }
    

