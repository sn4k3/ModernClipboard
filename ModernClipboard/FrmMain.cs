using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

namespace ModernClipboard
{
    public partial class FrmMain : Form
    {
        #region Properties
        /// <summary>
        /// Gets if form can be closed, if false form will be hidden
        /// </summary>
        private bool CanClose { get; set; }

        private int SelectedDropDownNavigationClip { get; set; } = -1;
        #endregion

        #region Construtor
        public FrmMain()
        {
            InitializeComponent();
            Disposed += (sender, args) => ClipboardManager.Instance.Dispose();
        }
        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClipboardManager.Instance.Init();
            ClipboardManager.Instance.PropertyChanged += ClipboardManager_OnPropertyChanged;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!CanClose)
            {
                Hide();
                e.Cancel = true;
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (pbBitmap.Visible)
            {
                try
                {
                    if (pbBitmap.Width < pbBitmap.Image.Width || pbBitmap.Height < pbBitmap.Image.Height)
                    {
                        pbBitmap.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbBitmap.SizeMode = PictureBoxSizeMode.Normal;
                    }
                }
                catch (Exception)
                {
                    // ignored
                }
            }
        }
        #endregion

        #region Events

        private void ClipboardManager_OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (InvokeRequired)
            {
                Invoke(new Action<object, PropertyChangedEventArgs>(ClipboardManager_OnPropertyChanged), sender, e);
                return;
            }

            if (e.PropertyName.Equals("SessionClips"))
            {
                var lastSelectedIndex = lbClips.SelectedIndex;
                lbClips.BeginUpdate();

                lbClips.Items.Insert(0, ClipboardManager.Instance.LastClipboardObject);
                lbClips.SelectedIndex = 0;

                lbClips.EndUpdate();

                ToolStripMenuItem item = new ToolStripMenuItem(ClipboardManager.Instance.LastClipboardObject.ToString())
                {
                    Tag = ClipboardManager.Instance.LastClipboardObject,
                    Checked = true
                };
                if (SelectedDropDownNavigationClip != -1)
                    ((ToolStripMenuItem)cmNotifyNavigation.DropDownItems[SelectedDropDownNavigationClip]).Checked = false;
                cmNotifyNavigation.DropDownItems.Insert(0, item);
                SelectedDropDownNavigationClip = 0;



                if (ClipboardManager.Instance.Count == 1)
                {
                    cmNotifyOldest.Text = $"&Oldest - {ClipboardManager.Instance.LastClipboardObject.Key}";
                }
                else if (ClipboardManager.Instance.Count > 1)
                {
                    cmNotifyBack.Text = $"&Back - {ClipboardManager.Instance.GoBack(true)?.Key}";
                }
                cmNotifyNewest.Text = $"&Newest - {ClipboardManager.Instance.LastClipboardObject.Key}";
                cmNotifyNavigation.Text = $"Navigation ({ClipboardManager.Instance.Count})";
                cmNotifyClips.Text = $"Clips: {ClipboardManager.Instance.Count}";
                
                return;
            }
        }

        private void lbClips_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lbClips.SelectedItem as ClipboardObject;
            if (item == null)
                return;

            UpdateButtonVisibility();

            if (item.Format == ClipboardFormat.Bitmap)
            {
                pbBitmap.Image = (Bitmap)item.Data;
                pbBitmap.Visible = true;
                tbData.Visible = false;
                
                OnResize(null);
                return;
            }

            if (pbBitmap.Visible)
            {
                pbBitmap.Visible = false;
                tbData.Visible = true;
                pbBitmap.Image = pbBitmap.InitialImage;
            }

            tbData.Text = string.IsNullOrEmpty(item.Text) ? item.Data.ToString() : item.Text;
        }

        private void Clicked(object sender, EventArgs e)
        {
            if (sender == cmNotifyOpen)
            {
                ShowMe();
                return;
            }
            if (sender == cmNotifyExit)
            {
                CanClose = true;
                Close();
                return;
            }
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowMe();
                return;
            }

            if (e.Button == MouseButtons.Middle)
            {
                MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu",
                BindingFlags.Instance | BindingFlags.NonPublic);

                methodInfo.Invoke(notifyIcon, null);

                cmNotifyNavigation.Select();
                cmNotifyNavigation.ShowDropDown();
                return;
            }
        }
        #endregion

        #region Methods
        public void ShowMe()
        {
            Show();
            WindowState = FormWindowState.Normal;
        }

        public void UpdateButtonVisibility()
        {
            cmNotifyNavigation.Enabled = ClipboardManager.Instance.Count > 0;

            cmNotifyOldest.Enabled = ClipboardManager.Instance.CanGoOldest();
            cmNotifyBack.Enabled = ClipboardManager.Instance.CanGoBack();
            cmNotifyForward.Enabled = ClipboardManager.Instance.CanGoForward();
            cmNotifyNewest.Enabled = ClipboardManager.Instance.CanGoNewest();
        }
        #endregion
    }
}
