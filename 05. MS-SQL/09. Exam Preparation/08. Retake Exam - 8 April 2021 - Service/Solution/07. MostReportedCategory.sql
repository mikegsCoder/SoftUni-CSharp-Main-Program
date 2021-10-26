SELECT TOP (5) c.[Name] AS [CategoryName], COUNT(CategoryId) AS [ReportNumber]
	FROM Reports r
	JOIN Categories c ON c.Id = r.CategoryId
	GROUP BY CategoryId, c.[Name]
	ORDER BY ReportNumber DESC, [CategoryName] ASC

SELECT TOP(5)
	Name AS CategoryName,
	(SELECT COUNT(*) FROM Reports 
		WHERE CategoryId = c.Id) AS [ReportsNumber]
	FROM Categories c
	ORDER BY [ReportsNumber] DESC, CategoryName ASC