# webapi-02: Swagger & Postman Integration

## 🎯 Objectives
- Demonstrate Swagger installation to WebAPI and WebAPI listing on browser
- NuGet package Swashbuckle.AspNetCore, ProducesResponseType usage
- AddSwaggerGen, UseSwaggerUI configuration
- Demonstrate Postman tool usage for hitting WebAPI methods
- Structure in Postman tool, Headers with Authorization, Body as JSON
- Request collection and tabs in center pane
- Demonstrate Route usage and Name attribute in HTTP requests
- ActionName for multiple methods with same Action verb

## 📋 Task 1: Web API using .NET Core with Swagger

### Step 1: Use Existing Application
Use the FirstWebApi created in webapi-01 or create new one:
```bash
dotnet new webapi -n SwaggerWebApi
cd SwaggerWebApi
```

### Step 2: Install Swashbuckle.AspNetCore NuGet Package
```bash
dotnet add package Swashbuckle.AspNetCore
```

### Step 3: Configure Swagger in Program.cs
```csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Add Swagger with custom configuration
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "Swagger Demo",
        Version = "v1",
        Description = "TBD",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "John Doe",
            Email = "john@xyzmail.com",
            Url = new Uri("https://www.example.com")
        },
        License = new Microsoft.OpenApi.Models.OpenApiLicense
        {
            Name = "License Terms",
            Url = new Uri("https://www.example.com")
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        // Specifying the Swagger JSON endpoint
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Swagger Demo");
    });
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
```

### Step 4: Execute Application and Test
1. Run the application: `dotnet run`
2. Navigate to: `https://localhost:[port]/swagger`
3. Notice:
   - Title: "Swagger Demo"
   - Version: "v1"
   - Contact details shown on top
   - Values controller HTTP verb action methods listed

### Step 5: Test GET Method
1. Click the 'GET' action verb method (without parameter)
2. Panel opens with 'Try it out' button
3. Click 'Try it out'
4. Click 'Execute' button
5. Verify response: `["value1", "value2", "value3"]`

## 📋 Task 2: Use POSTMAN Tool

### Step 1: Download and Install Postman
- Go to https://www.postman.com/downloads/
- Download and install Postman

### Step 2: Create Employee Controller
```csharp
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees = new List<Employee>
    {
        new Employee { Id = 1, Name = "John Doe", Department = "IT", Salary = 50000 },
        new Employee { Id = 2, Name = "Jane Smith", Department = "HR", Salary = 45000 }
    };

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(List<Employee>))]
    [ProducesResponseType(500)]
    public IActionResult GetEmployees()
    {
        return Ok(employees);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(200, Type = typeof(Employee))]
    [ProducesResponseType(404)]
    public IActionResult GetEmployee(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);
        if (employee == null)
            return NotFound();
        return Ok(employee);
    }
}

public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public decimal Salary { get; set; }
}
```

### Step 3: Test with POSTMAN
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`

2. **Headers Section**:
   - Key: `Content-Type`
   - Value: `application/json`

3. **Body Section**:
   - Select "raw"
   - Select "JSON" format

4. **Send Request and Verify**:
   - Body part shows list of employees
   - Status shows "200 OK" on right side

## 📋 Task 3: Modify Route Attribute

### Step 1: Change Controller Route
```csharp
[ApiController]
[Route("api/Emp")] // Changed from [controller] to Emp
public class EmployeeController : ControllerBase
{
    // Same methods as above
}
```

### Step 2: Test Access through POSTMAN
- URL: `http://localhost:[port]/api/Emp`
- Verify it works with new route

## 🔧 Understanding Route and ActionName

### Route Attribute
```csharp
[Route("api/[controller]")] // Uses controller name
[Route("api/Emp")]          // Custom route name
```

### ActionName for Multiple Methods
```csharp
[HttpGet]
[ActionName("GetAll")]
public IActionResult GetAllEmployees() { }

[HttpGet("active")]
[ActionName("GetActive")]
public IActionResult GetActiveEmployees() { }
```

## 📊 POSTMAN Structure

### Left Panel:
- **Collections**: Organize related requests
- **History**: Previously sent requests
- **Environments**: Different settings

### Center Panel:
- **Request URL**: API endpoint
- **Method Dropdown**: GET, POST, PUT, DELETE
- **Tabs**: Params, Authorization, Headers, Body

### Bottom Panel:
- **Response Body**: API response data
- **Status**: HTTP status code
- **Headers**: Response headers
- **Time**: Request duration

## ✅ Key Learning Points

1. **Swagger Configuration**: Custom title, version, contact info
2. **ProducesResponseType**: Better API documentation
3. **Postman Structure**: Request organization and testing
4. **Custom Routes**: User-friendly API endpoints
5. **ActionName**: Multiple methods with same HTTP verb

## 🎯 Expected Results

- Swagger UI shows custom configuration
- Employee API returns JSON data
- POSTMAN successfully tests all endpoints
- Custom route 'Emp' works correctly
- All HTTP status codes display properly

**This demonstrates professional API documentation and testing!** 🚀
