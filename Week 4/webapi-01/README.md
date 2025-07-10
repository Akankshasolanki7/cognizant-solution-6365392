# webapi-01: First Web API using .NET Core

## 🎯 Objectives
- Explain the concept of RESTful web service, Web API & Microservice
- Features of REST architecture - Representational State Transfer, Stateless, Messages
- Concept of Microservice, Difference between WebService & WebAPI
- Explain HttpRequest & HttpResponse
- List types of Action Verbs (HttpGet, HttpPost, HttpPut, HttpDelete)
- List types of HttpStatusCodes (Ok, InternalServerError, Unauthorized, BadRequest)
- Demonstrate creation of simple WebAPI with Read, Write actions
- Structure of Web API - Controller & inheritance from ApiController
- Configuration files (Startup.cs, appSettings.json, launchSettings.json)

## 📋 Theory: REST Concepts

### 1. RESTful Web Service
**REST (Representational State Transfer)** is an architectural style for web services.

**Key Features:**
- **Representational State Transfer**: Resources represented in different formats (JSON, XML)
- **Stateless**: Each request contains all information needed
- **Messages**: Communication through HTTP messages
- **Uniform Interface**: Consistent way to interact with resources

### 2. Web API vs Web Service vs Microservice

| Type | Protocol | Data Format | Complexity |
|------|----------|-------------|------------|
| **Web Service** | SOAP | XML only | Complex |
| **Web API** | REST/HTTP | JSON, XML, HTML | Simple |
| **Microservice** | HTTP/REST | Usually JSON | Modular |

**Key Advantages of Web API:**
- Not restricted to XML - can send JSON, XML, HTML responses
- Lightweight and faster
- Uses standard HTTP methods

### 3. HttpRequest & HttpResponse

**HttpRequest Components:**
- Method (GET, POST, PUT, DELETE)
- URL (Resource identifier)
- Headers (Content-Type, Authorization)
- Body (Data payload)

**HttpResponse Components:**
- Status Code (200, 404, 500)
- Headers (Response metadata)
- Body (Response data)

### 4. Action Verbs

| Verb | Purpose | Characteristics |
|------|---------|----------------|
| **GET** | Read data | Safe, Idempotent |
| **POST** | Create data | Not safe, Not idempotent |
| **PUT** | Update data | Not safe, Idempotent |
| **DELETE** | Remove data | Not safe, Idempotent |

### 5. HTTP Status Codes

| Code | Name | Meaning |
|------|------|---------|
| **200** | OK | Success |
| **400** | Bad Request | Invalid input |
| **401** | Unauthorized | Authentication required |
| **404** | Not Found | Resource not found |
| **500** | Internal Server Error | Server error |

## 🚀 Practical Implementation

### Step 1: Create .NET Core Web API Project
```bash
dotnet new webapi -n FirstWebApi
cd FirstWebApi
dotnet add package Swashbuckle.AspNetCore
```

### Step 2: Configure Program.cs
```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### Step 3: Create ValuesController
```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    private static List<string> values = new List<string>
    {
        "value1", "value2", "value3"
    };

    // GET: api/values - Read operation
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(values); // Returns 200 OK
    }

    // GET: api/values/5 - Read specific
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        if (id < 0 || id >= values.Count)
            return NotFound(); // Returns 404 Not Found
        
        return Ok(values[id]); // Returns 200 OK
    }

    // POST: api/values - Write operation
    [HttpPost]
    public IActionResult Post([FromBody] string value)
    {
        if (string.IsNullOrEmpty(value))
            return BadRequest(); // Returns 400 Bad Request
        
        values.Add(value);
        return Ok("Value added"); // Returns 200 OK
    }

    // PUT: api/values/5 - Write operation
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] string value)
    {
        if (id < 0 || id >= values.Count)
            return NotFound(); // Returns 404 Not Found
        
        if (string.IsNullOrEmpty(value))
            return BadRequest(); // Returns 400 Bad Request
        
        values[id] = value;
        return Ok("Value updated"); // Returns 200 OK
    }

    // DELETE: api/values/5 - Write operation
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        if (id < 0 || id >= values.Count)
            return NotFound(); // Returns 404 Not Found
        
        values.RemoveAt(id);
        return Ok("Value deleted"); // Returns 200 OK
    }
}
```

## 🧪 Testing

### Step 1: Run the Application
```bash
dotnet run
```

### Step 2: Test GET Method
**URL**: `http://localhost:5000/api/values`

**Expected Response**:
```json
["value1", "value2", "value3"]
```

### Step 3: Access Swagger
**URL**: `http://localhost:5000/swagger`

## 📁 Configuration Files

### 1. Program.cs (Replaces Startup.cs in .NET 6+)
- Service registration
- Middleware configuration
- Application pipeline setup

### 2. appsettings.json
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*"
}
```

### 3. launchSettings.json
```json
{
  "profiles": {
    "FirstWebApi": {
      "commandName": "Project",
      "launchBrowser": true,
      "launchUrl": "swagger",
      "applicationUrl": "http://localhost:5000"
    }
  }
}
```

## ✅ Key Learning Points

1. **Web API Structure**: Controller inherits from ControllerBase
2. **Action Verbs**: HTTP methods map to controller actions
3. **Status Codes**: Return appropriate codes for different scenarios
4. **Read/Write Operations**: GET for reading, POST/PUT/DELETE for writing
5. **Configuration**: Program.cs configures the entire application

## 🎯 Expected Results

- Web API runs successfully
- GET method returns JSON array
- All CRUD operations work
- Swagger documentation available
- Proper HTTP status codes returned

**This provides a solid foundation for Web API development!** 🚀
