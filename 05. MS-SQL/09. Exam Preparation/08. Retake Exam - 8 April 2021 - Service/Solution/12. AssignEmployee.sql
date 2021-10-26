CREATE PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
	
	DECLARE @EmployeeDepartmentId INT = 
	(SELECT DepartmentId FROM Employees WHERE Id = @EmployeeId);

	DECLARE @CategoryDepartmentId INT = 
	(SELECT c.DepartmentId FROM Reports r 
	JOIN Categories AS c ON c.Id = r.CategoryId
	WHERE r.Id = @ReportId);

	IF(@EmployeeDepartmentId != @CategoryDepartmentId)
		THROW 50000, 'Employee doesn''t belong to the appropriate department!', 1

	UPDATE Reports
		SET EmployeeId = @EmployeeId
		WHERE Id = @ReportId
END