namespace ModernClipboard
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.lbClips = new System.Windows.Forms.ListBox();
            this.tbData = new System.Windows.Forms.RichTextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmNotify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmNotifyOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cmNotifyNavigation = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotifyOldest = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotifyBack = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotifyForward = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotifyNewest = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmNotifyClips = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotifyExit = new System.Windows.Forms.ToolStripMenuItem();
            this.pbBitmap = new System.Windows.Forms.PictureBox();
            this.cmNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).BeginInit();
            this.SuspendLayout();
            // 
            // lbClips
            // 
            this.lbClips.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbClips.FormattingEnabled = true;
            this.lbClips.Location = new System.Drawing.Point(0, 0);
            this.lbClips.Name = "lbClips";
            this.lbClips.Size = new System.Drawing.Size(269, 552);
            this.lbClips.TabIndex = 0;
            this.lbClips.SelectedIndexChanged += new System.EventHandler(this.lbClips_SelectedIndexChanged);
            // 
            // tbData
            // 
            this.tbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbData.Location = new System.Drawing.Point(269, 0);
            this.tbData.Name = "tbData";
            this.tbData.ReadOnly = true;
            this.tbData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.tbData.Size = new System.Drawing.Size(725, 552);
            this.tbData.TabIndex = 1;
            this.tbData.Text = "";
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmNotify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Modern Clipboard";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.Clicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // cmNotify
            // 
            this.cmNotify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmNotifyOpen,
            this.toolStripSeparator2,
            this.cmNotifyNavigation,
            this.cmNotifyOldest,
            this.cmNotifyBack,
            this.cmNotifyForward,
            this.cmNotifyNewest,
            this.toolStripSeparator1,
            this.cmNotifyClips,
            this.cmNotifyExit});
            this.cmNotify.Name = "cmNotify";
            this.cmNotify.Size = new System.Drawing.Size(133, 192);
            // 
            // cmNotifyOpen
            // 
            this.cmNotifyOpen.Image = global::ModernClipboard.Properties.Resources.window16x16;
            this.cmNotifyOpen.Name = "cmNotifyOpen";
            this.cmNotifyOpen.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyOpen.Text = "&Show";
            this.cmNotifyOpen.Click += new System.EventHandler(this.Clicked);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(129, 6);
            // 
            // cmNotifyNavigation
            // 
            this.cmNotifyNavigation.Image = global::ModernClipboard.Properties.Resources.clipboard16x16;
            this.cmNotifyNavigation.Name = "cmNotifyNavigation";
            this.cmNotifyNavigation.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyNavigation.Text = "Navigation";
            // 
            // cmNotifyOldest
            // 
            this.cmNotifyOldest.Image = global::ModernClipboard.Properties.Resources.first16x16;
            this.cmNotifyOldest.Name = "cmNotifyOldest";
            this.cmNotifyOldest.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyOldest.Text = "&Oldest";
            // 
            // cmNotifyBack
            // 
            this.cmNotifyBack.Image = global::ModernClipboard.Properties.Resources.back16x16;
            this.cmNotifyBack.Name = "cmNotifyBack";
            this.cmNotifyBack.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyBack.Text = "&Back";
            // 
            // cmNotifyForward
            // 
            this.cmNotifyForward.Image = global::ModernClipboard.Properties.Resources.forward16x16;
            this.cmNotifyForward.Name = "cmNotifyForward";
            this.cmNotifyForward.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyForward.Text = "&Forward";
            // 
            // cmNotifyNewest
            // 
            this.cmNotifyNewest.Image = global::ModernClipboard.Properties.Resources.last16x16;
            this.cmNotifyNewest.Name = "cmNotifyNewest";
            this.cmNotifyNewest.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyNewest.Text = "&Newest";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(129, 6);
            // 
            // cmNotifyClips
            // 
            this.cmNotifyClips.Enabled = false;
            this.cmNotifyClips.Image = global::ModernClipboard.Properties.Resources.clip16x16;
            this.cmNotifyClips.Name = "cmNotifyClips";
            this.cmNotifyClips.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyClips.Text = "Clips: 0";
            this.cmNotifyClips.Visible = false;
            // 
            // cmNotifyExit
            // 
            this.cmNotifyExit.Image = global::ModernClipboard.Properties.Resources.exit16x16;
            this.cmNotifyExit.Name = "cmNotifyExit";
            this.cmNotifyExit.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyExit.Text = "&Exit";
            this.cmNotifyExit.Click += new System.EventHandler(this.Clicked);
            // 
            // pbBitmap
            // 
            this.pbBitmap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbBitmap.Location = new System.Drawing.Point(269, 0);
            this.pbBitmap.Name = "pbBitmap";
            this.pbBitmap.Size = new System.Drawing.Size(725, 552);
            this.pbBitmap.TabIndex = 2;
            this.pbBitmap.TabStop = false;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 552);
            this.Controls.Add(this.pbBitmap);
            this.Controls.Add(this.tbData);
            this.Controls.Add(this.lbClips);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmMain";
            this.Text = "Modern Clipboard";
            this.cmNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbClips;
        private System.Windows.Forms.RichTextBox tbData;
        private System.Windows.Forms.PictureBox pbBitmap;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmNotify;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyOpen;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyOldest;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyBack;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyForward;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyNewest;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyNavigation;
        private System.Windows.Forms.ToolStripMenuItem cmNotifyClips;
    }
}

