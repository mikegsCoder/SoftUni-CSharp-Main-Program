--Create a user defined function, named udf_AllUserCommits(@username) that 
--receives a username.
--The function must return count of all commits for the user:

CREATE FUNCTION udf_AllUserCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @userId INT = (SELECT TOP(1) Id FROM Users WHERE Username = @username)

	DECLARE @count INT = (SELECT COUNT(*) FROM Commits WHERE ContributorId = @userId)

	RETURN @count
END
