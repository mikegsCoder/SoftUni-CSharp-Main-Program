CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
BEGIN
	
	DECLARE @result INT
	SET @result = 
				(
					SELECT COUNT(c.Id)
					FROM Planets AS p
					JOIN Spaceports AS s ON s.PlanetId = p.Id
					JOIN Journeys AS j ON j.DestinationSpaceportId = s.Id
					JOIN TravelCards AS t ON t.JourneyId = j.Id
					JOIN Colonists AS c ON c.Id = t.ColonistId
					--WHERE p.Name = 'Otroyphus'
					WHERE p.Name = @PlanetName
				);

	RETURN @result;
END