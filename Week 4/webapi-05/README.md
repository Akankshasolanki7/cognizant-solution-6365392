# webapi-05: CORS & JWT Authentication

## 🎯 Objectives
- Explain CORS enablement for Web API access for local application
- What is CORS?, How to enable CORS through Startup.cs, Install CORS NuGet package
- Demonstrate security in WebAPI using Bearer and JWT token authentication
- Use Authorize attribute & send roles in JWT token
- Setting in Startup.cs for AddAuthentication and AddJwtBearer with validation attributes
- UseAuthentication, AllowAnonymous to AuthController to generate token, Claims

## 📋 Task 1: JsonWebToken (JWT) Authentication

### What is JWT?
JSON Web Token (JWT) is a methodology of passing a token in the Authorization header value in the request so that it can be checked at the WebAPI and validated. If not there, then 'Unauthorized' status message with status code 401 should be thrown.

### Key Components:
1. **Security Key**: "mysuperdupersecret"
2. **Issuer**: "mySystem" 
3. **Audience**: "myUsers"
4. **Claims**: User roles and ID
5. **Expiration**: Configurable token lifetime

## 📋 Task 2: Authentication Configuration

### Program.cs Configuration:
```csharp
string securityKey = "mysuperdupersecret";
var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
{
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "mySystem",
        ValidAudience = "myUsers",
        IssuerSigningKey = symmetricSecurityKey
    };
});
```

## 📋 Task 3: AuthController Implementation

### Features:
- **AllowAnonymous**: Controller accessible without authentication
- **GenerateJSONWebToken**: Private method to create JWT tokens
- **Claims**: Include user role and ID
- **Token Expiration**: Configurable duration (10 minutes default)

### Sample JWT Generation:
```csharp
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
```

## 📋 Task 4: POSTMAN Testing Scenarios

### 1. Test Without Token:
- **Request**: GET /api/employee
- **Expected**: 401 Unauthorized
- **Headers**: No Authorization header

### 2. Generate JWT Token:
- **Request**: GET /api/auth
- **Expected**: JWT token returned
- **Use**: Copy token for subsequent requests

### 3. Test With Valid Token:
- **Request**: GET /api/employee
- **Headers**: Authorization: Bearer {token}
- **Expected**: 200 OK with data

### 4. Test With Invalid Token:
- **Request**: GET /api/employee
- **Headers**: Authorization: Bearer invalid_token
- **Expected**: 401 Unauthorized

### 5. Test Token Expiration:
- **Wait**: 2+ minutes after token generation
- **Request**: GET /api/employee with expired token
- **Expected**: 401 Unauthorized

## 📋 Task 5: Role-Based Authorization

### Implementation:
```csharp
[Authorize(Roles = "Admin")]
public class EmployeeController : ControllerBase
```

### Testing Scenarios:
1. **Admin Role**: Access granted
2. **POC Role**: Access denied (401)
3. **Multiple Roles**: Admin,POC - Access granted

## 📋 Task 6: CORS Configuration

### What is CORS?
Cross-Origin Resource Sharing (CORS) allows web applications running at one domain to access resources from another domain.

### Configuration:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

app.UseCors("AllowAll");
```

## 🎯 Expected Results

### Authentication Flow:
1. **Generate Token**: POST /api/auth → JWT token
2. **Use Token**: Add to Authorization header
3. **Access Protected**: GET /api/employee with token
4. **Role Validation**: Check user permissions
5. **Token Expiry**: Handle expired tokens

### CORS Benefits:
- **Local Development**: Frontend can access API
- **Cross-Domain**: Different ports/domains supported
- **Security**: Controlled access policies

## ✅ Key Learning Points

1. **JWT Authentication**: Token-based security
2. **Claims-Based Authorization**: Role and user information
3. **Token Validation**: Issuer, audience, lifetime checks
4. **CORS Configuration**: Cross-origin access control
5. **Security Best Practices**: Proper token handling
6. **POSTMAN Testing**: Authentication workflow testing

**This module demonstrates enterprise-level security implementation!** 🚀
