

namespace XamBodyFit
{
    public class LoginResponse
    {
        public Response Response { get; set; }
        public User User { get; set; }
        public string AuthToken { get; set; }
    }
}