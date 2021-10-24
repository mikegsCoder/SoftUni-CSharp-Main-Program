SELECT 
  ISNULL((e.FirstName + ' ' + e.LastName),'None') AS [Employe],
  ISNULL(d.[Name], 'None') AS [Department],
  c.[Name] AS [Category],
  r.[Description] AS [Description],
  FORMAT(r.OpenDate, 'dd.MM.yyyy') AS [OpenDate],
  s.[Label] AS [Status],
  u.[Name] AS [User]
	FROM Reports r
	LEFT JOIN Employees e
	ON e.Id = r.EmployeeId
	LEFT JOIN Categories c
	ON c.Id = r.CategoryId
	LEFT JOIN Departments d
	ON d.Id = e.DepartmentId
	LEFT JOIN [Status] s
	ON s.Id = r.StatusId
	LEFT JOIN Users u
	ON u.Id = r.UserId
	ORDER BY FirstName DESC, LastName DESC, [Department] ASC, [Category] ASC, [Description] ASC, r.OpenDate ASC, [Status] ASC, [User] ASC