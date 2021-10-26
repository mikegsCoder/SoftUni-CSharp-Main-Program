SELECT TOP(10)
	s.FirstName,
	s.LastName,
	CAST(AVG(se.Grade) AS DECIMAL(3, 2)) AS Grade
FROM Students AS s
JOIN StudentsExams AS se ON se.StudentId = s.Id
GROUP BY s.Id, s.FirstName, s.LastName
ORDER BY Grade DESC, s.FirstName, s.LastName