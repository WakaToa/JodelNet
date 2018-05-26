using System.Net.Security;

namespace JodelNet.Verification.Extensions
{
    public static class SslStreamExtensions
    {
        public static int Read(this SslStream stream)
        {
            var b = new byte[1];

            stream.Read(b, 0, 1);

            return b[0];
        }

        public static int Read(this SslStream stream, byte[] b, int off, int len)
        {
            return stream.Read(b, off, len);
        }

        public static void Write(this SslStream stream, byte[] b)
        {
            stream.Write(b);
        }

        public static void Write(this SslStream stream, int b)
        {
            stream.Write(new [] {(byte)b});
        }
    }
}
