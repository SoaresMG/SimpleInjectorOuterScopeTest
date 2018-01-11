using System.IO;

namespace Connector.SDK.Extensions
{
    /// <summary>
    /// Extensions or helpers for streams
    /// </summary>
    public static class StreamExtensions
    {
        public static byte[] ToByteArray(this Stream stream)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                stream.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}