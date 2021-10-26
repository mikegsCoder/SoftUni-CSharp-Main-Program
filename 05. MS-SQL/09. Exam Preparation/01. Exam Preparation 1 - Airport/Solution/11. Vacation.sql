--Create a user defined function, named udf_CalculateTickets(@origin, 
--@destination, @peopleCount) that receives an origin (town name), destination 
--(town name) and people count.
--The function must return the total price in format "Total price {price}"
--•	If people count is less or equal to zero return – "Invalid people count!"
--•	If flight is invalid return – "Invalid flight!"

CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
	DECLARE @totalPrice DECIMAL(18, 2)
	DECLARE @flightId INT

	IF(@peopleCount <= 0)
	RETURN 'Invalid people count!';

	SET @flightId = (SELECT TOP(1) Id 
					FROM [dbo].[Flights] 
					WHERE [Origin] = @origin AND [Destination] = @destination)
	IF(@flightId IS NULL)
	RETURN 'Invalid flight!';

	SET @totalPrice = (SELECT [Price] FROM [dbo].[Tickets] WHERE [FlightId] = @flightId) * @peopleCount;

	DECLARE @result NVARCHAR(MAX) = 'Total price ' + CAST(@totalPrice AS NVARCHAR);

	RETURN @result;
END

SELECT dbo.udf_CalculateTickets('Kolyshley','Rancabolang', 33)