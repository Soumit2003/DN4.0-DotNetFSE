-- Drop existing objects if re-running
IF OBJECT_ID('dbo.Employees', 'U') IS NOT NULL DROP TABLE Employees;
IF OBJECT_ID('dbo.Departments', 'U') IS NOT NULL DROP TABLE Departments;
IF OBJECT_ID('dbo.fn_CalculateAnnualSalary', 'FN') IS NOT NULL DROP FUNCTION fn_CalculateAnnualSalary;
GO

-- Create Departments Table
CREATE TABLE Departments (
    DepartmentID INT PRIMARY KEY,
    DepartmentName VARCHAR(100)
);

-- Create Employees Table
CREATE TABLE Employees (
    EmployeeID INT PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DepartmentID INT,
    Salary DECIMAL(10, 2),
    JoinDate DATE,
    FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
);
GO

-- Insert Sample Data into Departments
INSERT INTO Departments (DepartmentID, DepartmentName) VALUES
(1, 'HR'),
(2, 'IT'),
(3, 'Finance');

-- Insert Sample Data into Employees
INSERT INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
(1, 'John', 'Doe', 1, 5000.00, '2020-01-15'),
(2, 'Jane', 'Smith', 2, 6000.00, '2019-03-22'),
(3, 'Bob', 'Johnson', 3, 5500.00, '2021-07-01');
GO

-- Create Scalar Function for Annual Salary
CREATE FUNCTION fn_CalculateAnnualSalary (@MonthlySalary DECIMAL(10, 2))
RETURNS DECIMAL(10, 2)
AS
BEGIN
    RETURN (@MonthlySalary * 12);
END;
GO

-- Exercise 1: Show all employees with Annual Salary
SELECT 
    EmployeeID,
    FirstName,
    LastName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees;
GO

-- Exercise 7: Show Annual Salary for EmployeeID = 1
SELECT 
    FirstName,
    LastName,
    Salary,
    dbo.fn_CalculateAnnualSalary(Salary) AS AnnualSalary
FROM Employees
WHERE EmployeeID = 1;
GO
