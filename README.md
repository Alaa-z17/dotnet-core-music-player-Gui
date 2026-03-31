# 🎵 Circular Pro Music Player (.NET Core)

A professional-grade desktop music player built with **C#** and **WinForms**, featuring a custom-engineered **Circular Doubly Linked List** for seamless playlist management.

## 🚀 Key Features
- **Custom Data Structure:** Built from scratch using a `Node<T>` based Doubly Linked List.
- **Circular Navigation:** Seamlessly loop from the last song to the first and vice versa.
- **Real-time Playback:** High-quality audio support (MP3/WAV) via `NetCoreAudio` & `NAudio`.
- **Interactive UI:** Supports Drag & Drop, real-time search, and volume/progress tracking.
- **Direct Selection:** Jump to any song instantly with double-click logic.

## 🛠 Engineering Highlight: The Circular List
Unlike standard arrays, this project uses a custom Linked List where:
- Each **Node** points to both the `Next` and `Previous` song.
- The `PlayNext` logic automatically resets the cursor to `Head` if it hits the end.
- This ensures **O(1)** time complexity for navigation and **O(1)** for adding new tracks.

## 💻 How to Run
1. Clone the repo: `git clone https://github.com/Alaa-z17/music-player-gui.git`
2. Restore NuGet packages: `dotnet restore`
3. Run the project: `dotnet run`

## 📄 License
This project is licensed under the **MIT License**.
