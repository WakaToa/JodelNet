using System;
using System.Net.Security;
using JodelNet.Verification.Extensions;
using JodelNet.Verification.Proto;

namespace JodelNet.Verification.Stream
{
    //https://github.com/microg/android_packages_apps_GmsCore/blob/93c3cbb31be6c8ffae81c18e551cb00c74aaaaf4/play-services-core/src/main/java/org/microg/gms/gcm/mcs/McsInputStream.java
    public class McsInputStream
    {
        private readonly SslStream _stream;
        private bool _initialized;
        private int _version = -1;

        public McsInputStream(SslStream stream) : this(stream, false)
        {
        }

        public McsInputStream(SslStream stream, bool initialized)
        {
            _stream = stream;
            _initialized = initialized;
        }

        public int GetVersion()
        {
            EnsureVersionRead();
            return _version;
        }

        private void EnsureVersionRead()
        {
            if (!_initialized)
            {
                try
                {
                    _version = _stream.Read();
                    _initialized = true;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }

        public ProtoResponseMessage ReadProtoMessage()
        {
            try
            {
                EnsureVersionRead();
                var mcsTag = _stream.Read();
                var mcsSize = ReadVarint();
                var bytes = new byte[mcsSize];
                var len = 0;
                while ((len += _stream.Read(bytes, len, mcsSize - len)) < mcsSize)
                {
                    
                }
                return new ProtoResponseMessage{ McsData = bytes, McsTag = (MCSToken)mcsTag};
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private int ReadVarint()
        {
            var res = 0;
            var s = 0;
            var b = 0x80;
            while ((b & 0x80) == 0x80) {
                b = _stream.Read();
                res |= (b & 0x7F) << s;
                s += 7;
            }
            return res;
        }
    }
}
