namespace Bloops.Shared.Responses
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }

        public ErrorType Type { get; set; }

        public string Message { get; set; }
    }

    public enum ErrorType
    {
    } 
}
