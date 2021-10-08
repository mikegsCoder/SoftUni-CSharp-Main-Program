--Select all of the files, which have size, greater than 1000, and a name 
--containing "html". Order them by size (descending), id (ascending) and 
--by file name (ascending).

SELECT
	Id,
	[Name],
	Size
FROM Files
WHERE Size > 1000 AND [Name] LIKE '%.html'
ORDER BY Size DESC, Id ASC, [Name] ASC