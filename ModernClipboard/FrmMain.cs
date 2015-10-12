using System;
using System.Windows.Forms;

namespace ModernClipboard
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            Disposed += (sender, args) => ClipboardManager.Instance.Dispose();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            ClipboardManager.Instance.Init();
        }

        

    }
}
