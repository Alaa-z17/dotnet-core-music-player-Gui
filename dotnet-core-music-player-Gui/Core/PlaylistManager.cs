using dotnet_core_music_player_Gui.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicPlayerApp.Core
{
    public enum PlaybackState
    {
        Stopped,
        Playing,
        Paused
    }

    public enum PlayAction { PlayNew, Resume, Pause, Stop }

    public class PlaybackRequestEventArgs : EventArgs
    {
        public PlayAction Action { get; }
        public Song? Song { get; }
        public PlaybackRequestEventArgs(PlayAction action, Song? song)
        {
            Action = action;
            Song = song;
        }
    }

    public class PlaylistManager : INotifyPropertyChanged
    {
        private CustomDoublyLinkedList<Song> playlist;
        private Node<Song>? currentSongNode;
        private PlaybackState _playbackState;

        public Song? CurrentSong => currentSongNode?.Data;
        public PlaybackState PlaybackState
        {
            get => _playbackState;
            private set
            {
                if (_playbackState != value)
                {
                    _playbackState = value;
                    OnPropertyChanged();
                }
            }
        }

        public event EventHandler<PlaybackRequestEventArgs>? PlaybackRequested;
        public event PropertyChangedEventHandler? PropertyChanged;

        public PlaylistManager()
        {
            playlist = new CustomDoublyLinkedList<Song>();
            currentSongNode = null;
            PlaybackState = PlaybackState.Stopped;
        }

        public void AddSongToPlaylist(Song song)
        {
            playlist.AddBack(song);
            if (currentSongNode == null)
            {
                currentSongNode = playlist.First;
                OnPropertyChanged(nameof(CurrentSong));
            }
        }

        public void Play()
        {
            if (PlaybackState == PlaybackState.Paused && CurrentSong != null)
            {
                PlaybackState = PlaybackState.Playing;
                PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.Resume, CurrentSong));
            }
            else if (CurrentSong != null)
            {
                PlaybackState = PlaybackState.Playing;
                PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.PlayNew, CurrentSong));
            }
        }

        public void Pause()
        {
            if (PlaybackState == PlaybackState.Playing)
            {
                PlaybackState = PlaybackState.Paused;
                PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.Pause, CurrentSong));
            }
        }

        public void Stop()
        {
            PlaybackState = PlaybackState.Stopped;
            PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.Stop, CurrentSong));
        }

        public void Next()
        {
            if (currentSongNode == null) return;

            if (currentSongNode.Next != null)
                currentSongNode = currentSongNode.Next;
            else
                currentSongNode = playlist.First;

            OnPropertyChanged(nameof(CurrentSong));

            if (PlaybackState == PlaybackState.Playing)
                PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.PlayNew, CurrentSong));
        }

        public void Previous()
        {
            if (currentSongNode == null) return;

            if (currentSongNode.Prev != null)
                currentSongNode = currentSongNode.Prev;
            else
                currentSongNode = playlist.Last;

            OnPropertyChanged(nameof(CurrentSong));

            if (PlaybackState == PlaybackState.Playing)
                PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.PlayNew, CurrentSong));
        }

        public void JumpToSong(Song selectedSong)
        {
            var current = playlist.First;
            while (current != null)
            {
                if (ReferenceEquals(current.Data, selectedSong))
                {
                    currentSongNode = current;
                    OnPropertyChanged(nameof(CurrentSong));
                    if (PlaybackState == PlaybackState.Playing)
                        PlaybackRequested?.Invoke(this, new PlaybackRequestEventArgs(PlayAction.PlayNew, CurrentSong));
                    return;
                }
                current = current.Next;
            }
        }

        public void ClearPlaylist()
        {
            playlist.Clear();
            currentSongNode = null;
            PlaybackState = PlaybackState.Stopped;
            OnPropertyChanged(nameof(CurrentSong));
        }

        public int GetTotalSongs() => playlist.Size();

        public IEnumerable<Song> GetAllSongs()
        {
            var current = playlist.First;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}