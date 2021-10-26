--Select the top 5 repositories in terms of count of commits. Order them by 
--commits count (descending), repository id (ascending) then by repository name 
--(ascending).

SELECT TOP(5)
	r.Id,
	r.Name,
	COUNT(c.RepositoryId) AS Commits
FROM Repositories AS r
JOIN Commits AS c ON r.Id = c.RepositoryId
LEFT JOIN RepositoriesContributors rc ON rc.RepositoryId = r.Id
GROUP BY r.Id, r.Name, c.RepositoryId
ORDER BY Commits DESC, r.Id ASC, r.Name ASC