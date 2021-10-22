--Select the total profit for each flight from database. Order them by total 
--price (descending), flight id (ascending).

SELECT
	f.Id AS FlightId,
	SUM(t.Price) AS Price
FROM [dbo].[Flights] AS f
JOIN [dbo].[Tickets] AS t ON t.[FlightId] = f.Id
GROUP BY f.Id
ORDER BY Price DESC, f.Id ASC