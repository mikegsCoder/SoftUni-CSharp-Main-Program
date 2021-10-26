CREATE VIEW v_UserWithCountries AS
SELECT
	c.FirstName + ' ' + c.LastName AS CustomerName,
	c.Age,
	c.Gender,
	co.[Name] AS CountryName
FROM Customers AS c
LEFT JOIN Countries AS co ON c.CountryId = co.Id