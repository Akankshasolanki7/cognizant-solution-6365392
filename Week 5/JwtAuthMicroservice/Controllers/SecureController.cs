using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // This attribute secures the endpoint using JWT
public class SecureController : ControllerBase
{
    [HttpGet("profile")]
    public IActionResult GetProfile()
    {
        var username = User.Identity?.Name;
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        return Ok(new
        {
            Message = "This is a secured endpoint - JWT authentication successful!",
            Username = username,
            UserId = userId,
            Timestamp = DateTime.Now,
            Claims = User.Claims.Select(c => new { c.Type, c.Value }).ToList()
        });
    }

    [HttpGet("data")]
    public IActionResult GetSecureData()
    {
        var username = User.Identity?.Name;
        
        return Ok(new
        {
            Message = "Access granted to secure data",
            Username = username,
            Data = new[]
            {
                "Confidential Information 1",
                "Confidential Information 2", 
                "Confidential Information 3"
            },
            AccessTime = DateTime.Now
        });
    }

    [HttpPost("update")]
    public IActionResult UpdateData([FromBody] object data)
    {
        var username = User.Identity?.Name;
        
        return Ok(new
        {
            Message = "Data updated successfully",
            Username = username,
            UpdatedBy = username,
            UpdatedAt = DateTime.Now,
            Status = "Success"
        });
    }
}
