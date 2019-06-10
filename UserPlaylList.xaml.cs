using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Windows.ApplicationModel.DataTransfer;

using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Media.Playback;
using Windows.Media.Core;
using Windows.UI;
using Windows.Media;
using System.ComponentModel;
using System.Collections;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UserPlaylList : Page

    {
        MediaSource _mediaSource;
        MediaPlayer _mediaPlayer;
        MediaPlaybackItem _mediaPlaybackItem;
        private ObservableCollection<Song> songsview;
        private List<ComboBox> comboBox;

        SystemMediaTransportControls _systemMediaTransportControls;

        public UserPlaylList()
        {
            this.InitializeComponent();
          //  songs = new ObservableCollection<Song>();
           // MusicManager.GetAllSongs(songs);
           


        }

        private void SongView_ItemClick(object sender, ItemClickEventArgs e)

        {

            var clicked_song = (Song)e.ClickedItem;

            //if song clicked it will add to media userplaylist


            mediaElement.Source = MediaSource.CreateFromUri(new Uri(this.BaseUri, clicked_song.AudioFile));


            // MediaPlaybackList _mediaPlaybackList = new MediaPlaybackList();
            /* foreach (Song file in songs)
             {
                 _mediaSource = MediaSource.CreateFromUri(new Uri(this.BaseUri, song.AudioFile));
                 _mediaPlaybackList.Items.Add(new MediaPlaybackItem(_mediaSource));
                 _mediaPlayer = new MediaPlayer();
                 _mediaPlayer.AutoPlay = false;
                 _mediaPlayer.Source = _mediaPlaybackList;
                 mediaElement.SetMediaPlayer(_mediaPlayer);
                 _mediaPlayer.Play();

             }*/

        }
        /*
        private static ArrayList GetViewSongs()

        {

            var songs = new ArrayList();

            songs.Add("song1");

            songs.Add("song2");
            songs.Add("song3");
            songs.Add("song4");
            return songs;
        }*/

        private async void User_song_click(object sender, ItemClickEventArgs e)

        {
            var clicked_song = (Song)e.ClickedItem;

            //if song clicked it will add to media userplaylist
            StorageFile file = await KnownFolders.VideosLibrary.GetFileAsync(clicked_song.AudioFormat);
            if (file != null)
            {
                var filestream = await file.OpenAsync(FileAccessMode.Read);
                // mediaControl is a MediaElement defined in XAML
                mediaElement.Source = MediaSource.CreateFromStream(filestream, file.ContentType);
                _mediaPlayer = new MediaPlayer();
                _mediaPlayer = mediaElement.MediaPlayer;
                //_mediaPlayer.AutoPlay = false;
                _mediaPlayer.Play();

                //  mediaElement.Source = MediaSource.CreateFromUri(new Uri(this.BaseUri, clicked_song.AudioFormat));


            }
        }

        /*
        private async void MediaElement_Loaded(object sender,RoutedEventArgs e)
        {
            MediaPlayerElement playerElement = sender as MediaPlayerElement;
            StorageFile file = await KnownFolders.VideosLibrary.GetFileAsync("song1.m4a");
            if (file != null)
            {
                var filestream = await file.OpenAsync(FileAccessMode.Read);
                // mediaControl is a MediaElement defined in XAML
                mediaElement.Source = MediaSource.CreateFromStream(filestream, file.ContentType);
                _mediaPlayer = new MediaPlayer();
                _mediaPlayer = mediaElement.MediaPlayer;
                //_mediaPlayer.AutoPlay = false;
                _mediaPlayer.Play();
            }
        }
        */

        protected async override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            //Song currentSong = e.Parameter as Song;

            //the media source for media element using uri
            //FileStream fs = File.OpenRead("C:/Users/seetha/Videos/song1.m4a");
            //mediaElement.Source = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/Videos/song1.m4a"));
            //var file = await KnownFolders.PicturesLibrary.GetFileAsync("2.jpg");
            //PickerLocationId.VideosLibrary;

            songsview =await Song.GetSongs();
            //Song_User.ItemsSource = songsview;
            

           
            /* using (var fileStream = (await file.OpenReadAsync()))
         {

         }






    /*  private void playlistCheckbox_Click(object sender, RoutedEventArgs e)
      {

          string selectedToppingsText = string.Empty;
          CheckBox[] checkboxes = new CheckBox[] { song1Checkbox, song2Checkbox,
                                           song3Checkbox, song4Checkbox };
          foreach (CheckBox c in checkboxes)
          {
              if (c.IsChecked == true)
              {
                  if (selectedToppingsText.Length > 1)
                  {
                      selectedToppingsText += ", ";
                  }
                  selectedToppingsText += c.Content;
              } 
          }
          UserPlaylist.Text = selectedToppingsText;
      }
     */
            /*
           private async void CreatePlaylist(object sender, RoutedEventArgs e)
            {
                FileOpenPicker openPicker = new FileOpenPicker();
                openPicker.ViewMode = PickerViewMode.List;
                openPicker.SuggestedStartLocation = PickerLocationId.Downloads;
                openPicker.FileTypeFilter.Add(".m4a");
               openPicker.FileTypeFilter.Add(".mp4");
               openPicker.FileTypeFilter.Add(".wav");
               openPicker.FileTypeFilter.Add(".flv");
               IReadOnlyList<StorageFile> files = await openPicker.PickMultipleFilesAsync();

                if (files.Count > 0)
                {                foreach (StorageFile file in files)
                    {

                        MediaPlaybackList _mediaPlaybackList = new MediaPlaybackList();
                        _mediaSource = MediaSource.CreateFromStorageFile(file);
                        _mediaPlaybackItem = new MediaPlaybackItem(_mediaSource);
                        _mediaPlaybackList.Items.Add(_mediaPlaybackItem);
                        _mediaPlayer = new MediaPlayer();
                       _mediaPlayer.Source = _mediaPlaybackList;
                      mediaElement.SetMediaPlayer(_mediaPlayer);
                     _mediaPlayer.Play();
            }
        }

    }*/
            /*
                   public  void BackButton_click(object sender, RoutedEventArgs e)
                   {
                       Frame.Navigate(typeof(MainPage));
                   }*/

            /*private void GetUri(object sender, RoutedEventArgs e)
            {
                Uri newuri = new Uri("ms-appx:///Assets/mySong.mp3");
                mediaElement.Source = newuri;

            }
            */

            /*
                 async void SystemControls_ButtonPressed(SystemMediaTransportControls sender,
         SystemMediaTransportControlsButtonPressedEventArgs args)
                 {
                     switch (args.Button)
                     {
                         case SystemMediaTransportControlsButton.Play:
                             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                             {
                                 _mediaPlayer.Play();
                             });
                             break;
                         case SystemMediaTransportControlsButton.Pause:
                             await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
                             {
                                 _mediaPlayer.Pause();
                             });
                             break;
                         default:
                             break;
                     }
                 }*/

        }
    }
}



 

