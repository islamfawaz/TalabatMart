using Application.Abstraction;
using System.Security.Claims;

namespace APIs.Service
{
    public class LoggedInUserService : ILoggedInUserService
    {
        private readonly IHttpContextAccessor _httpContext;

        public string? UserId { get; }

        public LoggedInUserService(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
            UserId = _httpContext.HttpContext?.User.FindFirstValue(ClaimTypes.PrimarySid);
        }
    }
}
