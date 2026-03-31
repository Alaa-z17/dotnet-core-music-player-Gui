namespace dotnet_core_music_player_Gui
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lstPlaylist = new ListBox();
            lblCurrentSong = new Label();
            btnNext = new Button();
            btnPrev = new Button();
            btnAddSong = new Button();
            btnClear = new Button();
            SuspendLayout();
            // 
            // lstPlaylist
            // 
            lstPlaylist.FormattingEnabled = true;
            lstPlaylist.Location = new Point(1, 229);
            lstPlaylist.Name = "lstPlaylist";
            lstPlaylist.Size = new Size(836, 244);
            lstPlaylist.TabIndex = 0;
            // 
            // lblCurrentSong
            // 
            lblCurrentSong.AutoSize = true;
            lblCurrentSong.Font = new Font("Segoe UI", 24F);
            lblCurrentSong.Location = new Point(268, 9);
            lblCurrentSong.Name = "lblCurrentSong";
            lblCurrentSong.Size = new Size(306, 54);
            lblCurrentSong.TabIndex = 1;
            lblCurrentSong.Text = "Playlist is empty";
            // 
            // btnNext
            // 
            btnNext.Font = new Font("Segoe UI", 12F);
            btnNext.Location = new Point(185, 79);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(170, 66);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next Song";
            btnNext.UseVisualStyleBackColor = true;
            btnNext.Click += btnNext_Click;
            // 
            // btnPrev
            // 
            btnPrev.Font = new Font("Segoe UI", 12F);
            btnPrev.Location = new Point(9, 79);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(170, 66);
            btnPrev.TabIndex = 3;
            btnPrev.Text = "Prev Song";
            btnPrev.UseVisualStyleBackColor = true;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnAddSong
            // 
            btnAddSong.Font = new Font("Segoe UI", 12F);
            btnAddSong.Location = new Point(185, 157);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(170, 66);
            btnAddSong.TabIndex = 4;
            btnAddSong.Text = "Add Song";
            btnAddSong.UseVisualStyleBackColor = true;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // btnClear
            // 
            btnClear.Font = new Font("Segoe UI", 12F);
            btnClear.Location = new Point(9, 156);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(170, 66);
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(841, 472);
            Controls.Add(btnClear);
            Controls.Add(btnAddSong);
            Controls.Add(btnPrev);
            Controls.Add(btnNext);
            Controls.Add(lblCurrentSong);
            Controls.Add(lstPlaylist);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstPlaylist;
        private Label lblCurrentSong;
        private Button btnNext;
        private Button btnPrev;
        private Button btnAddSong;
        private Button btnClear;
    }
}
