# webapi-03: Custom Models & Filters

## 🎯 Objectives
- Demonstrate creation of Action method to return list of custom class entity
- Model class creation, Use AllowAnonymous attribute, Use HttpGet action method
- Explain usage of FromBody attribute to read model object from request
- Demonstrate Custom filter using ActionFilterAttribute
- OnActionExecuting method to intercept requests
- Create filter for Custom exception handling
- Install Microsoft.AspNetCore.Mvc.WebApiCompatShim package

## 📋 Task 1: Web API using Custom Model Class

### Step 1: Create Custom Employee Class
Create a comprehensive Employee model with complex structure:

```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Salary { get; set; }
    public bool Permanent { get; set; }
    public Department Department { get; set; }
    public List<Skill> Skills { get; set; }
    public DateTime DateOfBirth { get; set; }
}

public class Department
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }
}

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ExperienceYears { get; set; }
}
```

### Step 2: Create EmployeeController with Custom Methods
- Constructor with sample records
- HTTPGet, HTTPPost/HTTPPut methods
- Private method GetStandardEmployeeList
- ActionResult<Employee> GetStandard()
- ProducesResponseType for status code 200

### Step 3: Enhanced Return Types
- Modify return type to List<Employee>
- Add comprehensive Swagger documentation
- Include complex object relationships

## 📋 Task 2: Custom Authorization Filter

### Requirement:
Create a custom action filter to intercept incoming requests and check for Authorization header with Bearer token.

### Step 1: Create CustomAuthFilter
```csharp
public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        // Check for Authorization header
        // Validate Bearer token
        // Return BadRequest if invalid
    }
}
```

### Step 2: Implementation Logic
- Check if 'Authorization' key exists in request header
- If not present: throw BadRequestResult with message "Invalid request - No Auth token"
- If present: check if value contains 'Bearer'
- If Bearer not found: throw BadRequestResult with message "Invalid request - Token present but Bearer unavailable"

### Step 3: Apply Filter
Add CustomAuthFilter attribute to Employee controller to filter all requests.

## 📋 Task 3: Custom Exception Filter

### Step 1: Create CustomExceptionFilter
```csharp
public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        // Capture exception details
        // Write to file system
        // Set Result property to ExceptionResult
    }
}
```

### Step 2: Exception Handling Logic
- Use exception context to fetch exception details
- Capture and write exception to file in system
- Set Result property of exception context to ExceptionResult
- Handle different types of exceptions

### Step 3: Test Exception Handling
- Throw exception in GET action method
- Ensure ProducesResponseType for 500 - Internal server error
- Use Swagger to test exception and message

### Step 4: Install Required Package
```bash
dotnet add package Microsoft.AspNetCore.Mvc.WebApiCompatShim
```

## 🔧 Key Features to Implement

### 1. AllowAnonymous Usage
```csharp
[AllowAnonymous]
[HttpGet]
public ActionResult<List<Employee>> GetStandard()
{
    return GetStandardEmployeeList();
}
```

### 2. FromBody Attribute
```csharp
[HttpPost]
public IActionResult CreateEmployee([FromBody] Employee employee)
{
    // Read complete model object from request body
    // Validate complex object structure
    // Handle nested objects (Department, Skills)
}
```

### 3. Complex Model Validation
- Validate nested Department object
- Validate Skills list
- Check date formats and ranges
- Ensure data integrity

### 4. Advanced Swagger Documentation
```csharp
[ProducesResponseType(200, Type = typeof(List<Employee>))]
[ProducesResponseType(400)]
[ProducesResponseType(401)]
[ProducesResponseType(500)]
```

## 📁 Project Structure
```
webapi-03/
├── Models/
│   ├── Employee.cs
│   ├── Department.cs
│   └── Skill.cs
├── Filters/
│   ├── CustomAuthFilter.cs
│   └── CustomExceptionFilter.cs
├── Controllers/
│   └── EmployeeController.cs
└── README.md
```

## 🎯 Learning Outcomes

After completing webapi-03, you will understand:

1. **Complex Model Creation**: Multi-level object structures
2. **Custom Filters**: Request interception and validation
3. **Exception Handling**: Global exception management
4. **Authorization Concepts**: Header validation and security
5. **FromBody Usage**: Complex object binding from JSON
6. **File Operations**: Writing logs and exception details
7. **Advanced Swagger**: Comprehensive API documentation

## ✅ Expected Results

- Custom Employee model with nested objects
- Authorization filter validates Bearer tokens
- Exception filter logs errors to file system
- Swagger documentation shows complex types
- All CRUD operations work with complex models
- Proper error handling and status codes

**This module demonstrates advanced Web API concepts with real-world scenarios!** 🚀
