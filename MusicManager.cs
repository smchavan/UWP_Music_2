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
        public static void GetSongsCategory(ObservableCollection<Song> sounds, SongCategory soundCategory)

        {

            var allSounds = getEachSongs();

            var filteredSounds = allSounds.Where(p => p.Category == soundCategory).ToList();

            sounds.Clear();

            filteredSounds.ForEach(p => sounds.Add(p));

        }



        public static void GetSoundsByName(ObservableCollection<Song> sounds, string name)

        {

            var allSounds = getEachSongs();

            var filteredSounds = allSounds.Where(p => p.Name == name).ToList();

            sounds.Clear();

            filteredSounds.ForEach(p => sounds.Add(p));

        }
        public static void GetSongPlaylist(ObservableCollection<Song> sounds, string audioFile)

        {

            var allSounds = getEachSongs();

            var filteredSounds = allSounds.Where(p => p.Name == audioFile).ToList();

            sounds.Clear();

            filteredSounds.ForEach(p => sounds.Add(p));

        }

        private static List<Song> getEachSongs()

        {

            var songs = new List<Song>();
                       
            songs.Add(new Song("song1",SongCategory.FastBeat));
            
            songs.Add(new Song("song2", SongCategory.FastBeat));
            songs.Add(new Song("song3", SongCategory.Melody));
            songs.Add(new Song("song4", SongCategory.Rhythms));
            songs.Add(new Song("song5", SongCategory.Rhythms));
            songs.Add(new Song("song6", SongCategory.Melody));
           
            /*  
             * add to songs
             * Talk to the file system.Songs.txt
             * You will take a stream then read everyline until u reach end of line
             * rnning in a loop;
             * every iteraton - read entry from file and create a song object.(name,uri("http://youtube.com/zxsuzzdfs",artist)
            *
            */
            /* XAML source="youtube.link " */

            
            return songs; 
           
            
        }
        /*
        private static List<Song> createUserPlaylist()
        {
            var songs = new List<Song>();
            return songs;

        }*/
    }
}
