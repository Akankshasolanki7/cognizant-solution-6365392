# JWT Authentication API - Testing Examples with userid and userrole Parameters

## 🎯 Updated API Endpoints

### **GET /api/auth** - Generate JWT Token with Parameters

**URL**: `http://localhost:5005/api/auth`

**Parameters**:
- `userid` (query parameter, integer, default: 1) - User ID for JWT token
- `userrole` (query parameter, string, default: "Admin") - User role for JWT token

**Example Requests**:

#### 1. Default Parameters
```
GET http://localhost:5005/api/auth
```

**Response**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "userid": 1,
  "userrole": "Admin",
  "message": "JWT token generated successfully for User ID: 1 with Role: Admin"
}
```

#### 2. Custom User ID and Role
```
GET http://localhost:5005/api/auth?userid=123&userrole=Manager
```

**Response**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "userid": 123,
  "userrole": "Manager",
  "message": "JWT token generated successfully for User ID: 123 with Role: Manager"
}
```

#### 3. Different Role Examples
```
GET http://localhost:5005/api/auth?userid=456&userrole=User
GET http://localhost:5005/api/auth?userid=789&userrole=SuperAdmin
GET http://localhost:5005/api/auth?userid=999&userrole=Employee
```

### **GET /api/auth/short** - Generate Short-lived JWT Token with Parameters

**URL**: `http://localhost:5005/api/auth/short`

**Parameters**:
- `userid` (query parameter, integer, default: 1) - User ID for JWT token
- `userrole` (query parameter, string, default: "Admin") - User role for JWT token

**Example Requests**:

#### 1. Short Token with Custom Parameters
```
GET http://localhost:5005/api/auth/short?userid=555&userrole=Supervisor
```

**Response**:
```json
{
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
  "userid": 555,
  "userrole": "Supervisor",
  "expiresIn": "2 minutes",
  "message": "Short-lived JWT token generated for User ID: 555 with Role: Supervisor"
}
```

## 🎯 Swagger UI Testing

### **In Swagger UI (http://localhost:5005/swagger):**

1. **Expand GET /api/auth endpoint**
2. **Click "Try it out"**
3. **You will see two parameter fields**:
   - `userid` (integer) - Enter any positive number
   - `userrole` (string) - Enter any role name

4. **Example Values to Test**:
   - userid: `100`, userrole: `Admin`
   - userid: `200`, userrole: `Manager`
   - userid: `300`, userrole: `Employee`
   - userid: `400`, userrole: `SuperUser`

5. **Click "Execute"** to see the response

## 🎯 Validation Examples

### **Error Cases**:

#### 1. Invalid User ID (zero or negative)
```
GET http://localhost:5005/api/auth?userid=0&userrole=Admin
```

**Response**:
```json
{
  "error": "User ID must be greater than 0"
}
```

#### 2. Empty User Role
```
GET http://localhost:5005/api/auth?userid=123&userrole=
```

**Response**:
```json
{
  "error": "User role cannot be empty"
}
```

## 🎯 JWT Token Claims

The generated JWT token will contain:
- **User ID**: As specified in the `userid` parameter
- **Role**: As specified in the `userrole` parameter
- **Issuer**: "mySystem"
- **Audience**: "myUsers"
- **Expiration**: 60 minutes (or 2 minutes for short token)

## 🎯 Testing Different Scenarios

### **Scenario 1: Admin User**
```
GET /api/auth?userid=1&userrole=Admin
```

### **Scenario 2: Regular User**
```
GET /api/auth?userid=1001&userrole=User
```

### **Scenario 3: Manager**
```
GET /api/auth?userid=2001&userrole=Manager
```

### **Scenario 4: Employee**
```
GET /api/auth?userid=3001&userrole=Employee
```

### **Scenario 5: Custom Role**
```
GET /api/auth?userid=4001&userrole=DataAnalyst
```

## 🎯 Using Generated Tokens

1. **Copy the token** from the response
2. **In Swagger UI**, click the **"Authorize"** button (🔒)
3. **Enter**: `Bearer YOUR_TOKEN_HERE`
4. **Click "Authorize"**
5. **Test protected endpoints** like `/api/employee`

## 🎯 Postman Testing

### **Collection Setup**:
1. **Create new request**: `GET http://localhost:5005/api/auth`
2. **Add Query Parameters**:
   - Key: `userid`, Value: `123`
   - Key: `userrole`, Value: `Manager`
3. **Send request** and copy the token
4. **Use token** in Authorization header for protected endpoints

**Authorization Header**:
```
Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...
```

## ✅ **Updated Features Summary**

- ✅ **userid parameter** - Specify any user ID (integer)
- ✅ **userrole parameter** - Specify any role (string)
- ✅ **Default values** - userid=1, userrole="Admin"
- ✅ **Input validation** - Validates userid > 0 and userrole not empty
- ✅ **Enhanced response** - Shows userid, userrole, and success message
- ✅ **Swagger documentation** - Parameters visible in Swagger UI
- ✅ **Both endpoints updated** - Regular and short-lived token endpoints

**Now you can test JWT token generation with any userid and userrole combination!** 🚀
