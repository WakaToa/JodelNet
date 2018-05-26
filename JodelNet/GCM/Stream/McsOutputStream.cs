using System.Net.Security;
using JodelNet.GCM.Extensions;
using JodelNet.GCM.Proto;

namespace JodelNet.GCM.Stream
{
    //https://github.com/microg/android_packages_apps_GmsCore/blob/93c3cbb31be6c8ffae81c18e551cb00c74aaaaf4/play-services-core/src/main/java/org/microg/gms/gcm/mcs/McsOutputStream.java
    public class McsOutputStream
    {
        private readonly SslStream _stream;
        private bool _initialized;
        private readonly int _version = (int)MCSToken.MCS_VERSION_CODE;

        public McsOutputStream(SslStream os, bool initialized)
        {
            _stream = os;
            _initialized = initialized;
        }

        public McsOutputStream(SslStream os) : this(os, false)
        {
            
        }

        public void WriteProtoMessage(int tag, byte[] message)
        {
            if (!_initialized)
            {
                _stream.Write(_version);
                _initialized = true;
            }
            _stream.Write(tag);
            WriteVarint(message.Length);
            _stream.Write(message);
            _stream.Flush();
        }

        public void WriteVarint(int value)
        {
            while (true)
            {
                if ((value & ~0x7FL) == 0)
                {
                    _stream.Write(value);
                    return;
                }

                // value >>>= 7; in C#
                _stream.Write((value & 0x7F) | 0x80);
                var u = unchecked((uint)value);
                u = u >> 7;

                value = unchecked((int)u);
            }
        }
    }
}
