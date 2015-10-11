namespace ModernClipboard
{
    public sealed class ClipboardData
    {
        /// <summary>
        /// Gets the ClipboardFormat
        /// </summary>
        public ClipboardFormat Format { get; private set; }

        /// <summary>
        /// Gets the clipboard data
        /// </summary>
        public object Data { get; private set; }

        public ClipboardData(ClipboardFormat format, object data)
        {
            Format = format;
            Data = data;
        }
    }
}
