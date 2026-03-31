namespace dotnet_core_music_player_Gui
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tableLayoutPanel = new TableLayoutPanel();
            lblCurrentSong = new Label();
            btnPrev = new Button();
            btnPlayPause = new Button();
            btnNext = new Button();
            btnStop = new Button();
            btnAddSong = new Button();
            btnClear = new Button();
            lblSearch = new Label();
            txtSearch = new TextBox();
            lstPlaylist = new ListView();
            colTitle = new ColumnHeader();
            colArtist = new ColumnHeader();
            trackProgress = new TrackBar();
            trackVolume = new TrackBar();
            statusStrip = new StatusStrip();
            lblStatus = new ToolStripStatusLabel();
            separator = new ToolStripSeparator();
            lblSongCount = new ToolStripStatusLabel();
            tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackProgress).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackVolume).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33F));
            tableLayoutPanel.Controls.Add(lblCurrentSong, 0, 0);
            tableLayoutPanel.Controls.Add(btnPrev, 0, 1);
            tableLayoutPanel.Controls.Add(btnPlayPause, 1, 1);
            tableLayoutPanel.Controls.Add(btnNext, 2, 1);
            tableLayoutPanel.Controls.Add(btnStop, 0, 2);
            tableLayoutPanel.Controls.Add(btnAddSong, 1, 2);
            tableLayoutPanel.Controls.Add(btnClear, 2, 2);
            tableLayoutPanel.Controls.Add(lblSearch, 0, 3);
            tableLayoutPanel.Controls.Add(txtSearch, 1, 3);
            tableLayoutPanel.Controls.Add(lstPlaylist, 0, 4);
            tableLayoutPanel.Controls.Add(trackProgress, 0, 5);
            tableLayoutPanel.Controls.Add(trackVolume, 0, 6);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.Padding = new Padding(10);
            tableLayoutPanel.RowCount = 7;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 80F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            tableLayoutPanel.Size = new Size(841, 472);
            tableLayoutPanel.TabIndex = 0;
            // 
            // lblCurrentSong
            // 
            lblCurrentSong.AutoSize = true;
            tableLayoutPanel.SetColumnSpan(lblCurrentSong, 3);
            lblCurrentSong.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblCurrentSong.ForeColor = Color.White;
            lblCurrentSong.Location = new Point(13, 13);
            lblCurrentSong.Margin = new Padding(3, 3, 3, 0);
            lblCurrentSong.Name = "lblCurrentSong";
            lblCurrentSong.Size = new Size(248, 41);
            lblCurrentSong.TabIndex = 0;
            lblCurrentSong.Text = "Playlist is empty";
            lblCurrentSong.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.FromArgb(50, 50, 50);
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.Dock = DockStyle.Fill;
            btnPrev.FlatStyle = FlatStyle.Flat;
            btnPrev.Font = new Font("Segoe UI", 12F);
            btnPrev.ForeColor = Color.White;
            btnPrev.Location = new Point(13, 93);
            btnPrev.Name = "btnPrev";
            btnPrev.Size = new Size(264, 64);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "◀◀";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnPlayPause
            // 
            btnPlayPause.BackColor = Color.FromArgb(70, 70, 70);
            btnPlayPause.Cursor = Cursors.Hand;
            btnPlayPause.Dock = DockStyle.Fill;
            btnPlayPause.FlatStyle = FlatStyle.Flat;
            btnPlayPause.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnPlayPause.ForeColor = Color.White;
            btnPlayPause.Location = new Point(283, 93);
            btnPlayPause.Name = "btnPlayPause";
            btnPlayPause.Size = new Size(273, 64);
            btnPlayPause.TabIndex = 2;
            btnPlayPause.Text = "▶";
            btnPlayPause.UseVisualStyleBackColor = false;
            btnPlayPause.Click += btnPlayPause_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.FromArgb(50, 50, 50);
            btnNext.Cursor = Cursors.Hand;
            btnNext.Dock = DockStyle.Fill;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 12F);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(562, 93);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(266, 64);
            btnNext.TabIndex = 3;
            btnNext.Text = "▶▶";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // btnStop
            // 
            btnStop.BackColor = Color.FromArgb(50, 50, 50);
            btnStop.Cursor = Cursors.Hand;
            btnStop.Dock = DockStyle.Fill;
            btnStop.FlatStyle = FlatStyle.Flat;
            btnStop.Font = new Font("Segoe UI", 12F);
            btnStop.ForeColor = Color.White;
            btnStop.Location = new Point(13, 163);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(264, 64);
            btnStop.TabIndex = 4;
            btnStop.Text = "■";
            btnStop.UseVisualStyleBackColor = false;
            btnStop.Click += btnStop_Click;
            // 
            // btnAddSong
            // 
            btnAddSong.BackColor = Color.FromArgb(40, 40, 40);
            btnAddSong.Cursor = Cursors.Hand;
            btnAddSong.Dock = DockStyle.Fill;
            btnAddSong.FlatStyle = FlatStyle.Flat;
            btnAddSong.Font = new Font("Segoe UI", 10F);
            btnAddSong.ForeColor = Color.White;
            btnAddSong.Location = new Point(283, 163);
            btnAddSong.Name = "btnAddSong";
            btnAddSong.Size = new Size(273, 64);
            btnAddSong.TabIndex = 5;
            btnAddSong.Text = "➕ Add";
            btnAddSong.UseVisualStyleBackColor = false;
            btnAddSong.Click += btnAddSong_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(40, 40, 40);
            btnClear.Cursor = Cursors.Hand;
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 10F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(562, 163);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(266, 64);
            btnClear.TabIndex = 6;
            btnClear.Text = "🗑 Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.ForeColor = Color.White;
            lblSearch.Location = new Point(13, 240);
            lblSearch.Margin = new Padding(3, 10, 3, 0);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "Search:";
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.FromArgb(60, 60, 60);
            txtSearch.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(txtSearch, 2);
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.ForeColor = Color.White;
            txtSearch.Location = new Point(283, 240);
            txtSearch.Margin = new Padding(3, 10, 3, 0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(545, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lstPlaylist
            // 
            lstPlaylist.BackColor = Color.FromArgb(45, 45, 45);
            lstPlaylist.Columns.AddRange(new ColumnHeader[] { colTitle, colArtist });
            tableLayoutPanel.SetColumnSpan(lstPlaylist, 3);
            lstPlaylist.Dock = DockStyle.Fill;
            lstPlaylist.ForeColor = Color.White;
            lstPlaylist.FullRowSelect = true;
            lstPlaylist.Location = new Point(13, 273);
            lstPlaylist.Name = "lstPlaylist";
            lstPlaylist.Size = new Size(815, 106);
            lstPlaylist.TabIndex = 2;
            lstPlaylist.UseCompatibleStateImageBehavior = false;
            lstPlaylist.View = View.Details;
            lstPlaylist.DoubleClick += lstPlaylist_DoubleClick;
            // 
            // colTitle
            // 
            colTitle.Text = "Title";
            colTitle.Width = 450;
            // 
            // colArtist
            // 
            colArtist.Text = "Artist";
            colArtist.Width = 250;
            // 
            // trackProgress
            // 
            trackProgress.BackColor = Color.FromArgb(30, 30, 30);
            tableLayoutPanel.SetColumnSpan(trackProgress, 3);
            trackProgress.Dock = DockStyle.Fill;
            trackProgress.Enabled = false;
            trackProgress.Location = new Point(13, 385);
            trackProgress.Name = "trackProgress";
            trackProgress.Size = new Size(815, 34);
            trackProgress.TabIndex = 7;
            trackProgress.TickStyle = TickStyle.None;
            trackProgress.Scroll += trackProgress_Scroll;
            trackProgress.MouseUp += trackProgress_MouseUp;
            // 
            // trackVolume
            // 
            trackVolume.BackColor = Color.FromArgb(30, 30, 30);
            tableLayoutPanel.SetColumnSpan(trackVolume, 3);
            trackVolume.Dock = DockStyle.Fill;
            trackVolume.Location = new Point(13, 425);
            trackVolume.Maximum = 100;
            trackVolume.Name = "trackVolume";
            trackVolume.Size = new Size(815, 34);
            trackVolume.TabIndex = 8;
            trackVolume.TickFrequency = 10;
            trackVolume.Value = 80;
            trackVolume.Scroll += trackVolume_Scroll;
            // 
            // statusStrip
            // 
            statusStrip.BackColor = Color.FromArgb(30, 30, 30);
            statusStrip.ForeColor = Color.White;
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { lblStatus, separator, lblSongCount });
            statusStrip.Location = new Point(0, 446);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(841, 26);
            statusStrip.TabIndex = 3;
            statusStrip.Text = "statusStrip";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(50, 20);
            lblStatus.Text = "Ready";
            // 
            // separator
            // 
            separator.Name = "separator";
            separator.Size = new Size(6, 26);
            // 
            // lblSongCount
            // 
            lblSongCount.Name = "lblSongCount";
            lblSongCount.Size = new Size(59, 20);
            lblSongCount.Text = "0 songs";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(841, 472);
            Controls.Add(statusStrip);
            Controls.Add(tableLayoutPanel);
            Name = "Form1";
            Text = "Music Player";
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackProgress).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackVolume).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label lblCurrentSong;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnPlayPause;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnAddSong;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lstPlaylist;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colArtist;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripSeparator separator;
        private System.Windows.Forms.ToolStripStatusLabel lblSongCount;
        private System.Windows.Forms.TrackBar trackVolume;
        private System.Windows.Forms.TrackBar trackProgress;
    }
}