namespace JodelNet.GCM
{
    public class AndroidVerificationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }

        public AndroidVerificationResult(bool success, string error)
        {
            Success = success;
            ErrorMessage = error;
        }
    }
}
