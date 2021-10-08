CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS varchar(MAX)
AS
BEGIN
	IF (@Salary < 30000) RETURN 'Low';
	ELSE IF (@salary <= 50000) RETURN 'Average';
	ELSE RETURN 'High';
	RETURN '';
END

-------------------------------------------------------------

CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS varchar(MAX)
AS
BEGIN
	RETURN
		CASE
			WHEN @salary < 30000 THEN 'Low'
			WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
			ELSE 'High'
		END	
END