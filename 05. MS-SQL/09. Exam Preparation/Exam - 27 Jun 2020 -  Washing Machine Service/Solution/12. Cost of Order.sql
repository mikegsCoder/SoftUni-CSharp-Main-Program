CREATE FUNCTION udf_GetCost(@jobId INT)
RETURNS DECIMAL(15,2)
AS
BEGIN
	DECLARE @result DECIMAL(10, 2);
    SET @result =
         (
             SELECT ISNULL(SUM(P.Price * OP.Quantity), 0.00)
             FROM Orders AS O
                  JOIN OrderParts AS OP ON O.OrderId = OP.OrderId
                  JOIN Parts AS P ON P.PartId = OP.PartId
             WHERE JobId = @jobId
         );

         RETURN @result;
END