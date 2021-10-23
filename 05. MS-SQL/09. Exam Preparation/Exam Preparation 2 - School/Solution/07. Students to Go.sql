SELECT
	s.FirstName + ' ' + s.LastName AS [Full Name]
FROM
Students AS s
LEFT JOIN StudentsExams AS se ON se.StudentId = s.Id
WHERE se.StudentId IS NULL
ORDER BY [Full Name]