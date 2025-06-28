
--Exercise 1: Create a Stored Procedure 

CREATE PROCEDURE sp_GetEmployeesByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT 
        EmployeeID, FirstName, LastName, Salary, JoinDate
    FROM 
        Employees
    WHERE 
        DepartmentID = @DepartmentID;
END;

--Exercise 2: Write the SQL query to select employee details based on the DepartmentID
EXEC sp_GetEmployeesByDepartment @DepartmentID = 3;

--DROP PROCEDURE sp_GetEmployeesByDepartment;


--Exercise 3: Create a stored procedure named `sp_InsertEmployee` with the following code:
CREATE PROCEDURE sp_InsertEmployee 
    @FirstName VARCHAR(50), 
    @LastName VARCHAR(50), 
    @DepartmentID INT, 
    @Salary DECIMAL(10,2), 
    @JoinDate DATE 
AS 
BEGIN 
    INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) 
    VALUES (@FirstName, @LastName, @DepartmentID, @Salary, @JoinDate); 
END;


EXEC sp_InsertEmployee 
    @FirstName = 'khushi', 
    @LastName = 'singh ', 
    @DepartmentID = 2, 
    @Salary = 8500.00, 
    @JoinDate = '2022-05-10';

--DROP PROCEDURE sp_InsertEmployee;

