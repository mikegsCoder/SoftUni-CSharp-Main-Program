CREATE PROCEDURE usp_ExcludeFromSchool(@StudentId INT)
AS
BEGIN
	IF NOT EXISTS(SELECT TOP(1) * FROM Students WHERE Id = @StudentId)
	THROW 50000, 'This school has no student with the provided id!', 1;

	DELETE FROM StudentsExams WHERE StudentId = @StudentId;

	DELETE FROM StudentsSubjects WHERE StudentId = @StudentId;

	DELETE FROM StudentsTeachers WHERE StudentId = @StudentId;

	DELETE FROM Students WHERE Id = @StudentId;
END