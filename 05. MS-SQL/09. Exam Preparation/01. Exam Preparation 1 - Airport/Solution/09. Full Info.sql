--Select all passengers who have trips. Select their full name (first name – 
--last name), plane name, trip (in format {origin} - {destination}) and luggage 
--type. Order the results by full name (ascending), name (ascending), origin 
--(ascending), destination (ascending) and luggage type (ascending).

SELECT
	p.[FirstName] + ' ' + p.[LastName] AS [Full Name],
	pl.[Name] AS [Plane Name],
	f.Origin + ' - ' + f.Destination AS Trip,
	lt.[Type] AS [Luggage Type]
FROM Passengers p
	JOIN Tickets t
	ON t.PassengerId = p.Id
	JOIN Flights f
	ON t.FlightId = F.Id
	JOIN Planes pl
	ON f.PlaneId = pl.Id
	JOIN Luggages l
	ON t.LuggageId = l.Id
	JOIN LuggageTypes lt
	ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]