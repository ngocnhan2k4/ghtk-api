using Microsoft.AspNetCore.Authentication;

namespace GHTK.Authorization
{
    // là lớp cấu hình (options) cho XClientSourceAuthenticationHandler
    // Khi tạo một custom authentication handler, bạn thường cần tùy chỉnh các tham số như:tên header cần kiểm tra, danh sách giá trị hợp lệ
    // các cài đặt khác như bỏ qua xác thực trong môi trường dev
    public class XClientSourceAuthenticationHandlerOptions : AuthenticationSchemeOptions
    {
        public Func<string?, bool> ClientSourceValidator { get; set; } = source => false;
    }
}
