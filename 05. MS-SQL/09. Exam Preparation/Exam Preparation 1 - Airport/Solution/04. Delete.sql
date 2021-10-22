-- Delete all flights to "Ayn Halagim".

DELETE FROM [dbo].[Tickets]
WHERE [FlightId] =
(
	SELECT Id FROM [dbo].[Flights]
	WHERE [Destination] = 'Ayn Halagim'
)

DELETE FROM [dbo].[Flights] WHERE [Destination] = 'Ayn Halagim'