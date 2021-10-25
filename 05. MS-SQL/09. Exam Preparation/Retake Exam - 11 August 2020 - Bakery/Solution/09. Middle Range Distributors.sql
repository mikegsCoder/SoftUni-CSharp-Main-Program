SELECT
	d.[Name] AS DistributorName,
	i.[Name] AS IngredientName,
	P.[Name] AS ProductName,
	AVG(f.Rate) AS AverageRate
FROM Distributors AS d
LEFT JOIN Ingredients AS i ON i.DistributorId = d.Id
LEFT JOIN ProductsIngredients AS pri ON pri.IngredientId = i.Id
LEFT JOIN Products as p ON p.Id = pri.ProductId
LEFT JOIN Feedbacks AS f ON f.ProductId = p.Id
GROUP BY d.[Name], i.[Name], p.[Name]
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.[Name], i.[Name], p.[Name]