using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ModernClipboard
{
    public static class ClipboardMonitor
    {
        public static bool IsStarted => ClipboardWatcher.IsStarted;
        public static bool IsPaused {
            get { return ClipboardWatcher.IsPaused;  }
            set { ClipboardWatcher.IsPaused = value; }
        }
        public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);
        public static event OnClipboardChangeEventHandler OnClipboardChange;

        public static void Start()
        {
            ClipboardWatcher.Start();
            ClipboardWatcher.OnClipboardChange += (format, data) =>
            {
                OnClipboardChange?.Invoke(format, data);
            };
        }

        public static void Stop()
        {
            OnClipboardChange = null;
            ClipboardWatcher.Stop();
        }

        class ClipboardWatcher : Form
        {
            public static bool IsStarted => _mInstance != null;
            public static bool IsPaused { get; set; }

            // static instance of this form
            private static ClipboardWatcher _mInstance;

            // needed to dispose this form
            static IntPtr _nextClipboardViewer;

            public delegate void OnClipboardChangeEventHandler(ClipboardFormat format, object data);
            public static event OnClipboardChangeEventHandler OnClipboardChange;

            // start listening
            public static void Start()
            {
                // we can only have one instance if this class
                if (_mInstance != null)
                    return;

                var t = new Thread(x => Application.Run(new ClipboardWatcher()));
                t.SetApartmentState(ApartmentState.STA); // give the [STAThread] attribute
                t.Start();
            }

            // stop listening (dispose form)
            public static void Stop()
            {
                _mInstance.Invoke(new MethodInvoker(() =>
                {
                    ChangeClipboardChain(_mInstance.Handle, _nextClipboardViewer);
                }));
                _mInstance.Invoke(new MethodInvoker(_mInstance.Close));

                _mInstance.Dispose();

                _mInstance = null;
            }

            // on load: (hide this window)
            protected override void SetVisibleCore(bool value)
            {
                CreateHandle();

                _mInstance = this;

                _nextClipboardViewer = SetClipboardViewer(_mInstance.Handle);

                base.SetVisibleCore(false);
            }

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            private static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

            [DllImport("User32.dll", CharSet = CharSet.Auto)]
            private static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

            /*[DllImport("user32.dll")]
            private static extern bool OpenClipboard(IntPtr hWndNewOwner);

            [DllImport("user32.dll")]
            static extern bool EmptyClipboard();

            [DllImport("user32.dll")]
            private static extern bool CloseClipboard();

            [DllImport("user32.dll")]
            private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);*/

            // defined in winuser.h
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            protected override void WndProc(ref Message m)
            {
                switch (m.Msg)
                {
                    case WM_DRAWCLIPBOARD:
                        ClipChanged();
                        SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                        break;

                    case WM_CHANGECBCHAIN:
                        if (m.WParam == _nextClipboardViewer)
                            _nextClipboardViewer = m.LParam;
                        else
                            SendMessage(_nextClipboardViewer, m.Msg, m.WParam, m.LParam);
                        break;

                    default:
                        base.WndProc(ref m);
                        break;
                }
            }

            static readonly string[] Formats = Enum.GetNames(typeof(ClipboardFormat));

            private void ClipChanged()
            {
                if (IsPaused) return;

                IDataObject iData = Clipboard.GetDataObject();

                ClipboardFormat? format = null;

                foreach (var f in Formats)
                {
                    if (!iData.GetDataPresent(f)) continue;
                    format = (ClipboardFormat)Enum.Parse(typeof(ClipboardFormat), f);
                    break;
                }

                object data = iData.GetData(format.ToString());

                if (data == null || format == null)
                    return;

                OnClipboardChange?.Invoke((ClipboardFormat)format, data);
            }
        }
    }
}