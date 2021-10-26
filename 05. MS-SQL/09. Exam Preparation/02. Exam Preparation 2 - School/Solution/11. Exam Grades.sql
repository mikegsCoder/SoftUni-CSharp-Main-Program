CREATE FUNCTION udf_ExamGradesToUpdate(@studentId INT, @grade DECIMAL(3,2))
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @StudentExist INT = (SELECT TOP(1) StudentId FROM StudentsExams WHERE StudentId = @studentId);

	IF(@StudentExist IS NULL)
	BEGIN
		RETURN 'The student with provided id does not exist in the school!';
	END

	IF (@grade > 6.00)
	BEGIN
		RETURN 'Grade cannot be above 6.00!';
	END

	DECLARE @studentName NVARCHAR(30) = 
		(SELECT TOP(1) FirstName FROM Students WHERE Id = @studentId);

	DECLARE @upperRange DECIMAL(14,2) = @grade + 0.50;

	DECLARE @count INT = 
		(SELECT COUNT(Grade) FROM StudentsExams WHERE (StudentId = @studentId) AND (Grade >= @grade AND Grade <= @upperRange) )

	RETURN CONCAT('You have to update ', @count,' grades for the student ', @studentName)
END