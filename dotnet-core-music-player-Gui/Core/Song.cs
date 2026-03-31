namespace MusicPlayerApp.Core
{
    public class Song
    {
        public string Title { get; set; }
        public string Artist { get; set; }
        public string FilePath { get; set; }

        public Song(string title, string artist, string filePath)
        {
            Title = title;
            Artist = artist;
            FilePath = filePath;
        }

        // Overriding ToString() makes it easy to display the song in UI ListBoxes later
        public override string ToString()
        {
            return $"{Title} - {Artist}";
        }
    }
}