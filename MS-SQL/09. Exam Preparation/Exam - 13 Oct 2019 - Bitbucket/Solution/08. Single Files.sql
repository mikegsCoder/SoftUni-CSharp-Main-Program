--Select all of the files, which are NOT a parent to any other file. Select 
--their size of the file and add "KB" to the end of it. Order them file id 
--(ascending), file name (ascending) and file size (descending).

SELECT
	Id,
	[Name],
	CONCAT(Size, 'KB') AS Size
FROM Files AS f
WHERE f.Id NOT IN 
	(SELECT ParentId FROM Files WHERE ParentId IS NOT NULL)
ORDER BY Id ASC, [Name] ASC, f.Size DESC