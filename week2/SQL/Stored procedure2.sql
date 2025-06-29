-- Drop if rerunning
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE Departments;
IF OBJECT_ID('dbo.sp_InsertEmployee', 'P') IS NOT NULL DROP PROCEDURE sp_InsertEmployee;
IF OBJECT_ID('dbo.sp_GetEmployeeCountByDepartment', 'P') IS NOT NULL DROP PROCEDURE sp_GetEmployeeCountByDepartment;
GO

-- Create Departments table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);
GO

-- Create Employees table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT FOREIGN KEY REFERENCES Departments(DepartmentID),
    Salary DECIMAL(10,2),
    JoinDate DATE
);
GO

-- Insert sample data
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES 
(1, 'HR'), 
(2, 'Finance'), 
(3, 'IT'), 
(4, 'Marketing');

INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES 
('John', 'Doe', 1, 5000.00, '2020-01-15'),
('Jane', 'Smith', 2, 6000.00, '2019-03-22'),
('Michael', 'Johnson', 3, 7000.00, '2018-07-30'),
('Emily', 'Davis', 4, 5500.00, '2021-11-05');
GO

-- Exercise 1: Create stored procedure to insert employee
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
GO

-- Exercise 5: Create stored procedure to return employee count by department
CREATE PROCEDURE sp_GetEmployeeCountByDepartment
    @DepartmentID INT
AS
BEGIN
    SELECT COUNT(*) AS EmployeeCount
    FROM Employees
    WHERE DepartmentID = @DepartmentID;
END;
GO

-- Exercise 4: Execute sp_InsertEmployee (Example)
EXEC sp_InsertEmployee 
    @FirstName = 'Sara',
    @LastName = 'Lee',
    @DepartmentID = 2,
    @Salary = 6200.00,
    @JoinDate = '2022-05-10';
GO

-- Exercise 5: Execute sp_GetEmployeeCountByDepartment (Example)
EXEC sp_GetEmployeeCountByDepartment @DepartmentID = 2;
GO
