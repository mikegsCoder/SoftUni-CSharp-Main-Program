CREATE OR ALTER PROCEDURE usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN

SELECT
	c.CigarName,
	CONCAT('$',c.PriceForSingleCigar) AS Price,
	t.TasteType,
	b.BrandName,
	CONCAT(s.[Length], ' cm') AS CigarLength,
	CONCAT(s.RingRange, ' cm') AS CigarRingRange
FROM Tastes AS t
JOIN Cigars AS c ON c.TastId = t.Id
JOIN Sizes AS s ON s.Id = c.SizeId
JOIN Brands AS b ON b.Id = c.BrandId
WHERE t.TasteType = @taste
ORDER BY CigarLength, CigarRingRange DESC

END

EXEC usp_SearchByTaste 'Woody'