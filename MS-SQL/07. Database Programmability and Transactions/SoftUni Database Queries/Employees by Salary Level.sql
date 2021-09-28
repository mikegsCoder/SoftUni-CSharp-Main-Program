CREATE PROCEDURE usp_EmployeesBySalaryLevel(@salaryLevel VARCHAR(7))
AS
BEGIN
	SELECT FirstName, LastName 
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @salaryLevel
END