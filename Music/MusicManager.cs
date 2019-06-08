using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
    class MusicManager
    {
        public static void GetAllSongs(ObservableCollection<Song> songs)

        {

            var allSongs = getEachSongs();

            songs.Clear();

            allSongs.ForEach(p => songs.Add(p));

        }
        private static List<Song> getEachSongs()

        {

            var songs = new List<Song>();



            songs.Add(new Song("song1","AR.Rahman"));

            songs.Add(new Song("song2", "AR.Rahman"));
            songs.Add(new Song("song3", "AR.Rahman"));
            songs.Add(new Song("song4", "AR.Rahman"));
         //   songs.Add(new Song("song5", "AR.Rahman"));
          //  songs.Add(new Song("song6", "AR.Rahman"));

            return songs;
           

        }
    }
}
