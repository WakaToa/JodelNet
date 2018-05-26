namespace JodelNet.GCM.Proto
{
    public class ProtoResponseMessage
    {
        public MCSToken McsTag { get; set; }
        public byte[] McsData { get; set; }
    }
}
