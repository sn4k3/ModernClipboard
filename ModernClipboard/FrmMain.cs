using System;
using System.Windows.Forms;

namespace ModernClipboard
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Disposed += (sender, args) => ClipboardMonitor.Stop();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;
            ClipboardMonitor.Start();
        }

        
        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data)
        {
            MessageBox.Show($"{format}\n{data}");

        }
    }
}
