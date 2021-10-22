--Select all people who don't have tickets. Select their first name, last name 
--and age .Order them by age (descending), first name (ascending) and last name 
--(ascending).

SELECT
	[FirstName],
	[LastName],
	[Age]
FROM [dbo].[Passengers]
WHERE Id NOT IN
(
	SELECT [PassengerId]
	FROM [dbo].[Tickets]
)
ORDER BY [Age] DESC, [FirstName] ASC, [LastName] ASC