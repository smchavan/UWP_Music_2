using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddSongPage : Page
    {
       // public object Url { get; private set; }

        public AddSongPage()
        {
            this.InitializeComponent();
        }
        //Update Song Fields with the Song Data
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            Song currentSong = e.Parameter as Song;
            if (currentSong != null)
            {
                Name.Text = currentSong.SongName != null ? currentSong.SongName : " ";
                Url.Text = currentSong.AudioFormat != null ? currentSong.AudioFormat : "  ";
                ArtistName.Text = currentSong.ArtistName != null ? currentSong.ArtistName : " ";
                CoverPhoto.Text = currentSong.ImageFormat != null ? currentSong.ImageFormat : " ";
                //Catagory.Text = currentSong.Category
            }

        }

        /// <summary>
        /// Save Song to the file system.
        /// songs.text is created which holds the collection of user-music-library
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddSong_Click(object sender, RoutedEventArgs e)
        {
            var song = new Song
            {
                SongName = Name.Text,
                AudioFormat = Url.Text,
                ArtistName = ArtistName.Text,
                ImageFormat = CoverPhoto.Text,//cover photo of the song
               // Category = ""
            };
            Song.saveSong(song);
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

        /// <summary>
        /// Upload music file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private async void AudioButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker mediaPicker = new FileOpenPicker();
            mediaPicker.ViewMode = PickerViewMode.List;
            mediaPicker.SuggestedStartLocation = PickerLocationId.VideosLibrary;
            mediaPicker.FileTypeFilter.Add(".mp3"); //".mp3", ".mp4", ".wma"
            mediaPicker.FileTypeFilter.Add(".m4a");
            mediaPicker.FileTypeFilter.Add(".wma");
            mediaPicker.FileTypeFilter.Add(".flv");
            StorageFile selectedFile = await GetFileNameAsync(mediaPicker);
            if (selectedFile != null)
            {
                this.Url.Text = selectedFile.Path;
            }
            else
            {
                this.Url.Text = "Operation cancelled.";
            }
        }

        /// <summary>
        /// Add Cover photo for the Song
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            FileOpenPicker imagePicker = new FileOpenPicker();
            imagePicker.ViewMode = PickerViewMode.Thumbnail;
            imagePicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            imagePicker.FileTypeFilter.Add(".jpg");
            imagePicker.FileTypeFilter.Add(".jpeg");
            imagePicker.FileTypeFilter.Add(".svg");
            imagePicker.FileTypeFilter.Add(".png");
            imagePicker.FileTypeFilter.Add(".bmp");
            StorageFile selectedFile = await GetFileNameAsync(imagePicker);
            if (selectedFile != null)
            {
                this.CoverPhoto.Text = selectedFile.Path;
            }
            else
            {
                this.CoverPhoto.Text = "Operation cancelled.";
            }
        }

        private async Task<StorageFile> GetFileNameAsync(FileOpenPicker imagePicker)
        {
            StorageFile selectedFile = await imagePicker.PickSingleFileAsync();
            return selectedFile;
        }

    }
}

