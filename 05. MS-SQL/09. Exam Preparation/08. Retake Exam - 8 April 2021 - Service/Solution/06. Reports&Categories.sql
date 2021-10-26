  SELECT [Description], c.[Name] AS [CategoryName]
	FROM Reports r
	JOIN Categories c
	ON c.Id = r.CategoryId
	ORDER BY [Description] ASC, CategoryName ASC