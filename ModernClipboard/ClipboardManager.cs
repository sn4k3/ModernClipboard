using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

        public int CurrentIndex { get; set; }

        /// <summary>
        /// Gets a list of the clipboard objects in memory
        /// </summary>

        /// <summary>
        /// Gets a list of the clipboard objects in memory
        /// </summary>
        public ListEx<ClipboardObject> ClipboardObjects { get; }

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

        /// <summary>
        /// Gets the item count into ClipboardObjects list
        /// </summary>
        public int Clips => ClipboardObjects.Count;

        /// <summary>
        /// Gets the item count into ClipboardObjects list
        /// </summary>
        public int Count => ClipboardObjects.Count;

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
            Start();
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

        #region Events

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

            CurrentIndex = 0;

            var item = Find(clipboardObject);
            if (item != null)
            {
                ClipboardObjects.Remove(clipboardObject);
                ClipboardObjects.Enqueue(clipboardObject);
            }
            else
            {
                ClipboardObjects.Enqueue(clipboardObject);
            }
            
            OnPropertyChanged(nameof(ClipboardObjects));

            LastClipboardObject = clipboardObject;
            SessionClips++;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region Methods

        public void Start() => ClipboardMonitor.Start();
        public void Stop() => ClipboardMonitor.Stop();

        public bool CanGoOldest()
        {
            return Count > 1 && CurrentIndex != 0;
        }

        public ClipboardObject GoOldest(bool peek = false)
        {
            if (!CanGoOldest())
                return null;

            if (peek)
                return ClipboardObjects[0];

            CurrentIndex = 0;
            return ClipboardObjects[CurrentIndex];
        }

        public bool CanGoBack()
        {
            return Count > 1 && CurrentIndex > 0;
        }

        public ClipboardObject GoBack(bool peek = false)
        {
            if (!CanGoBack())
                return null;

            if (peek)
                return ClipboardObjects[CurrentIndex-1];

            CurrentIndex--;
            return ClipboardObjects[CurrentIndex];
        }

        public bool CanGoForward()
        {
            return Count > 1 && CurrentIndex < Count-1;
        }

        public ClipboardObject GoForward(bool peek = false)
        {
            if (!CanGoForward())
                return null;

            if (peek)
                return ClipboardObjects[CurrentIndex + 1];

            CurrentIndex++;
            return ClipboardObjects[CurrentIndex];
        }

        public bool CanGoNewest()
        {
            return Count > 1 && CurrentIndex != Count - 1;
        }

        public ClipboardObject GoNewest(bool peek = false)
        {
            if (!CanGoNewest())
                return null;

            if (peek)
                return ClipboardObjects[Count - 1];

            CurrentIndex = Count - 1;
            return ClipboardObjects[CurrentIndex];
        }

        /// <summary>
        /// Find an clip matching a checksum
        /// </summary>
        /// <param name="Checksum">Checksum to find</param>
        /// <returns><see cref="ClipboardObject"/> or null</returns>
        public ClipboardObject Find(byte[] Checksum)
        {
            var result = ClipboardObjects.AsParallel().FirstOrDefault(clip => clip.Checksum.SequenceEqual(Checksum));
            return result;
        }

        /// <summary>
        /// Find an clip matching a checksum
        /// </summary>
        /// <param name="clipitem">Checksum to find</param>
        /// <returns><see cref="ClipboardObject"/> or null</returns>
        public ClipboardObject Find(ClipboardObject clipitem)
        {
            var result = ClipboardObjects.AsParallel().FirstOrDefault(clip => clip.Checksum.SequenceEqual(clipitem.Checksum));
            return result;
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
            Stop();
            Disposed = true;
            GC.SuppressFinalize(this);
        }
        #endregion

        
    }
}
