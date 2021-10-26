SELECT 
	CONCAT(C.FirstName, ' ', C.LastName) AS CustomerName,
	C.PhoneNumber,
	C.Gender
	FROM Feedbacks F 
	RIGHT JOIN Customers C ON C.Id = F.CustomerId 
	WHERE F.Id IS NULL 
	ORDER BY C.Id