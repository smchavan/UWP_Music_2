using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.Storage;   
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.DataTransfer;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Music
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        MediaSource _mediaSource;
        MediaPlayer _mediaPlayer;
        private ObservableCollection<Song> songs;

        private List<MenuItem> MenuItems;
        private List<String> Suggestions;

        public MainPage()
        {
            this.InitializeComponent();
            songs = new ObservableCollection<Song>();
            MusicManager.GetAllSongs(songs);
            MenuItems = new List<MenuItem>();

            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/fastbeat.jpg", Category = SongCategory.FastBeat });

            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/melody.jpg", Category = SongCategory.Rhythms });

            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/rythms.jpg", Category = SongCategory.Melody });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/rythms.jpg", Category = SongCategory.Melody });


            BackButton.Visibility = Visibility.Collapsed;
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            Song test = new Song
            {
                SongName = "song6",
                AudioFormat = "C:/Users/seetha/Documents/Sound recordings",
                ArtistName = "Raghu Dixit",
                ImageFormat = "C:/Users/seetha/Downloads/Arizona.jpg",
                //  Category = "Melodies"
            };
           DataContext = test;//dummy model object set. TOBE REMOVED & ACTUAL DATA CLICKED FROM THE UI NEEDS TO BE PASSED

            Frame.Navigate(typeof(UserPlaylList),test);
               
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



        private void HamburgerButton_Click(object sender, RoutedEventArgs e)

        {

            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;

        }



        private void BackButton_Click(object sender, RoutedEventArgs e)

        {

            goBack();

        }
        private void AddSong_Click(object sender, RoutedEventArgs e)

        {

            Frame.Navigate(typeof(AddSongPage));

        }



        private void SearchAutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)

        {

            if (String.IsNullOrEmpty(sender.Text)) goBack();



            MusicManager.GetAllSongs(songs);

            Suggestions = songs

                .Where(p => p.Name.StartsWith(sender.Text))

                .Select(p => p.Name)

                .ToList();

            SearchAutoSuggestBox.ItemsSource = Suggestions;



        }



        private void goBack()

        {

            MusicManager.GetAllSongs(songs);

            Music_Collection.Text = "Music Collection";

            MenuItemsListView.SelectedItem = null;
           // Frame.Navigate(typeof(UserPlaylList));


            BackButton.Visibility = Visibility.Collapsed;
           

        }

      private void SearchAutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)

        {

            MusicManager.GetSoundsByName(songs, sender.Text);

            Music_Collection.Text = sender.Text;

            MenuItemsListView.SelectedItem = null;

            BackButton.Visibility = Visibility.Visible;

        }
           private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {

            var menuItem = (MenuItem)e.ClickedItem;
                       
            // Filter on category

            Music_Collection.Text = menuItem.Category.ToString();

            MusicManager.GetSongsCategory(songs, menuItem.Category);

            BackButton.Visibility = Visibility.Visible;

        }

        

        /*
private void ColorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
{

   var song = (Song)e.AddedItems;
   MusicManager.GetSongsCategory(songs, song.Category);
}
*/
    }
}

     /*   private void Playlist_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(UserPlaylList));

        }

       
    }
}





    /*
    long token;

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        token = mediaPlayer.RegisterPropertyChangedCallback(MediaPlayerElement.IsFullWindowProperty, OnMPEFullWindowChanged);
        base.OnNavigatedTo(e);
    }

    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        mediaPlayer.UnregisterPropertyChangedCallback(MediaPlayerElement.IsFullWindowProperty, token);
    }

    private void OnMPEFullWindowChanged(DependencyObject sender, DependencyProperty dp)
    {
        MediaPlayerElement mpe = (MediaPlayerElement)sender;

        if (mpe != null && dp == MediaPlayerElement.IsFullWindowProperty)
        {
            if (mpe.IsFullWindow == true)
            {
                mediaPlayerPopup.Visibility = Visibility.Collapsed;
            }
            else
            {
                mediaPlayerPopup.Visibility = Visibility.Visible;
            }
        }
    }

    private void ClosePopupClicked(object sender, RoutedEventArgs e)
    {
        // If the Popup is open, then close it. 
        if (mediaPlayerPopup.IsOpen) { mediaPlayerPopup.IsOpen = false; }
    }

    // Handles the Click event on the Button on the page and opens the Popup. 
    private void ShowPopupClicked(object sender, RoutedEventArgs e)
    {
        // Open the Popup if it isn't open already.
        if (!mediaPlayerPopup.IsOpen) { mediaPlayerPopup.IsOpen = true; }
    } 
    */

