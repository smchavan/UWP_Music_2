using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music
{
   public class Song
    {
        public string Name { get; set; }
        public string AudioFile { get; set; }
        public string ImageFile { get; set; }
        public string ArtistName { get; set; }

        public Song(string name, string artistName)
        {
            Name = name;
            AudioFile = String.Format("/Assets/Song/{0}.m4a", name);
            ImageFile = String.Format("/Assets/Image/{0}.png", name);
            ArtistName = artistName;

        }
    }
}
