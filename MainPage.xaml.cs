using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace FileAccessTrial
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

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var myDirectory = Directory.CreateDirectory(@"C:\");

            // Get the folder where you want to create a new folder
            StorageFolder parentFolder = ApplicationData.Current.LocalFolder;

            // Get the name for the new folder from the user input
            string newFolderName = "newFolder";

            try
            {
                // Create a new folder asynchronously
                StorageFolder newFolder = await parentFolder.CreateFolderAsync(@"C:\\RGNEW");

            }
            catch (Exception ex)
            {
                // Display an error message if folder creation fails
                var error = $"Error creating folder: {ex.Message}";
            }

            //var picker = new Windows.Storage.Pickers.FolderPicker();
            //picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
            //picker.FileTypeFilter.Add(".exe");//add any extension to avoid exception
            //var folder = await picker.PickSingleFolderAsync();
            //if (folder != null)
            //{
            //    var myNewFolder = await folder.CreateFolderAsync("myNewFolder");
            //}

            // Get the local folder for the app
            //StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            //try
            //{
            //    // Create a new folder
            //    StorageFolder newFolder = await localFolder.CreateFolderAsync("MyNewFolder", CreationCollisionOption.OpenIfExists);

            //    // Create a new file within the folder
            //    StorageFile newFile = await newFolder.CreateFileAsync("MyNewFile.txt", CreationCollisionOption.ReplaceExisting);

            //    // You can now perform additional operations on the file, such as writing content to it
            //    await FileIO.WriteTextAsync(newFile, "Hello, this is the content of the file!");
            //}
            //catch (Exception ex)
            //{
            //    // Handle any exceptions that may occur during folder or file creation
            //    Console.WriteLine($"Error: {ex.Message}");
            //}


            //try
            //{
            //    // Create a folder picker
            //    var folderPicker = new FolderPicker
            //    {
            //        SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            //    };

            //    // Add file type filters if needed
            //    folderPicker.FileTypeFilter.Add(".txt");

            //    // Show the folder picker
            //    StorageFolder selectedFolder = await folderPicker.PickSingleFolderAsync();

            //    if (selectedFolder != null)
            //    {
            //        // Create a new file within the selected folder
            //        StorageFile newFile = await selectedFolder.CreateFileAsync("MyNewFile.txt", CreationCollisionOption.ReplaceExisting);

            //        // You can now perform additional operations on the file, such as writing content to it
            //        await FileIO.WriteTextAsync(newFile, "Hello, this is the content of the file!");
            //    }
            //    else
            //    {
            //        Console.WriteLine("User canceled the operation.");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Handle any exceptions that may occur during folder or file creation
            //    Console.WriteLine($"Error: {ex.Message}");
            //}

        }


        private async void myBtn_Click(object sender, RoutedEventArgs e)
        {
            // Specify the folder path
            string folderPath = @"C:\\RGNEW";

            
            // Get the StorageFolder from the path
            StorageFolder folder = StorageFolder.GetFolderFromPathAsync(folderPath).AsTask().Result;

            // Add the folder to FutureAccessList with the folder path as the token
            string token = folderPath; // You can customize the token if needed
            StorageApplicationPermissions.FutureAccessList.AddOrReplace(token, folder);
        }

        private async void myBtn2_Click(object sender, RoutedEventArgs e)
        {
            var folder = await Windows.Storage.AccessCache.StorageApplicationPermissions.FutureAccessList.GetFolderAsync("PickedFolderToken");
            if (folder != null)
            {
                var newFolder = folder.CreateFolderAsync("myQuietFolder1");
            }
        }
    }
}
