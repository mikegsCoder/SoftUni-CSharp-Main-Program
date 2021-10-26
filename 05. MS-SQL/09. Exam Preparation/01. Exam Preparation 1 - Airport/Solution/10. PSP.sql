--Select all planes with their name, seats count and passengers count. Order the 
--results by passengers count (descending), plane name (ascending) and seats 
--(ascending) 

SELECT
	p.[Name],
	p.[Seats],
	COUNT(t.PassengerId) AS [Passengers Count]
FROM [dbo].[Planes] AS p
LEFT JOIN [dbo].[Flights] AS f ON f.[PlaneId] = p.[Id]
LEFT JOIN [dbo].[Tickets] AS t ON t.[FlightId] = f.[Id]
GROUP BY p.[Name], p.[Seats]
ORDER BY [Passengers Count] DESC, p.[Name] ASC, p.[Seats] ASC