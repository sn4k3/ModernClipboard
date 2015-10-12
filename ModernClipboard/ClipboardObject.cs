using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ModernClipboard
{
    public sealed class ClipboardObject
    {
        /// <summary>
        /// Gets the ClipboardFormat
        /// </summary>
        public ClipboardFormat Format { get; }

        /// <summary>
        /// Gets the clipboard data
        /// </summary>
        public object Data { get; }

        public string Key { get; }

        public string Text { get; }

        public DateTime ClipDateTime { get; }

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="format"></param>
        /// <param name="data"></param>
        public ClipboardObject(ClipboardFormat format, object data)
        {
            Format = format;
            Data = data;
            ClipDateTime = DateTime.Now;

            var text = data as string;
            if (text != null)
            {
                Key = $"Text[{text.Length}]";
                return;
            }

            var strings = data as string[];
            if (strings != null)
            {
                Key = $"Strings[{strings.LongLength}]";
                if (strings.LongLength > 0)
                {
                    Text = $"\"{string.Join("\",\n\"", strings)}\"";
                }
                return;
            }
            var bitmaps = data as Bitmap;
            if (bitmaps != null)
            {
                
                Key = $"Bitmap[{bitmaps.Size.Width}x{bitmaps.Size.Height}]";
                return;
            }
        }

        #endregion

        #region Equality Compare
        private bool Equals(ClipboardObject other)
        {
            if (Format == other.Format && Equals(Data, other.Data))
            {
                return true;
            }

            if (Data.GetType() != other.Data.GetType() || !Equals(Key, other.Key))
                return false;

            var strings = other.Data as string[];
            if (strings != null)
            {
                var thisData = (string[])Data;
                var otherData = strings;

                if (thisData.LongLength != otherData.LongLength)
                    return false;

                for (var i = 0; i < thisData.LongLength; i++)
                {
                    if (!Equals(thisData[i], otherData[i]))
                        return false;
                }

                return true;
            }

            var bitmaps = other.Data as Bitmap;
            if (bitmaps != null)
            {
                var thisData = (Bitmap)Data;
                var otherData = bitmaps;

                try
                {
                    if ((thisData.Width != otherData.Width && thisData.Height != otherData.Height) || thisData.PixelFormat != otherData.PixelFormat)
                        return false;
                }
                catch (Exception)
                {

                    return false;
                }
                


                return false;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj is ClipboardObject && Equals((ClipboardObject) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((int) Format*397) ^ (Data?.GetHashCode() ?? 0);
            }
        }
        #endregion

        #region Overrides
        /// <summary>
        /// ToString representation
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Format}=>{Key}";
        }
        #endregion
    }
}
