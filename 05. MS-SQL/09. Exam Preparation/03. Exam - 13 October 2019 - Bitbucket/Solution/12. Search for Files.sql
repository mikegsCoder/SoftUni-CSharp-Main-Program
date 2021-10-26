--Create a user defined stored procedure, named usp_SearchForFiles(@fileExtension)
--, that receives files extensions.
--The procedure must print the id, name and size of the file. Add "KB" in the end 
--of the size. Order them by id (ascending), file name (ascending) and file size 
--(descending)

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(20))
AS
BEGIN
	SELECT
		Id,
		[Name],
		CONCAT(Size,'KB') AS Size
	FROM Files
	WHERE [Name] LIKE '%' + '.' + @fileExtension
	ORDER BY Id ASC, [Name] ASC, Files.Size DESC
END