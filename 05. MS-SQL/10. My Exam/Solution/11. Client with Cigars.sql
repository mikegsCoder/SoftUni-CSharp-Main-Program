CREATE FUNCTION udf_ClientWithCigars(@name NVARCHAR(30))
RETURNS INT
AS
BEGIN

	DECLARE @result INT = (SELECT TOP(1) COUNT(ci.Id)
						   FROM Clients AS c
						   JOIN ClientsCigars AS cs ON cs.ClientId = c.Id
						   JOIN Cigars AS ci ON ci.Id = cs.CigarId
						   WHERE c.FirstName = @name
						   GROUP BY c.Id)

	RETURN ISNULL(@result, 0)

END

GO

SELECT dbo.udf_ClientWithCigars('Betty')