CREATE OR ALTER PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN

	DECLARE @tripHotel INT = 
							(SELECT r.HotelId 
							 FROM Trips AS t 
							 JOIN Rooms AS r ON R.Id = t.RoomId 
							 WHERE t.Id = @TripId)
	
	DECLARE @roomHotel INT = 
							(SELECT HotelId 
							 FROM Rooms 
							 WHERE Id = @TargetRoomId)

	IF (@tripHotel <> @roomHotel)
		THROW 50001, 'Target room is in another hotel!', 1

	DECLARE @bedsNeeded INT = 
							(SELECT COUNT(*) 
							 FROM AccountsTrips 
							 WHERE TripId = @TripId)
	
	DECLARE @beds INT = 
						(SELECT Beds 
						 FROM Rooms 
						 WHERE Id = @TargetRoomId)
	
	IF (@bedsNeeded > @beds)
		THROW 50002, 'Not enough beds in target room!', 1

	UPDATE 
		Trips 
		SET RoomId = @TargetRoomId 
		WHERE Id = @TripId

END