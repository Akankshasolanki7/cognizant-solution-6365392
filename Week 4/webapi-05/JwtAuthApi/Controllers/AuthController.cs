using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthApi.Controllers
{
    /// <summary>
    /// AuthController with AllowAnonymous attribute as per instructions
    /// Generates JWT tokens for authentication
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous] // AllowAnonymous attribute as per instructions
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// GET: api/auth
        /// Generates JWT token with specified userId and userRole parameters
        /// Invoke GenerateJSONWebToken with userId and userRole as per instructions
        /// </summary>
        /// <param name="userid">User ID for JWT token generation</param>
        /// <param name="userrole">User role for JWT token generation (e.g., Admin, User, Manager)</param>
        [HttpGet]
        public IActionResult Get([FromQuery] int userid = 1, [FromQuery] string userrole = "Admin")
        {
            // Validate input parameters
            if (userid <= 0)
            {
                return BadRequest(new { error = "User ID must be greater than 0" });
            }

            if (string.IsNullOrWhiteSpace(userrole))
            {
                return BadRequest(new { error = "User role cannot be empty" });
            }

            // Invoke GenerateJSONWebToken with provided userId and userRole
            // This is to set Claims information to check the user role
            var token = GenerateJSONWebToken(userid, userrole);

            return Ok(new {
                token = token,
                userid = userid,
                userrole = userrole,
                message = $"JWT token generated successfully for User ID: {userid} with Role: {userrole}"
            });
        }

        /// <summary>
        /// GET: api/auth/short
        /// Generates JWT token with 2 minutes expiration for testing token expiry as per instructions
        /// </summary>
        /// <param name="userid">User ID for JWT token generation</param>
        /// <param name="userrole">User role for JWT token generation (e.g., Admin, User, Manager)</param>
        [HttpGet("short")]
        public IActionResult GetShortToken([FromQuery] int userid = 1, [FromQuery] string userrole = "Admin")
        {
            // Validate input parameters
            if (userid <= 0)
            {
                return BadRequest(new { error = "User ID must be greater than 0" });
            }

            if (string.IsNullOrWhiteSpace(userrole))
            {
                return BadRequest(new { error = "User role cannot be empty" });
            }

            // Modify the duration for 'expires' attribute to 2 minutes as per instructions
            var token = GenerateJSONWebTokenWithExpiry(userid, userrole, 2);

            return Ok(new {
                token = token,
                userid = userid,
                userrole = userrole,
                expiresIn = "2 minutes",
                message = $"Short-lived JWT token generated for User ID: {userid} with Role: {userrole}"
            });
        }

        /// <summary>
        /// Private method GenerateJSONWebToken as per exact instructions
        /// Note: issuer, audience and securitykey must match with Program.cs configuration
        /// </summary>
        private string GenerateJSONWebToken(int userId, string userRole)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(10),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// Private method to generate JWT token with custom expiry for testing
        /// </summary>
        private string GenerateJSONWebTokenWithExpiry(int userId, string userRole, int expiryMinutes)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysuperdupersecret"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Role, userRole),
                new Claim("UserId", userId.ToString())
            };

            var token = new JwtSecurityToken(
                        issuer: "mySystem",
                        audience: "myUsers",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(expiryMinutes),
                        signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
