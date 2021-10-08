--Select all users which have commits. Select their username and average size 
--of the file, which were uploaded by them. Order the results by average upload 
--size (descending) and by username (ascending).

SELECT
	u.Username,
	AVG(f.Size) AS Size
FROM Users AS u
JOIN Commits AS c ON u.Id = c.ContributorId
JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC, u.Username ASC