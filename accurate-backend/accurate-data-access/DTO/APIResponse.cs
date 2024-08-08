using System.Net;

namespace accurate_data_access.DTO
{
    public class APIResponse<T> where T : class
    {
        public APIResponse()
        {
            ErrorMessages = new List<string>();
        }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess { get; set; }
        public List<string> ErrorMessages { get; set; }
        public T? Result { get; set; }
    }
}
