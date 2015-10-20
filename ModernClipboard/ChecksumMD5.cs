using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ModernClipboard
{
    public static class ChecksumMD5
    {
        /// <summary>
        /// Gets a byte array from a string.
        /// </summary>
        /// <param name="str">String to convert into byte[]</param>
        /// <returns>A byte array from a string</returns>
        public static byte[] GetBytes(string str)
        {
            var bytes = new byte[str.Length * sizeof(char)];
            Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        /// <summary>
        /// Gets a string from a byte array.
        /// </summary>
        /// <param name="bytes">byte[] to convert into a string</param>
        /// <returns>A string from a byte array.</returns>
        public static string GetString(byte[] bytes)
        {
            var chars = new char[bytes.Length / sizeof(char)];
            Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

        /// <summary>
        /// Compute a MD5 checksum from a byte array
        /// </summary>
        /// <param name="buffer">Byte array to compute</param>
        /// <returns>Hashed checksum</returns>
        public static byte[] ComputeChecksum(byte[] buffer)
        {
            using (var md5 = MD5.Create())
            {
                return md5.ComputeHash(buffer);
            }
        }

        /// <summary>
        /// Compute a MD5 checksum from a string
        /// </summary>
        /// <param name="text">String to compute</param>
        /// <returns>Hashed checksum</returns>
        public static byte[] ComputeChecksum(string text)
        {
            return ComputeChecksum(GetBytes(text));
        }

        /// <summary>
        /// Compute a MD5 checksum from a string
        /// </summary>
        /// <param name="strings">String to compute</param>
        /// <returns>Hashed checksum</returns>
        public static byte[] ComputeChecksum(string[] strings)
        {
            return ComputeChecksum(GetBytes(strings.Aggregate(string.Empty, (current, s) => current + s)));
        }

        /// <summary>
        /// Compute a MD5 checksum from a string builder
        /// </summary>
        /// <param name="sb">Stringbuilder to compute</param>
        /// <returns>Hashed checksum</returns>
        public static byte[] ComputeChecksum(StringBuilder sb)
        {
            return ComputeChecksum(GetBytes(sb.ToString()));
        }

        /// <summary>
        /// Compute a MD5 checksum from a bitmap
        /// </summary>
        /// <param name="bitmap">Bitmap to compute</param>
        /// <returns>Hashed checksum</returns>
        public static byte[] ComputeChecksum(Bitmap bitmap)
        {
            //Convert each image to a byte array
            var ic = new ImageConverter();
            var ics = new byte[2];
            var bytes = (byte[])ic.ConvertTo(bitmap, ics.GetType());
            
            //LockBitmap lockBitmap = new LockBitmap(bitmap);
            //lockBitmap.LockBits();
            //lockBitmap.UnlockBits();
            return ComputeChecksum(bytes);
        }
    }
}
