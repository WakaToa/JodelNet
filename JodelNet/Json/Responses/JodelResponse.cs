namespace JodelNet.Json.Responses
{
    public abstract class JodelResponse
    {
        protected JodelResponse()
        {
            Code = JodelResponseCodes.SUCCESS;
        }

        public JodelResponseCodes Code { get; set; }
        public string GetError()
        {
            switch (Code)
            {
                case JodelResponseCodes.SUCCESS:
                    return "Success";
                case JodelResponseCodes.NULL_RESPONSE_ERROR:
                    return "Response is null";
                case JodelResponseCodes.JSON_ERROR:
                    return "Json not valid";
                default:
                    return "Unknown ErrorCode";
            }
            
        }
    }

    public enum JodelResponseCodes
    {
        SUCCESS = 200,
        NULL_RESPONSE_ERROR = 600,
        JSON_ERROR = 601
    }
}
