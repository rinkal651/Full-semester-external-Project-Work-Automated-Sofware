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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Report2_Program
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>

    public sealed partial class MainPage : Page
    {
        ApplicationDataContainer appData = ApplicationData.Current.LocalSettings;

        public MainPage()
        {
            this.InitializeComponent();
            Loaded += (sender, args) =>
            {
                if (appData.Values.ContainsKey("TextWrapping"))
                    txtbox.TextWrapping = (TextWrapping)appData.Values["TextWrapping"];
                wrapButton.IsChecked = txtbox.TextWrapping == TextWrapping.Wrap;
                wrapButton.Content = (bool)wrapButton.IsChecked ? "Wrap" : "No Wrap";
                txtbox.Focus(FocusState.Programmatic);
            };

        }

        async void OnFileOpenButtonClick(object sender, RoutedEventArgs args)
        {
            FileOpenPicker picker = new FileOpenPicker();
            picker.FileTypeFilter.Add(".txt");
            StorageFile storageFile = await picker.PickSingleFileAsync();
            if (storageFile == null)
                return;
            using (IRandomAccessStream stream = await storageFile.OpenReadAsync())
            {
                using (DataReader dataReader = new DataReader(stream))
                {
                    uint length = (uint)stream.Size;
                    await dataReader.LoadAsync(length);
                    txtbox.Text = dataReader.ReadString(length);
                }
            }

        }
        void OnWrapButtonChecked(object sender, RoutedEventArgs args)
        {
            txtbox.TextWrapping = (bool)wrapButton.IsChecked ? TextWrapping.Wrap :
            TextWrapping.NoWrap;
            wrapButton.Content = (bool)wrapButton.IsChecked ? "Wrap" : "No Wrap";
            appData.Values["TextWrapping"] = (int)txtbox.TextWrapping;
        }
        async void OnFileSaveAsButtonClick(object sender, RoutedEventArgs args)
        {
            await SaveFileAsync(txtbox.Text);
        }
        async Task SaveFileAsync(string text)
        {
            FileSavePicker picker = new FileSavePicker();
            picker.DefaultFileExtension = ".txt";
            picker.FileTypeChoices.Add("Text", new List<string> { ".txt" });
            StorageFile storageFile = await picker.PickSaveFileAsync();
            // If user presses Cancel, result is null
            if (storageFile == null)
                return;
            using (IRandomAccessStream stream = await storageFile.OpenAsync(FileAccessMode.ReadWrite))
            {
                using (DataWriter dataWriter = new DataWriter(stream))
                {
                    dataWriter.WriteString(text);
                    await dataWriter.StoreAsync();
                }
            }
        }
    }
    }
