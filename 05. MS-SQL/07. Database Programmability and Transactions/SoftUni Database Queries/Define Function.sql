CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(MAX), @word VARCHAR(MAX)) 
RETURNS BIT
AS
BEGIN
	DECLARE @Count INT = 1
	DECLARE @Letter VARCHAR(1)

	WHILE (LEN(@word) >= @Count)
	BEGIN
		SET @Letter = SUBSTRING(@word, @Count, 1)

		IF @setOfLetters NOT LIKE '%' + @Letter + '%'
			RETURN 0

		SET @Count += 1
	END
	RETURN 1 
END