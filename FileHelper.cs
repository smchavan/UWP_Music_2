using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Streams;

namespace Music
{
    static class FileHelper
    {
        public static async void WriteToTextFileAsync(string filename, string content)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;//localfolder access
            StorageFile songFile = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.OpenIfExists);
            File.AppendAllLines(songFile.Path, new string[] { content });//append content to the file
        }

        public static async Task<string> readFromTextFileAsync(string filename)
        {
            var storageFolder = ApplicationData.Current.LocalFolder;
            var textFile = await storageFolder.GetFileAsync(filename);
            var textStream = await textFile.OpenReadAsync();
            var textReader = new DataReader(textStream);
            var textLength = textStream.Size;
            await textReader.LoadAsync((uint)textLength);
            return textReader.ReadString((uint)textLength);
        }
    }
}
