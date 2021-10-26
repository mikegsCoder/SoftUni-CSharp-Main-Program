CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN

	BEGIN TRANSACTION

		DECLARE @purpose VARCHAR(11)
		SET @purpose = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId);

		IF(@purpose IS NULL)
			BEGIN
					ROLLBACK
					RAISERROR('The journey does not exist!', 16, 1)
					RETURN
			END

		IF(@purpose = @NewPurpose)
			BEGIN
					ROLLBACK
					RAISERROR('You cannot change the purpose!', 16, 2)
					RETURN
			END

		UPDATE Journeys SET Purpose = @NewPurpose WHERE Id = @JourneyId;
	COMMIT

END