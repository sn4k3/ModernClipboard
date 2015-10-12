using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using ModernClipboard.Annotations;

namespace ModernClipboard
{
    public sealed class ClipboardManager : IDisposable, INotifyPropertyChanged
    {
        #region Properties
        /// <summary>
        /// Gets if the object is disposed
        /// </summary>
        public bool Disposed { get; private set; }

        /// <summary>
        /// Gets a list of the clipboard objects in memory
        /// </summary>

        /// <summary>
        /// Gets a list of the clipboard objects in memory
        /// </summary>
        public ListEx<ClipboardObject> ClipboardObjects { get; private set; }

        /// <summary>
        /// Gets the currently clipboard object in memory
        /// </summary>
        private ClipboardObject _lastClipboardObject = null;

        /// <summary>
        /// Gets the currently clipboard object in memory
        /// </summary>
        public ClipboardObject LastClipboardObject
        {
                    get { return _lastClipboardObject; }
            private set { _lastClipboardObject = value; OnPropertyChanged(); }
        }

        /// <summary>
        /// Gets the total clips count collected in this session
        /// </summary>
        private ulong _sessionClips;

        /// <summary>
        /// Gets the total clips count collected in this session
        /// </summary>
        public ulong SessionClips
        {
                    get { return _sessionClips; }
            private set { _sessionClips = value; OnPropertyChanged(); }
        }
        #endregion

        #region Singleton
        /// <summary>
        /// This class instance for singleton
        /// </summary>
        private static ClipboardManager _instance = null;
        public static ClipboardManager Instance
        {
            get
            {
                if (ReferenceEquals(_instance, null))
                {
                    _instance = new ClipboardManager();
                }
                return _instance;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor, Clipboard will be hooked after this call
        /// </summary>
        private ClipboardManager()
        {
            ClipboardObjects = new ListEx<ClipboardObject>();
            ClipboardMonitor.OnClipboardChange += ClipboardMonitor_OnClipboardChange;
            ClipboardMonitor.Start();
        }

        // Finalizer simply calls Dispose(false)
        ~ClipboardManager()
        {
            Dispose();
        }

        /// <summary>
        /// Init the class and hook the clipboard
        /// </summary>
        public void Init() {}
        #endregion

        #region Methods
        /// <summary>
        /// Clipboard has changed - event
        /// </summary>
        /// <param name="format">Data format</param>
        /// <param name="data">Data object</param>
        private void ClipboardMonitor_OnClipboardChange(ClipboardFormat format, object data)
        {
            var clipboardObject = new ClipboardObject(format, data);
            if (LastClipboardObject != null && LastClipboardObject.Equals(clipboardObject))
                return; // Same clipboard as the last one, ignoring!
            

            ClipboardObjects.Add(clipboardObject);
            OnPropertyChanged(nameof(ClipboardObjects));

            LastClipboardObject = clipboardObject;
            SessionClips++;

            MessageBox.Show(LastClipboardObject.ToString());
        }
        #endregion

        #region Dispose
        /// <summary>
        /// Release and free all objects from memory within this class
        /// </summary>
        public void Dispose()
        {
            if (Disposed)
                return;
            ClipboardMonitor.Stop();
            Disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion

        #region events
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
