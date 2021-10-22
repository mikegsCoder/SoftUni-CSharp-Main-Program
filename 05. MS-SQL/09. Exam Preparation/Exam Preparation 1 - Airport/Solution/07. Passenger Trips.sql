--Select the full name of the passengers with their trips (origin - destination). 
--Order them by full name (ascending), origin (ascending) and destination 
--(ascending).

SELECT
	p.FirstName + ' ' + p.LastName AS [Full Name],
	f.Origin,
	f.Destination
FROM [dbo].[Passengers] AS p
JOIN [dbo].[Tickets] AS t ON t.[PassengerId] = p.Id
JOIN [dbo].[Flights] AS f ON f.Id = t.[FlightId]
ORDER BY [Full Name], f.Origin, f.Destination