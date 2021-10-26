SELECT FirstName + ' ' + LastName AS FullName,
	(SELECT COUNT(DISTINCT UserId) FROM Reports WHERE EmployeeId = e.Id) AS UsersCount
	FROM Employees e 
	ORDER BY UsersCount DESC, FullName ASC

SELECT FirstName + ' ' + LastName AS [FullName], COUNT(DISTINCT UserId) AS UsersCount
	FROM Reports r
	RIGHT JOIN Employees e
	ON e.Id = r.EmployeeId
	GROUP BY EmployeeId, FirstName, LastName
	ORDER BY UsersCount DESC, FullName ASC