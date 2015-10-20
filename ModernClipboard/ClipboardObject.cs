using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
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

        public byte[] Checksum { get; }

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
                Checksum = ChecksumMD5.ComputeChecksum(text);
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
                Checksum = ChecksumMD5.ComputeChecksum(strings);
                return;
            }
            var bitmap = data as Bitmap;
            if (bitmap != null)
            {
                
                Key = $"Bitmap[{bitmap.Size.Width}x{bitmap.Size.Height}]";
                Checksum = ChecksumMD5.ComputeChecksum(bitmap);
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

            if (Checksum != null && other.Checksum != null)
            {
                if (Checksum.LongLength != other.Checksum.LongLength)
                    return false;

                if (Checksum.SequenceEqual(other.Checksum))
                    return true;
            }

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
                    if (thisData.Size != otherData.Size || thisData.PixelFormat != otherData.PixelFormat)
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
            return $"{Format} => {Key}";
        }
        #endregion
    }
}
