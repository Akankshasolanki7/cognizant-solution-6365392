# webapi-04: CRUD Operations

## 🎯 Objectives
- Demonstrate creation of Action method to perform data create, update & delete operation
- Use FromBody attribute, extract data to custom model class using FromBody attribute
- Use hardcoded data to update & delete data
- Use Swagger and POSTMAN to test all operations
- Implement comprehensive validation and error handling

## 📋 Task: Web API CRUD Operation

### Key Requirements:
1. **Update Employee Data**: Employee information updated based on user input
2. **Use Swagger Tool**: Invoke action method mapped with HTTP PUT action verb
3. **Return Employee Data**: Modify action method to return Employee data through ActionResult
4. **Validation**: Check if ID value is valid and handle errors appropriately
5. **Error Messages**: Specific error messages for different validation scenarios

### Validation Rules:
- **Invalid ID Check**: If id <= 0, throw BadRequest with message 'Invalid employee id'
- **Not Found Check**: If id not in employee list, throw BadRequest with same message
- **Valid Update**: If id is valid, use JSON data from input body to update hardcoded list
- **Return Updated Data**: Filter employee list for input id and return as output

## 🚀 Implementation Features

### 1. Enhanced Employee Model
```csharp
public class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Department { get; set; }
    public decimal Salary { get; set; }
    public DateTime JoinDate { get; set; }
    public bool IsActive { get; set; }
}
```

### 2. Complete CRUD Operations
- **CREATE**: POST /api/employee - Add new employee
- **READ**: GET /api/employee - Get all employees
- **READ**: GET /api/employee/{id} - Get specific employee
- **UPDATE**: PUT /api/employee/{id} - Update existing employee
- **DELETE**: DELETE /api/employee/{id} - Remove employee

### 3. Advanced Validation
- Input validation for all fields
- Business rule validation
- Custom error responses
- Detailed error messages

### 4. FromBody Usage
- Complex object binding from JSON
- Nested object validation
- Collection handling
- Data transformation

## 📊 Expected API Endpoints

### GET /api/employee
**Response**: List of all employees
```json
[
  {
    "id": 1,
    "name": "John Doe",
    "email": "john@company.com",
    "department": "IT",
    "salary": 75000,
    "joinDate": "2023-01-15",
    "isActive": true
  }
]
```

### POST /api/employee
**Request Body**:
```json
{
  "name": "Jane Smith",
  "email": "jane@company.com",
  "department": "HR",
  "salary": 65000,
  "joinDate": "2024-01-01",
  "isActive": true
}
```

### PUT /api/employee/1
**Request Body**:
```json
{
  "name": "John Doe Updated",
  "email": "john.updated@company.com",
  "department": "Senior IT",
  "salary": 85000,
  "joinDate": "2023-01-15",
  "isActive": true
}
```

## ✅ Testing Scenarios

### Swagger Testing:
1. **Valid Update**: Update employee with valid ID and data
2. **Invalid ID**: Test with ID <= 0
3. **Not Found**: Test with non-existent ID
4. **Invalid Data**: Test with missing required fields
5. **Boundary Cases**: Test edge cases and limits

### POSTMAN Testing:
1. **Headers**: Content-Type: application/json
2. **Body**: Raw JSON format
3. **Status Codes**: Verify 200, 400, 404 responses
4. **Response Data**: Validate returned employee data

## 🎯 Learning Outcomes

After completing webapi-04, you will understand:

1. **CRUD Implementation**: Complete data operations
2. **FromBody Binding**: JSON to object conversion
3. **Validation Strategies**: Input and business validation
4. **Error Handling**: Proper HTTP status codes and messages
5. **Testing Techniques**: Swagger and POSTMAN usage
6. **Data Management**: In-memory data operations

**This module provides comprehensive CRUD operations with professional validation and error handling!** 🚀
