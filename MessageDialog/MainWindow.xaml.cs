using Microsoft.UI;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Popups;

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
        Color clr;
        public MainWindow()
        {
            this.InitializeComponent();
           
                  }
        void OnButtonClick(object sender, RoutedEventArgs args)
        {
            MessageDialog msgdlg = new MessageDialog("Choose a color", "How To Async #1");
            msgdlg.Commands.Add(new UICommand("Red", null, Colors.Red));
            msgdlg.Commands.Add(new UICommand("Green", null, Colors.Green));
            msgdlg.Commands.Add(new UICommand("Blue", null, Colors.Blue));
            // Show the MessageDialog with a Completed handler
            IAsyncOperation<IUICommand> asyncOp = msgdlg.ShowAsync();
            asyncOp.Completed = OnMessageDialogShowAsyncCompleted;
        }
        void OnMessageDialogShowAsyncCompleted(IAsyncOperation<IUICommand> asyncInfo,
        AsyncStatus asyncStatus)
        {
            // Get the Color value
            IUICommand command = asyncInfo.GetResults();
            clr = (Color)command.Id;
            // Use a Dispatcher to run in the UI thread
            IAsyncAction asyncAction = this.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            OnDispatcherRunAsyncCallback);
        }
        void OnDispatcherRunAsyncCallback()
        {
            // Set the background brush
            contentGrid.Background = new SolidColorBrush(clr);
        }


    }


    }
    

