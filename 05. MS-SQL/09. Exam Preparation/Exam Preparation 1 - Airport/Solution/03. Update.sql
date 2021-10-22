-- Make all flights to "Carlsbad" 13% more expensive.

UPDATE [dbo].[Tickets]
SET [Price] = [Price] * 1.13
WHERE [FlightId] = 
(
	SELECT Id FROM [dbo].[Flights]
	WHERE [Destination] = 'Carlsbad'
)