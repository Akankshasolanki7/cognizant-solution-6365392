# Postman Testing Guide for webapi-02

## 🎯 Objective
Learn how to use Postman tool to test Web API methods with proper headers, JSON body, and request collections.

## 📥 Step 1: Download and Install Postman
1. Go to https://www.postman.com/downloads/
2. Download Postman for your operating system
3. Install and create a free account (optional but recommended)

## 🖥️ Step 2: Understanding Postman Interface

### Left Panel:
- **Collections**: Groups of related requests
- **History**: Previously sent requests
- **Environments**: Different settings (dev, prod, etc.)

### Center Panel (Main Request Area):
- **Request URL**: Where you enter the API endpoint
- **Method Dropdown**: GET, POST, PUT, DELETE, etc.
- **Tabs**: Params, Authorization, Headers, Body, Pre-request Script, Tests

### Bottom Panel:
- **Response Body**: API response data
- **Status**: HTTP status code (200, 404, etc.)
- **Headers**: Response headers
- **Time**: Request duration

## 📋 Step 3: Create Request Collection

### Create New Collection:
1. Click "New" in top left
2. Select "Collection"
3. Name it "Web API Tests - webapi-02"
4. Add description: "Testing Swagger Web API with Employee controller"
5. Click "Create"

## 🚀 Step 4: Test Employee API with Postman

### Test 1: GET All Employees
1. **Create New Request**:
   - Click "Add a request" in your collection
   - Name: "Get All Employees"
   - Method: GET
   - URL: `http://localhost:[port]/api/Emp`

2. **Headers** (usually not needed for GET):
   - No special headers required

3. **Send Request**:
   - Click "Send"
   - **Expected Response**:
   ```json
   [
     {
       "id": 1,
       "name": "John Doe",
       "department": "IT",
       "salary": 50000
     },
     {
       "id": 2,
       "name": "Jane Smith",
       "department": "HR",
       "salary": 45000
     },
     {
       "id": 3,
       "name": "Bob Johnson",
       "department": "Finance",
       "salary": 55000
     },
     {
       "id": 4,
       "name": "Alice Brown",
       "department": "Marketing",
       "salary": 48000
     }
   ]
   ```

4. **Verify**:
   - **Body**: List of employees displayed
   - **Status**: 200 OK (shown on right side)

### Test 2: GET Specific Employee
1. **Create New Request**:
   - Name: "Get Employee by ID"
   - Method: GET
   - URL: `http://localhost:[port]/api/Emp/1`

2. **Send and Verify**:
   - Response shows single employee
   - Status: 200 OK

### Test 3: POST Create Employee
1. **Create New Request**:
   - Name: "Create Employee"
   - Method: POST
   - URL: `http://localhost:[port]/api/Emp`

2. **Headers Tab**:
   - Key: `Content-Type`
   - Value: `application/json`

3. **Body Tab**:
   - Select "raw"
   - Select "JSON" from dropdown
   - Enter:
   ```json
   {
     "name": "Mike Wilson",
     "department": "Engineering",
     "salary": 60000
   }
   ```

4. **Send and Verify**:
   - Response shows created employee with new ID
   - Status: 200 OK

### Test 4: PUT Update Employee
1. **Create New Request**:
   - Name: "Update Employee"
   - Method: PUT
   - URL: `http://localhost:[port]/api/Emp/1`

2. **Headers**:
   - Content-Type: application/json

3. **Body**:
   ```json
   {
     "name": "John Doe Updated",
     "department": "Senior IT",
     "salary": 55000
   }
   ```

4. **Verify**: Updated employee data returned

### Test 5: DELETE Employee
1. **Create New Request**:
   - Name: "Delete Employee"
   - Method: DELETE
   - URL: `http://localhost:[port]/api/Emp/1`

2. **Send and Verify**:
   - Success message returned
   - Status: 200 OK

## 🔧 Step 5: Test Custom Routes

### Test Active Employees:
- Method: GET
- URL: `http://localhost:[port]/api/Emp/active`
- Expected: Employees with salary > 45000

### Test Employees by Department:
- Method: GET
- URL: `http://localhost:[port]/api/Emp/department/IT`
- Expected: Employees in IT department

## 📊 Step 6: Understanding Headers and Authorization

### Common Headers:
1. **Content-Type**: `application/json`
   - Tells server what format you're sending

2. **Accept**: `application/json`
   - Tells server what format you want back

3. **Authorization**: `Bearer token123`
   - For secured APIs (we'll use this in webapi-05)

### Adding Headers:
1. Click "Headers" tab
2. Add Key-Value pairs
3. Headers are sent with every request

## 📋 Step 7: Request Collection Organization

### Organize Requests:
1. **Folder Structure**:
   - Employee CRUD Operations
   - Values Controller Tests
   - Custom Route Tests

2. **Request Naming**:
   - Use descriptive names
   - Include HTTP method
   - Example: "GET - All Employees"

3. **Documentation**:
   - Add descriptions to requests
   - Include expected responses
   - Note any special requirements

## ✅ Step 8: Verification Checklist

Test each endpoint and verify:
- [ ] GET /api/Emp returns employee list
- [ ] GET /api/Emp/1 returns single employee
- [ ] POST /api/Emp creates new employee
- [ ] PUT /api/Emp/1 updates employee
- [ ] DELETE /api/Emp/1 deletes employee
- [ ] GET /api/Emp/active returns filtered employees
- [ ] GET /api/Emp/department/IT returns department employees
- [ ] All responses show correct status codes
- [ ] JSON format is properly displayed
- [ ] Headers are correctly configured

## 🎯 Key Learning Points

1. **Postman Structure**: Collections organize related requests
2. **Headers**: Content-Type is crucial for POST/PUT requests
3. **Body Format**: JSON data must be properly formatted
4. **Status Codes**: Always check the response status
5. **Custom Routes**: Different URL patterns for different operations
6. **Request Types**: Each HTTP method serves different purposes

## 🔍 Troubleshooting Tips

1. **404 Not Found**: Check URL spelling and port number
2. **400 Bad Request**: Verify JSON format and required fields
3. **500 Internal Server Error**: Check server logs and data validation
4. **No Response**: Ensure Web API is running

**Postman makes API testing visual and organized!** 🚀
