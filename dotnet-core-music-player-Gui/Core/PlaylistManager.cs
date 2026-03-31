using dotnet_core_music_player_Gui.Core;

namespace MusicPlayerApp.Core
{
    public class PlaylistManager
    {
        private CustomDoublyLinkedList<Song> playlist;

        // This pointer acts as our "Cursor" for the current playing song
        private Node<Song>? currentSongNode;

        public PlaylistManager()
        {
            playlist = new CustomDoublyLinkedList<Song>();
            currentSongNode = null;
        }

        public void AddSongToPlaylist(Song song)
        {
            playlist.AddBack(song);

            // If this is the first song added, initialize the cursor
            if (currentSongNode == null)
            {
                currentSongNode = playlist.First;
            }
        }

        public Song? GetCurrentSong()
        {
            return currentSongNode?.Data;
        }

        // Circular Logic: If at the end, jump to First
        public Song? PlayNextSong()
        {
            if (currentSongNode == null) return null;

            if (currentSongNode.Next != null)
            {
                currentSongNode = currentSongNode.Next;
            }
            else
            {
                // Circular jump to the beginning
                currentSongNode = playlist.First;
            }
            return currentSongNode?.Data;
        }

        // Circular Logic: If at the start, jump to Last
        public Song? PlayPreviousSong()
        {
            if (currentSongNode == null) return null;

            if (currentSongNode.Prev != null)
            {
                currentSongNode = currentSongNode.Prev;
            }
            else
            {
                // Circular jump to the end
                currentSongNode = playlist.Last;
            }
            return currentSongNode?.Data;
        }

        public void ClearPlaylist()
        {
            playlist.Clear();
            currentSongNode = null;
        }

        public int GetTotalSongs() => playlist.Size();
    }
}