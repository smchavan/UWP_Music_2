using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
   public class Song
    {
        public string Name { get; set; }
        public SongCategory Category { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
      //  public string ArtistName { get; set; }
        private const string FILE_NAME = "songs.text";

        private string songName;// name of the song
        private string audioFormat;// url of the song
        private string imageFormat;//cover photo of the song
        private string artistName;// artist name
        private string category;// category of the song

        public Song(string name, SongCategory category)
        {
            Name = name;
           // Category = category;
            AudioFile = String.Format("/Assets/Song/{0}.m4a", name);
            ImageFile = String.Format("/Assets/Image/{0}.png", name);
            // call a filehelper method to write the song to general playlist txt file
         }
        //Song object with the song name and the cover photo
        public Song(string songName, string imageFormat)
        {
            this.songName = songName;
            this.imageFormat = imageFormat;
        }

        //Default Constructor
        public Song()
        {

        }
        public string SongName { get => this.songName; set => this.songName = value; }

        /// <summary>
        /// URI from the file system for the music to play
        /// </summary>
        public string AudioFormat { get => this.audioFormat; set => this.audioFormat = value; }

        /// <summary>
        /// Cover Photo for the song
        /// </summary>
        public string ImageFormat { get => this.imageFormat; set => this.imageFormat = value; }

        /// <summary>
        /// Uniquely identifies each song with song id
        /// </summary>
        /*public int songId {
            get => this.songId;
            set => this.songId = songId;
        }*/

        /// <summary>
        /// Artist Name 
        /// </summary>
        public string ArtistName { get => this.artistName; set => this.artistName = value; }

        /// <summary>
        /// Category for the Song
        /// </summary>
      //  public string Category { get => this.category; set => this.category = value; }

        /// <summary>
        /// Get Songs from songs.text from the windows storage folder
        /// </summary>
        /// <returns>Collection of Songs</returns>
        public async static Task<ICollection<Song>> GetSongs()
        {
            var songs = new List<Song>();
            var fileContent = await FileHelper.readFromTextFileAsync(FILE_NAME);
            var lines = fileContent.Split(new char[] { '\r', '\n' });
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                    continue;
                var lineParts = line.Split(',');
                if (lineParts != null && lineParts.Length > 0)
                {
                    try
                    {
                        var song = new Song
                        {
                            SongName = lineParts[0],
                            AudioFormat = lineParts[1],
                            ArtistName = lineParts[2],
                            ImageFormat = lineParts[3],
                           // Category = lineParts[4]
                        };
                        songs.Add(song);
                    }
                    catch (Exception e)//Array Index out of bounds Exception might occur
                    {
                        //e.StackTrace;
                    }
                }
            }
            return songs;
        }

        public static void saveSong(Song song)
        {
            // var songData = $"{song.SongName},{song.AudioFormat},{song.ArtistName},{song.ImageFormat},{song.Category}";
            var songData = $"{song.SongName},{song.AudioFormat},{song.ArtistName},{song.ImageFormat}";
            FileHelper.WriteToTextFileAsync(FILE_NAME, songData);
        }

    }

}

    public enum SongCategory { 
    
        Melody,
        Rhythms,
        FastBeat
       
    }

