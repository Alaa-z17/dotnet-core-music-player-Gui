using MusicPlayerApp.Core;
using NAudio.Wave;
using System.ComponentModel;

// Alias to avoid ambiguity with NAudio.Wave.PlaybackState
using CorePlaybackState = MusicPlayerApp.Core.PlaybackState;

namespace dotnet_core_music_player_Gui
{
    public partial class Form1 : Form
    {
        private PlaylistManager _playlistManager;
        private WaveOutEvent? _waveOut;
        private AudioFileReader? _audioFileReader;
        private System.Windows.Forms.Timer _progressTimer;
        private bool _isDraggingProgress = false;

        public Form1()
        {
            InitializeComponent();
            _playlistManager = new PlaylistManager();

            _waveOut = new WaveOutEvent();
            _waveOut.PlaybackStopped += OnPlaybackStopped;

            _progressTimer = new System.Windows.Forms.Timer();
            _progressTimer.Interval = 500;
            _progressTimer.Tick += ProgressTimer_Tick;

            ApplyStyling();

            _playlistManager.PlaybackRequested += OnPlaybackRequested;
            _playlistManager.PropertyChanged += OnPlaylistPropertyChanged;

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;

            UpdateStatusLabel();
        }

        private void ApplyStyling()
        {
            foreach (Button btn in new Button[] { btnPrev, btnPlayPause, btnNext, btnStop, btnAddSong, btnClear })
            {
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.BackColor = Color.FromArgb(50, 50, 50);
                btn.ForeColor = Color.White;
                btn.Font = new Font("Segoe UI", 12);
                btn.Cursor = Cursors.Hand;
            }
            btnPlayPause.BackColor = Color.FromArgb(70, 70, 70);
            btnPlayPause.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lstPlaylist.BackColor = Color.FromArgb(45, 45, 45);
            lstPlaylist.ForeColor = Color.White;
            lstPlaylist.Font = new Font("Segoe UI", 10);
            lstPlaylist.GridLines = false;
            lstPlaylist.BorderStyle = BorderStyle.None;
        }

        private void OnPlaybackRequested(object? sender, PlaybackRequestEventArgs e)
        {
            switch (e.Action)
            {
                case PlayAction.PlayNew:
                    PlayNewSong(e.Song);
                    break;
                case PlayAction.Resume:
                    if (_waveOut != null && _audioFileReader != null)
                    {
                        _waveOut.Play();
                        _progressTimer.Start();
                        UpdateStatusLabel("Resumed");
                    }
                    break;
                case PlayAction.Pause:
                    if (_waveOut != null)
                    {
                        _waveOut.Pause();
                        _progressTimer.Stop();
                        UpdateStatusLabel("Paused");
                    }
                    break;
                case PlayAction.Stop:
                    StopPlayback();
                    break;
            }
        }

        private void PlayNewSong(Song? song)
        {
            if (song == null || string.IsNullOrEmpty(song.FilePath) || !File.Exists(song.FilePath))
                return;

            StopPlayback();

            try
            {
                _audioFileReader = new AudioFileReader(song.FilePath);
                _waveOut = new WaveOutEvent();
                _waveOut.Init(_audioFileReader);
                _waveOut.Play();
                _progressTimer.Start();

                trackVolume.Value = (int)(_audioFileReader.Volume * 100);
                trackVolume.Enabled = true;

                trackProgress.Maximum = (int)_audioFileReader.TotalTime.TotalSeconds;
                trackProgress.Enabled = true;

                UpdateStatusLabel("Playing: " + song.Title);
            }
            catch (Exception ex)
            {
                UpdateStatusLabel("Error: " + ex.Message);
            }
        }

        private void StopPlayback()
        {
            _progressTimer.Stop();
            if (_waveOut != null)
            {
                _waveOut.Stop();
                _waveOut.Dispose();
                _waveOut = null;
            }
            if (_audioFileReader != null)
            {
                _audioFileReader.Dispose();
                _audioFileReader = null;
            }
            trackProgress.Value = 0;
            trackProgress.Enabled = false;
        }

        private void OnPlaybackStopped(object? sender, StoppedEventArgs e)
        {
            if (this.IsDisposed || this.Disposing) return;
            this.Invoke(new MethodInvoker(() =>
            {
                _progressTimer.Stop();
                trackProgress.Value = 0;
                // Auto‑play next song if not manually stopped
                if (_playlistManager.PlaybackState == CorePlaybackState.Playing)
                {
                    _playlistManager.Next();
                    _playlistManager.Play();
                }
            }));
        }

        private void OnPlaylistPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PlaylistManager.CurrentSong))
            {
                var current = _playlistManager.CurrentSong;
                if (current != null)
                {
                    lblCurrentSong.Text = $"♫ {current.Title} - {current.Artist}";
                    foreach (ListViewItem item in lstPlaylist.Items)
                    {
                        if (item.Tag == current)
                        {
                            item.Selected = true;
                            item.EnsureVisible();
                            break;
                        }
                    }
                }
                else
                {
                    lblCurrentSong.Text = "Playlist is empty";
                }
            }
            else if (e.PropertyName == nameof(PlaylistManager.PlaybackState))
            {
                btnPlayPause.Text = _playlistManager.PlaybackState == CorePlaybackState.Playing ? "⏸" : "▶";
                btnPlayPause.Font = new Font("Segoe UI", 14, FontStyle.Bold);
                if (_playlistManager.PlaybackState == CorePlaybackState.Playing)
                    UpdateStatusLabel("Playing");
                else if (_playlistManager.PlaybackState == CorePlaybackState.Paused)
                    UpdateStatusLabel("Paused");
                else
                    UpdateStatusLabel("Stopped");
            }
            UpdateSongCount();
        }

        private void ProgressTimer_Tick(object? sender, EventArgs e)
        {
            if (_waveOut != null && _audioFileReader != null && _waveOut.PlaybackState == NAudio.Wave.PlaybackState.Playing && !_isDraggingProgress)
            {
                double currentSeconds = _audioFileReader.CurrentTime.TotalSeconds;
                trackProgress.Value = (int)currentSeconds;
            }
        }

        private void trackVolume_Scroll(object sender, EventArgs e)
        {
            if (_audioFileReader != null)
            {
                _audioFileReader.Volume = trackVolume.Value / 100f;
                UpdateStatusLabel($"Volume: {trackVolume.Value}%");
            }
        }

        private void trackProgress_Scroll(object sender, EventArgs e)
        {
            _isDraggingProgress = true;
        }

        private void trackProgress_MouseUp(object sender, MouseEventArgs e)
        {
            if (_audioFileReader != null && _waveOut != null)
            {
                _audioFileReader.CurrentTime = TimeSpan.FromSeconds(trackProgress.Value);
                _isDraggingProgress = false;
                UpdateStatusLabel($"Seeked to {TimeSpan.FromSeconds(trackProgress.Value):mm\\:ss}");
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            _playlistManager.Previous();
            _playlistManager.Play();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            _playlistManager.Next();
            _playlistManager.Play();
        }

        private void btnPlayPause_Click(object sender, EventArgs e)
        {
            if (_playlistManager.PlaybackState == CorePlaybackState.Playing)
                _playlistManager.Pause();
            else
                _playlistManager.Play();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _playlistManager.Stop();
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Audio Files|*.mp3;*.wav";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        string title = Path.GetFileNameWithoutExtension(file);
                        Song newSong = new Song(title, "Unknown Artist", file);
                        _playlistManager.AddSongToPlaylist(newSong);
                    }
                    ApplySearchFilter();
                    UpdateSongCount();
                    UpdateStatusLabel($"Added {openFileDialog.FileNames.Length} song(s)");
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            StopPlayback();
            _playlistManager.ClearPlaylist();
            lstPlaylist.Items.Clear();
            lblCurrentSong.Text = "Playlist is empty";
            UpdateSongCount();
            UpdateStatusLabel("Cleared");
        }

        private void lstPlaylist_DoubleClick(object sender, EventArgs e)
        {
            if (lstPlaylist.SelectedItems.Count > 0)
            {
                ListViewItem item = lstPlaylist.SelectedItems[0];
                if (item.Tag is Song selectedSong)
                {
                    _playlistManager.JumpToSong(selectedSong);
                    _playlistManager.Play();
                }
            }
        }

        private void UpdateStatusLabel(string? message = null)
        {
            if (message != null)
                lblStatus.Text = message;
            else
                lblStatus.Text = "Ready";
        }

        private void UpdateSongCount()
        {
            int count = _playlistManager.GetTotalSongs();
            lblSongCount.Text = $"{count} song{(count != 1 ? "s" : "")}";
        }

        private void AddSongToListView(Song song)
        {
            var item = new ListViewItem(song.Title);
            item.SubItems.Add(song.Artist);
            item.Tag = song;
            lstPlaylist.Items.Add(item);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            ApplySearchFilter();
        }

        private void ApplySearchFilter()
        {
            string filter = txtSearch.Text.Trim().ToLower();
            lstPlaylist.BeginUpdate();
            lstPlaylist.Items.Clear();

            foreach (Song song in _playlistManager.GetAllSongs())
            {
                if (string.IsNullOrEmpty(filter) ||
                    song.Title.ToLower().Contains(filter) ||
                    song.Artist.ToLower().Contains(filter))
                {
                    AddSongToListView(song);
                }
            }
            lstPlaylist.EndUpdate();
        }

        private void Form1_DragEnter(object? sender, DragEventArgs e)
        {
            if (e.Data?.GetDataPresent(DataFormats.FileDrop) == true)
                e.Effect = DragDropEffects.Copy;
        }

        private void Form1_DragDrop(object? sender, DragEventArgs e)
        {
            string[]? files = e.Data?.GetData(DataFormats.FileDrop) as string[];
            if (files != null)
            {
                foreach (string file in files)
                {
                    if (file.EndsWith(".mp3", StringComparison.OrdinalIgnoreCase) ||
                        file.EndsWith(".wav", StringComparison.OrdinalIgnoreCase))
                    {
                        string title = Path.GetFileNameWithoutExtension(file);
                        Song song = new Song(title, "Unknown Artist", file);
                        _playlistManager.AddSongToPlaylist(song);
                    }
                }
                ApplySearchFilter();
                UpdateSongCount();
                UpdateStatusLabel($"Added {files.Length} file(s)");
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _progressTimer?.Stop();
            _waveOut?.Stop();
            _waveOut?.Dispose();
            _audioFileReader?.Dispose();
            base.OnFormClosing(e);
        }
    }
}