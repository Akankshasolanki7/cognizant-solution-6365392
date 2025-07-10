# JWT Authentication Testing Guide with POSTMAN - Exact Instructions

## 🎯 Objective
Follow the exact instructions for JWT authentication testing with POSTMAN as specified in the requirements.

## 📋 Step 1: Use POSTMAN to Test Without JWT Token

### Test Employee Controller Without Token:
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`
   - Headers: No Authorization header

2. **Send Request**:
   - **Expected Response**: 401 Unauthorized
   - **Status**: Note the 'Status' attribute in the 'Headers' section in the output window
   - **Reason**: Authorize attribute checks if request header contains 'Authorization' key with 'Bearer' token

3. **Verify**:
   - If token unavailable, 'Unauthorized' status message with code 401 is thrown
   - Check 'Status' attribute in 'Headers' section in output window

## 📋 Step 2: Use AuthController to Generate JWT

### Generate JWT Token:
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/auth`
   - Headers: None required (AllowAnonymous attribute on AuthController)

2. **Send Request**:
   - **Expected Response**: 200 OK
   - **Body**: JWT token returned
   ```json
   {
     "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
   }
   ```

3. **Copy Token**: Save the token value for next requests
   - This token contains 'Admin' role in claims
   - Token expires in 10 minutes as per GenerateJSONWebToken method

### Generate Short Token for Expiry Testing:
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/auth/short`

2. **Expected Response**: Token with 2 minutes expiry
   - This is for testing JWT expiration as per instructions

## 📋 Step 3: Use JWT in POSTMAN Request

### Test with Valid JWT Token:
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`

2. **Add Authorization Header**:
   - Key: `Authorization`
   - Value: `Bearer {your_jwt_token_here}`
   - **Important**: Include "Bearer " before the token

3. **Send Request**:
   - **Expected Result**: This will test if the request is authenticated or not
   - **Current Setup**: Employee controller has [Authorize(Roles = "POC")]
   - **Admin Token Result**: Should get 403 Forbidden (wrong role)
   - **Status**: Check 'Status' attribute in 'Headers' section in output window

## 📋 Step 4: Modify Token Value in POSTMAN

### Test with Invalid Token:
1. **Create New Request**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`

2. **Modify Token Value**:
   - Key: `Authorization`
   - Value: `Bearer invalid_token_123`
   - **Purpose**: Check if 'Unauthorized' status message is thrown

3. **Send Request**:
   - **Expected Response**: 401 Unauthorized
   - **Verify**: Note the 'Status' attribute in the 'Headers' section in the output window
   - **Result**: Modified token should yield 'Unauthorized' message

## 📋 Step 5: Check JWT Expiration

### Test Token Expiry as per Instructions:
1. **Generate Short Token**:
   - GET `/api/auth/short`
   - This token has 2 minutes expiry (expires attribute modified to 2 minutes)

2. **Wait 2+ Minutes**: Let token expire

3. **Test Expired Token**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`
   - Headers: Authorization with expired token

4. **Expected Result**:
   - **Response**: 401 Unauthorized with Http status code 401
   - **Verification**: Check POSTMAN request for GET call AFTER 2 minutes of JWT generation
   - **Result**: Should yield 'Unauthorized' message as per instructions

## 📋 Step 6: Add Roles to Authorize Attribute

### Test POC Role (Current Setup):
1. **Current Employee Controller**: Has [Authorize(Roles = "POC")]
2. **Generate Admin Token**: GET `/api/auth` (generates Admin role token)
3. **Test Employee Access**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee`
   - Headers: Authorization: Bearer {admin_token}
   - **Expected**: 401 Unauthorized with status code 401
   - **Reason**: Admin token trying to access POC-only endpoint

### Test Admin,POC Roles (As Per Instructions):
1. **Employee2 Controller**: Has [Authorize(Roles = "Admin,POC")]
2. **Test with Admin Token**:
   - Method: GET
   - URL: `http://localhost:[port]/api/employee2`
   - Headers: Authorization: Bearer {admin_token}
   - **Expected**: 200 OK with status code 200
   - **Reason**: Admin role is included along with POC in Authorize attribute

### Verification Steps as per Instructions:
1. **Include role 'POC'**: Employee controller has POC role
   - Hit GET action method → Verify response status is 'Unauthorized' with status code 401

2. **Include role 'Admin' along with 'POC'**: Employee2 controller has Admin,POC roles
   - Hit GET action method → Verify response status is OK with status code 200

## 📋 Step 7: Test CRUD Operations with Authentication

### Create Employee (POST):
1. **Method**: POST
2. **URL**: `http://localhost:[port]/api/employee`
3. **Headers**:
   - Authorization: Bearer {admin_token}
   - Content-Type: application/json
4. **Body** (raw JSON):
   ```json
   {
     "name": "New Employee",
     "department": "Engineering",
     "salary": 80000,
     "isActive": true
   }
   ```
5. **Expected**: 200 OK with created employee

### Update Employee (PUT):
1. **Method**: PUT
2. **URL**: `http://localhost:[port]/api/employee/1`
3. **Headers**: Authorization + Content-Type
4. **Body**: Updated employee JSON
5. **Expected**: 200 OK with updated data

### Delete Employee (DELETE):
1. **Method**: DELETE
2. **URL**: `http://localhost:[port]/api/employee/1`
3. **Headers**: Authorization: Bearer {admin_token}
4. **Expected**: 200 OK with success message

## 📋 Step 8: Test CORS Functionality

### Cross-Origin Request:
1. **Different Port**: If testing from different port
2. **Browser Console**: Check for CORS errors
3. **Headers**: Verify CORS headers in response:
   - Access-Control-Allow-Origin: *
   - Access-Control-Allow-Methods: GET, POST, PUT, DELETE
   - Access-Control-Allow-Headers: *

## 🔧 POSTMAN Collection Organization

### Create Folders:
1. **Authentication**:
   - Generate Admin Token
   - Generate POC Token
   - Generate Short Token

2. **Unauthorized Tests**:
   - No Token Test
   - Invalid Token Test
   - Expired Token Test

3. **Role-Based Tests**:
   - Admin Only Access
   - POC Only Access
   - Multiple Role Access

4. **CRUD Operations**:
   - GET All Employees
   - GET Single Employee
   - POST Create Employee
   - PUT Update Employee
   - DELETE Employee

## ✅ Expected Test Results Summary

| Test Scenario | Expected Status | Expected Response |
|---------------|----------------|-------------------|
| No Token | 401 Unauthorized | Authentication required |
| Invalid Token | 401 Unauthorized | Invalid token |
| Expired Token | 401 Unauthorized | Token expired |
| Admin Token + Employee API | 200 OK | Employee data |
| POC Token + Employee API | 403 Forbidden | Insufficient permissions |
| Admin Token + PublicEmployee API | 200 OK | Employee data |
| POC Token + PublicEmployee API | 200 OK | Employee data |
| Admin Token + POCEmployee API | 403 Forbidden | Wrong role |
| POC Token + POCEmployee API | 200 OK | POC data |

## 🎯 Key Learning Points

1. **JWT Structure**: Bearer token in Authorization header
2. **Token Expiration**: Time-based security
3. **Role-Based Access**: Different permissions for different roles
4. **CORS Configuration**: Cross-origin request handling
5. **Status Codes**: 200, 401, 403 for different scenarios
6. **Claims Validation**: Role and user information in tokens

**This comprehensive testing demonstrates enterprise-level security implementation!** 🚀
