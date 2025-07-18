# Week 5 - JWT Authentication Microservice

## Question 1: Implement JWT Authentication in ASP.NET Core Web API

### Scenario
Building a microservice that requires secure login with JWT-based authentication.

### Implementation Steps Completed

✅ **Step 1**: Created ASP.NET Core Web API project  
✅ **Step 2**: Added User model and login endpoint  
✅ **Step 3**: Generate JWT token upon successful login  
✅ **Step 4**: Secure endpoints using `[Authorize]` attribute  

### Project Structure
```
Week 5/JwtAuthMicroservice/
├── Controllers/
│   ├── AuthController.cs      # Login and JWT token generation (PDF specs)
│   └── SecureController.cs    # Protected endpoints with [Authorize]
├── Models/
│   └── User.cs               # User and LoginModel classes
├── Program.cs                # JWT configuration as per PDF specs
├── appsettings.json         # JWT settings (PDF format)
└── JwtAuthMicroservice.csproj
```

### Configuration (Exact PDF Implementation)

#### NuGet Package
```bash
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

#### appsettings.json
```json
{
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtToken",
    "Issuer": "MyAuthServer", 
    "Audience": "MyApiUsers",
    "DurationInMinutes": 60
  }
}
```

#### Program.cs Authentication Setup (PDF Exact Code)
```csharp
builder.Services.AddAuthentication("Bearer")
 .AddJwtBearer("Bearer", options =>
 {
 options.TokenValidationParameters = new TokenValidationParameters
 {
 ValidateIssuer = true,
 ValidateAudience = true,
 ValidateLifetime = true,
 ValidateIssuerSigningKey = true,
 ValidIssuer = builder.Configuration["Jwt:Issuer"],
 ValidAudience = builder.Configuration["Jwt:Audience"],
 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
 };
 });
builder.Services.AddAuthorization();
```

#### AuthController.cs (PDF Exact Implementation)
```csharp
[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
 [HttpPost("login")]
 public IActionResult Login([FromBody] LoginModel model)
 {
 if (IsValidUser(model))
 {
 var token = GenerateJwtToken(model.Username);
 return Ok(new { Token = token });
 }
 return Unauthorized();
 }
 private string GenerateJwtToken(string username)
 {
 var claims = new[]
 {
 new Claim(ClaimTypes.Name, username)
 };
 var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken"));
 var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
 var token = new JwtSecurityToken(
 issuer: "MyAuthServer",
 audience: "MyApiUsers",
 claims: claims,
 expires: DateTime.Now.AddMinutes(60),
 signingCredentials: creds);
 return new JwtSecurityTokenHandler().WriteToken(token);
 }
}
```

### API Endpoints

#### Authentication
- `POST /api/auth/login` - Login and get JWT token

#### Secured Endpoints (Requires JWT)
- `GET /api/secure/profile` - Get user profile
- `GET /api/secure/data` - Get protected data  
- `POST /api/secure/update` - Update data

### Test Users
- Username: `admin`, Password: `admin123`
- Username: `user`, Password: `user123`
- Username: `test`, Password: `test123`

### How to Run
```bash
cd "cognizant-solution-6365392/Week 5/JwtAuthMicroservice"
dotnet run --urls "https://localhost:7000;http://localhost:5000"
```

### Testing
1. **Swagger UI**: Navigate to `https://localhost:5170/swagger`
2. **Login**: Use `/api/auth/login` with test credentials
3. **Authorize**: Click "Authorize" in Swagger, enter `Bearer <token>`
4. **Test Secured Endpoints**: Access protected endpoints with token

### Success Criteria
✅ JWT token generated upon successful login (PDF requirement)  
✅ Secured endpoints protected with `[Authorize]` (PDF requirement)  
✅ Token validation working correctly (PDF requirement)  
✅ Claims-based authentication implemented (PDF requirement)  
✅ Swagger UI with JWT authentication support  

This implementation follows the exact specifications from the PDF document for Week 5 JWT Authentication Microservices.
