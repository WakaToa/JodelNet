namespace JodelNet.Json.Responses
{
    public abstract class JodelResponse
    {
        protected JodelResponse()
        {
            ResponseCode = JodelResponseCodes.SUCCESS;
        }

        public JodelResponseCodes ResponseCode { get; set; }

        public string ErrorMessage => ResponseCode.ToString();

        public bool Success => ResponseCode == JodelResponseCodes.SUCCESS;
    }

    public enum JodelResponseCodes
    {
        SUCCESS = 200,

        UNAUTHORIZED = 401,
        ACTION_NOT_ALLOWED = 402,
        ACCESS_DENIED = 403,
        TOO_MANY_REQUESTS = 429,
        SIGNED_REQUEST_EXPECTED = 477,
        ACCOUNT_NOT_VERIFIED = 478,
        BAD_GATEWAY = 502,

        NULL_RESPONSE_ERROR = 600,
        JSON_ERROR = 601
    }
}
