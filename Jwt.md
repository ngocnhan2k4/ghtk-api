### JWT 
- `JSON Web Token (JWT)` là một tiêu chuẩn Internet được đề xuất để tạo dữ liệu bao gồm `signature(optional)` và/hoặc `encryption(optional)`. Payload của JWT chứa dữ liệu ở định dạng JSON, trong đó xác nhận một số `"claims"` (khai báo). Token này được ký bằng một `private secret` hoặc bằng một cặp `public/private key`, giúp đảm bảo tính xác thực và toàn vẹn của dữ liệu.

**Header**
```json
{
  "alg": "HS256",
  "typ": "JWT"
}
```
**Payload**
```json
{
  "iss": "Issuer: Xác định bên phát hành token (ví dụ: URL của server xác thực)",
  "sub": "Subject: Định danh đối tượng của token (thường là user_id)",
  "aud": "Audience: Xác định ai là đối tượng sử dụng token (ví dụ: ứng dụng client)",
  "exp ": "Expiration Time: Thời gian token hết hạn",
  "iat": "Issued At: Thời gian token được tạo",
  "jti": "JWT ID: D duy nhất của token để tránh bị sử dụng lại (replay attack)",
  "nbf":"Not Before: Token không hợp lệ trước thời gian này"
}
```
**Signature**
```text
HMACSHA256(
  base64UrlEncode(Header) + "." + base64UrlEncode(Payload),
  secret
)
```