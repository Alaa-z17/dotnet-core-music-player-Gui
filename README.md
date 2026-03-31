# 🎵 Circular Pro Music Player (.NET Core)

A professional-grade desktop music player built with **C#** and **WinForms**, featuring a custom-engineered **Circular Doubly Linked List** for seamless playlist management.

## Video Demonstration

Click the image below to watch the project walk-through and a full demonstration of the system in action!

[![Watch the Video](https://img.youtube.com/vi/MPr3ooje-H4/hqdefault.jpg)](https://www.youtube.com/watch?v=MPr3ooje-H4)


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

 ## 🛠 Development Methodology
- **Core Engineering (The Heart):** The entire playlist engine, including the `CustomDoublyLinkedList`, `Node<T>`, and `PlaylistManager` circular logic, was manually architected and coded to ensure maximum performance and algorithmic correctness.
- **UI & Integration (The Shell):** To maintain a rapid development pace, AI tools were utilized to assist in generating the WinForms UI layouts, event wireups, and standard boilerplate code, allowing the focus to remain on the complex data structure implementation.

## 📦 External Libraries
While the core logic is manual, this project leverages the following libraries for audio processing:
- **NetCoreAudio:** Handles cross-platform audio playback commands.
- **NAudio:** Used for advanced audio stream management and event handling.

## 📥 How to Download (Quick Start)
1. Navigate to the [Releases](https://github.com/Alaa-z17/dotnet-core-music-player-Gui/releases/tag/V1.0.0) page.
2. Download `MusicPlayer-v1.0.0.zip`.
3. Extract the contents to a folder.
4. Double-click `MusicPlayerApp.exe` to start listening!

## 💻 How to Run
1. Clone the repo: `git clone https://github.com/Alaa-z17/music-player-gui.git`
2. Restore NuGet packages: `dotnet restore`
3. Run the project: `dotnet run`

## 📄 License
This project is licensed under the **MIT License**.
