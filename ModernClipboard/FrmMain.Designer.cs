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
            this.panelMain = new System.Windows.Forms.Panel();
            this.statusBar = new System.Windows.Forms.StatusStrip();
            this.statusClips = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.toolbarOldest = new System.Windows.Forms.ToolStripButton();
            this.toolbarBack = new System.Windows.Forms.ToolStripButton();
            this.toolbarForward = new System.Windows.Forms.ToolStripButton();
            this.toolbarNewest = new System.Windows.Forms.ToolStripButton();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.mainMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmNotify.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).BeginInit();
            this.panelMain.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.toolbar.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbClips
            // 
            this.lbClips.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbClips.FormattingEnabled = true;
            this.lbClips.Location = new System.Drawing.Point(0, 0);
            this.lbClips.Name = "lbClips";
            this.lbClips.Size = new System.Drawing.Size(192, 481);
            this.lbClips.TabIndex = 0;
            this.lbClips.SelectedIndexChanged += new System.EventHandler(this.lbClips_SelectedIndexChanged);
            this.lbClips.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseDoubleClick);
            // 
            // tbData
            // 
            this.tbData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbData.Location = new System.Drawing.Point(192, 0);
            this.tbData.Name = "tbData";
            this.tbData.ReadOnly = true;
            this.tbData.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth;
            this.tbData.Size = new System.Drawing.Size(802, 481);
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
            this.cmNotifyOldest.Click += new System.EventHandler(this.Clicked);
            // 
            // cmNotifyBack
            // 
            this.cmNotifyBack.Image = global::ModernClipboard.Properties.Resources.back16x16;
            this.cmNotifyBack.Name = "cmNotifyBack";
            this.cmNotifyBack.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyBack.Text = "&Back";
            this.cmNotifyBack.Click += new System.EventHandler(this.Clicked);
            // 
            // cmNotifyForward
            // 
            this.cmNotifyForward.Image = global::ModernClipboard.Properties.Resources.forward16x16;
            this.cmNotifyForward.Name = "cmNotifyForward";
            this.cmNotifyForward.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyForward.Text = "&Forward";
            this.cmNotifyForward.Click += new System.EventHandler(this.Clicked);
            // 
            // cmNotifyNewest
            // 
            this.cmNotifyNewest.Image = global::ModernClipboard.Properties.Resources.last16x16;
            this.cmNotifyNewest.Name = "cmNotifyNewest";
            this.cmNotifyNewest.Size = new System.Drawing.Size(132, 22);
            this.cmNotifyNewest.Text = "&Newest";
            this.cmNotifyNewest.Click += new System.EventHandler(this.Clicked);
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
            this.pbBitmap.Location = new System.Drawing.Point(192, 0);
            this.pbBitmap.Name = "pbBitmap";
            this.pbBitmap.Size = new System.Drawing.Size(802, 481);
            this.pbBitmap.TabIndex = 2;
            this.pbBitmap.TabStop = false;
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.pbBitmap);
            this.panelMain.Controls.Add(this.tbData);
            this.panelMain.Controls.Add(this.lbClips);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 49);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(994, 481);
            this.panelMain.TabIndex = 3;
            // 
            // statusBar
            // 
            this.statusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusClips});
            this.statusBar.Location = new System.Drawing.Point(0, 530);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(994, 22);
            this.statusBar.SizingGrip = false;
            this.statusBar.TabIndex = 4;
            this.statusBar.Text = "Status Bar";
            // 
            // statusClips
            // 
            this.statusClips.Name = "statusClips";
            this.statusClips.Size = new System.Drawing.Size(45, 17);
            this.statusClips.Text = "Clips: 0";
            // 
            // toolbar
            // 
            this.toolbar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbarOldest,
            this.toolbarBack,
            this.toolbarForward,
            this.toolbarNewest});
            this.toolbar.Location = new System.Drawing.Point(0, 24);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(994, 25);
            this.toolbar.TabIndex = 5;
            this.toolbar.Text = "Toolbar";
            // 
            // toolbarOldest
            // 
            this.toolbarOldest.Image = global::ModernClipboard.Properties.Resources.first16x16;
            this.toolbarOldest.Name = "toolbarOldest";
            this.toolbarOldest.Size = new System.Drawing.Size(61, 22);
            this.toolbarOldest.Text = "&Oldest";
            this.toolbarOldest.ToolTipText = "Go to Oldest clip";
            this.toolbarOldest.Click += new System.EventHandler(this.Clicked);
            // 
            // toolbarBack
            // 
            this.toolbarBack.Image = global::ModernClipboard.Properties.Resources.back16x16;
            this.toolbarBack.Name = "toolbarBack";
            this.toolbarBack.Size = new System.Drawing.Size(52, 22);
            this.toolbarBack.Text = "&Back";
            this.toolbarBack.ToolTipText = "Go to Previous clip";
            this.toolbarBack.Click += new System.EventHandler(this.Clicked);
            // 
            // toolbarForward
            // 
            this.toolbarForward.Image = global::ModernClipboard.Properties.Resources.forward16x16;
            this.toolbarForward.Name = "toolbarForward";
            this.toolbarForward.Size = new System.Drawing.Size(70, 22);
            this.toolbarForward.Text = "&Forward";
            this.toolbarForward.ToolTipText = "Go to Forward clip";
            this.toolbarForward.Click += new System.EventHandler(this.Clicked);
            // 
            // toolbarNewest
            // 
            this.toolbarNewest.Image = global::ModernClipboard.Properties.Resources.last16x16;
            this.toolbarNewest.Name = "toolbarNewest";
            this.toolbarNewest.Size = new System.Drawing.Size(66, 22);
            this.toolbarNewest.Text = "&Newest";
            this.toolbarNewest.ToolTipText = "Go to Newest clip";
            this.toolbarNewest.Click += new System.EventHandler(this.Clicked);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuFile,
            this.mainMenuHelp});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(994, 24);
            this.mainMenu.TabIndex = 6;
            this.mainMenu.Text = "menuStrip1";
            // 
            // mainMenuFile
            // 
            this.mainMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainMenuExit});
            this.mainMenuFile.Name = "mainMenuFile";
            this.mainMenuFile.Size = new System.Drawing.Size(37, 20);
            this.mainMenuFile.Text = "&File";
            // 
            // mainMenuExit
            // 
            this.mainMenuExit.Image = global::ModernClipboard.Properties.Resources.exit16x16;
            this.mainMenuExit.Name = "mainMenuExit";
            this.mainMenuExit.Size = new System.Drawing.Size(92, 22);
            this.mainMenuExit.Text = "&Exit";
            this.mainMenuExit.Click += new System.EventHandler(this.Clicked);
            // 
            // mainMenuHelp
            // 
            this.mainMenuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.mainMenuHelp.Name = "mainMenuHelp";
            this.mainMenuHelp.Size = new System.Drawing.Size(44, 20);
            this.mainMenuHelp.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 552);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.toolbar);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FrmMain";
            this.Text = "Modern Clipboard";
            this.cmNotify.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbBitmap)).EndInit();
            this.panelMain.ResumeLayout(false);
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.StatusStrip statusBar;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem mainMenuFile;
        private System.Windows.Forms.ToolStripButton toolbarOldest;
        private System.Windows.Forms.ToolStripButton toolbarBack;
        private System.Windows.Forms.ToolStripButton toolbarForward;
        private System.Windows.Forms.ToolStripButton toolbarNewest;
        private System.Windows.Forms.ToolStripMenuItem mainMenuExit;
        private System.Windows.Forms.ToolStripMenuItem mainMenuHelp;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel statusClips;
    }
}

