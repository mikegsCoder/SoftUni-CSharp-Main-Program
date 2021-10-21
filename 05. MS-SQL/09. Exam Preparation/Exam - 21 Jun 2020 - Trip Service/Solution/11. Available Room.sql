--11. Available Room

CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(MAX)
AS
BEGIN 
		
		DECLARE @Output VARCHAR(MAX) = (SELECT TOP(1) CONCAT('Room ', r.Id , ': ' , r.[Type] , 
													  ' (',r.Beds , ' beds) - $',(h.BaseRate + r.Price) * 2) 
							FROM Hotels h
							JOIN Rooms r ON r.HotelId = h.Id
							JOIN Trips t ON t.RoomId = r.Id
							WHERE @HotelId = r.HotelId 
								AND h.Id = @HotelId 
								AND ((@Date NOT BETWEEN ArrivalDate AND ReturnDate) AND CancelDate IS NULL) 
								AND Beds > @People
							ORDER BY (h.BaseRate + r.Price) * 2 DESC)
		IF(@Output IS NULL)
			SET @Output = 'No rooms available'

	RETURN @Output
END

GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)

SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)