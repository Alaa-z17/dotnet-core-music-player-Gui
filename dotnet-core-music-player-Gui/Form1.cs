using MusicPlayerApp.Core;
using NetCoreAudio; // 1. Bring in the audio library

namespace dotnet_core_music_player_Gui
{
    public partial class Form1 : Form
    {
        private PlaylistManager _playlistManager;
        private Player _audioPlayer; // 2. Create the player instance

        public Form1()
        {
            InitializeComponent();
            _playlistManager = new PlaylistManager();
            _audioPlayer = new Player(); // 3. Initialize the player
        }

        private void UpdateUI()
        {
            var current = _playlistManager.GetCurrentSong();
            if (current != null)
            {
                lblCurrentSong.Text = "Playing: " + current.Title;
                lstPlaylist.SelectedItem = current;

                // 4. Play the actual audio file
                if (File.Exists(current.FilePath))
                {
                    _audioPlayer.Play(current.FilePath);
                }
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _playlistManager.PlayPreviousSong();
            UpdateUI();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _playlistManager.PlayNextSong();
            UpdateUI();
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Audio Files|*.mp3;*.wav";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
                Song newSong = new Song(fileName, "Unknown Artist", openFileDialog.FileName);

                _playlistManager.AddSongToPlaylist(newSong);
                lstPlaylist.Items.Add(newSong);

                UpdateUI();
            }
        }

        // Added the btnClear_Click we talked about earlier
        private void btnClear_Click(object sender, EventArgs e)
        {
            _audioPlayer.Stop(); // Stop any audio currently playing
            _playlistManager.ClearPlaylist();
            lstPlaylist.Items.Clear();
            lblCurrentSong.Text = "Playlist is empty";
        }
    }
}