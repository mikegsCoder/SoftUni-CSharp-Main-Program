SELECT Username, c.Name AS [CategoryName]
	FROM Reports r
	JOIN Users u
	ON u.Id = r.UserId
	JOIN Categories c
	ON c.Id = r.CategoryId
	WHERE DATEPART(month, r.OpenDate) = DATEPART(month, u.Birthdate) AND DATEPART(day, r.OpenDate) = DATEPART(day, u.Birthdate)
	ORDER BY Username ASC, CategoryName ASC

SELECT Username, c.Name AS [CategoryName]
	FROM Reports r
	JOIN Users u
	ON u.Id = r.UserId
	JOIN Categories c
	ON c.Id = r.CategoryId
	WHERE FORMAT(r.OpenDate, 'MM-dd') = FORMAT(u.Birthdate, 'MM-dd')
	ORDER BY Username ASC, CategoryName ASC