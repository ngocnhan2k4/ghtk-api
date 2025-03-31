using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;

namespace GHTK.Authorization
{
    public static class XClientSourceAuthenticationHandlerExtensions
    {
        private const string DefaultScheme = "X-Client-Source"; // Schem.Name của XClientSourceAuthenticationHandler

        // Action<T>: Một delegate nhận vào một đối tượng T và thực hiện cấu hình trên đó.
        public static void AddXClientSource(this IServiceCollection services, Action<XClientSourceAuthenticationHandlerOptions> options)
        {
            services.AddAuthentication(DefaultScheme)
                .AddScheme<XClientSourceAuthenticationHandlerOptions, XClientSourceAuthenticationHandler>(DefaultScheme, options); 
        }
    }
}
