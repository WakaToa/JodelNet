namespace JodelNet.GCM
{
    public class VerificationResult
    {
        public bool Success { get; set; }
        public string Message { get; set; }

        public VerificationResult(bool success, string msg)
        {
            Success = success;
            Message = msg;
        }
    }
}
