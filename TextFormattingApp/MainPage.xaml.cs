using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Microsoft.UI;
using Windows.UI.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Storage.Pickers;
using Windows.Storage;
using Windows.Storage.Streams;
using System.Threading.Tasks;
using Windows.UI.Text;
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Report2_Program
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
        void OnBoldAppBarCheckBoxChecked(object sender, RoutedEventArgs args)
        {
            CheckBox chkbox = sender as CheckBox;
            textBlock.FontWeight = (bool)chkbox.IsChecked ? FontWeights.Bold : FontWeights.Normal;
        }
        void OnItalicAppBarCheckBoxChecked(object sender, RoutedEventArgs args)
        {
            CheckBox chkbox = sender as CheckBox;
            textBlock.FontStyle = (bool)chkbox.IsChecked ? FontStyle.Italic : FontStyle.Normal;
        }
        void OnUnderlineAppBarCheckBoxChecked(object sender, RoutedEventArgs args)
        {
            CheckBox chkbox = sender as CheckBox;
            Inline inline = textBlock.Inlines[0];
            if ((bool)chkbox.IsChecked && !(inline is Underline))
            {
                Underline underline = new Underline();
                textBlock.Inlines[0] = underline;
                underline.Inlines.Add(inline);
            }
            else if (!(bool)chkbox.IsChecked && inline is Underline)
            {
                Underline underline = inline as Underline;
                Run run = underline.Inlines[0] as Run;
                underline.Inlines.Clear();
                textBlock.Inlines[0] = run;
            }
        }
        void OnFontColorAppBarRadioButtonChecked(object sender, RoutedEventArgs args)
        {
            textBlock.Foreground = (sender as RadioButton).Foreground;
        }

    }
}
