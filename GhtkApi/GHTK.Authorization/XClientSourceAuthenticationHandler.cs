using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.Encodings.Web;

namespace GHTK.Authorization
{
    // custom authentication handler trong ASP.NET Core, kế thừa từ AuthenticationHandler<TOptions>.
    // Mục đích chính của nó là kiểm tra header X-Client-Source và xác thực người dùng dựa trên giá trị của header này
    public class XClientSourceAuthenticationHandler : AuthenticationHandler<XClientSourceAuthenticationHandlerOptions>
    {
        public XClientSourceAuthenticationHandler(IOptionsMonitor<XClientSourceAuthenticationHandlerOptions> options, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock) : base(options, logger, encoder, clock)
        {
        }

        // là phương thức quan trọng nhất trong AuthenticationHandler, dùng để xử lý logic xác thực.
        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var clientSourceValue = Context.Request.Headers["X-Client-Source"].FirstOrDefault();
            if (clientSourceValue == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Missing X-Client-Source header"));
            }

            if (!Options.ClientSourceValidator(clientSourceValue))
            {
                return Task.FromResult(AuthenticateResult.Fail("Invalid X-Client-Source header"));
            }

            var identity = new ClaimsIdentity(Scheme.Name);
            identity.AddClaim(new Claim(ClaimTypes.Name, clientSourceValue)); ////ClaimTypes.Name: là một trong những loại claim phổ biến nhất trong ASP.NET Core Authentication, thường dùng để lưu tên đăng nhập hoặc thông tin nhận diện của người dùng.
            var principal = new ClaimsPrincipal(identity); //  là một đối tượng bao bọc ClaimsIdentity, đại diện cho người dùng và chứa tất cả các danh tính (identity) của họ.
            var ticket = new AuthenticationTicket(principal, Scheme.Name); // đại diện cho kết quả của quá trình xác thực, Principal - thông tin danh tính đã xác thực, Authentication Scheme - tên của phương thức xác thực
            return Task.FromResult(AuthenticateResult.Success(ticket));

        }
    }
}
