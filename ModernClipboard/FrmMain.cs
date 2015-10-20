using System;
using System.ComponentModel;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Gma.System.MouseKeyHook;

namespace ModernClipboard
{
    public partial class FrmMain : Form
    {
        #region Variables
        private IKeyboardMouseEvents m_GlobalHook;
        #endregion

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
            m_GlobalHook = Hook.GlobalEvents();
            m_GlobalHook.KeyDown += GlobalHookKeyDown;

            Disposed += (sender, args) =>
            {
                m_GlobalHook.Dispose();
                ClipboardManager.Instance.Dispose();
            };

           
        }



        #endregion

        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClipboardManager.Instance.Init();
            ClipboardManager.Instance.PropertyChanged += ClipboardManager_OnPropertyChanged;
            lbClips.DataSource = ClipboardManager.Instance.ClipboardObjects;
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
        private void GlobalHookKeyDown(object sender, KeyEventArgs e)
        {
            
        }

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
                /*lbClips.BeginUpdate();

                lbClips.Items.Insert(0, ClipboardManager.Instance.LastClipboardObject);
                lbClips.SelectedIndex = 0;

                lbClips.EndUpdate();*/
                lbClips.DataSource = null;
                lbClips.DataSource = ClipboardManager.Instance.ClipboardObjects;
                if(ClipboardManager.Instance.ClipboardObjects.Count > 0)
                    lbClips.SelectedIndex = 0;

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

                //statusClips.Text = $"Total of {ClipboardManager.Instance.Count} clips and {ClipboardManager.Instance.SessionClips} for this session";
                statusClips.Text = $"Clips: {ClipboardManager.Instance.Count}";

                return;
            }
        }

        private void lbClips_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = lbClips.SelectedItem as ClipboardObject;
            if (item == null)
                return;

            ClipboardManager.Instance.CurrentIndex = lbClips.Items.Count - 1 - lbClips.SelectedIndex;

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
            if (sender == mainMenuExit || sender == cmNotifyExit)
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

            toolbarOldest.Enabled =
            cmNotifyOldest.Enabled = ClipboardManager.Instance.CanGoOldest();
            cmNotifyOldest.Text = $"&Oldest{(cmNotifyOldest.Enabled ? $" - {ClipboardManager.Instance.GoOldest(true).Key}" : string.Empty)}";

            toolbarBack.Enabled =
            cmNotifyBack.Enabled = ClipboardManager.Instance.CanGoBack();
            cmNotifyBack.Text = $"&Back{(cmNotifyBack.Enabled ? $" - {ClipboardManager.Instance.GoBack(true).Key}" : string.Empty)}";

            toolbarForward.Enabled =
            cmNotifyForward.Enabled = ClipboardManager.Instance.CanGoForward();
            cmNotifyForward.Text = $"&Forward{(cmNotifyForward.Enabled ? $" - {ClipboardManager.Instance.GoForward(true).Key}" : string.Empty)}";

            toolbarNewest.Enabled =
            cmNotifyNewest.Enabled = ClipboardManager.Instance.CanGoNewest();
            cmNotifyNewest.Text = $"&Newest{(cmNotifyNewest.Enabled ? $" - {ClipboardManager.Instance.GoNewest(true).Key}" : string.Empty)}";
        }
        #endregion

        private void OnMouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (sender == lbClips)
            {
                if (e.Button != MouseButtons.Left) return;

                var clip = lbClips.SelectedItem as ClipboardObject;
                if (clip == null) return;

                DataObject m_data = new DataObject();
                //m_data.SetData(DataFormats.Text, true, textBox1.Text);
                //m_data.SetData(DataFormats.Bitmap, true, pictureBox1.Image);
                m_data.SetData(clip.Format.ToString(), true, clip.Data);
                Clipboard.SetDataObject(m_data, true);

                return;
            }
        }
    }
}
