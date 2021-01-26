USE [Geography]


--PROBLEM - 12
SELECT mc.[CountryCode], m.[MountainRange], [PeakName], [Elevation] FROM [MountainsCountries] AS mc
JOIN [Mountains] AS m ON m.[Id] = mc.[MountainId]
JOIN [Peaks] AS p ON p.[MountainId] = m.[Id]
WHERE mc.CountryCode = 'BG' AND p.[Elevation] > 2835
ORDER BY p.[Elevation] DESC;


--PROBLEM - 13
SELECT mc.[CountryCode], COUNT(m.[MountainRange]) AS [MountainRanges] FROM [Mountains] AS m
JOIN [MountainsCountries] AS mc ON m.[Id] = mc.[MountainId]
WHERE mc.[CountryCode] IN ('BG', 'RU', 'US')
GROUP BY mc.[CountryCode];


--PROBLEM - 14
  SELECT TOP(5) c.[CountryName], r.[RiverName]  FROM [CountriesRivers] AS cr
  JOIN [Rivers] AS r ON r.[Id] = cr.RiverId
  RIGHT JOIN [Countries] AS c ON c.[CountryCode] = cr.[CountryCode]
  WHERE c.[ContinentCode] = 'AF' 
  ORDER BY c.[CountryName];



  --PROBLEM - 15
SELECT [ContinentCode], [CurrencyCode], [CurrencyCount] AS CurrencyUsage FROM (
  SELECT [ContinentCode], [CurrencyCode], [CurrencyCount], 
  DENSE_RANK() OVER(PARTITION BY [ContinentCode] ORDER BY [CurrencyCount] DESC) AS [CurrencyRank]
		FROM (
	SELECT [ContinentCode], [CurrencyCode], COUNT(*) AS [CurrencyCount] FROM [Countries]
		GROUP BY [ContinentCode],[CurrencyCode]
		) AS [CurrencyCountQuery]
		WHERE [CurrencyCount] > 1) AS [CurrencyRankingQuery]
WHERE CurrencyRank = 1
ORDER BY [ContinentCode]



--PROBLEM - 16
SELECT COUNT([CountryCode]) AS [Count] FROM (
SELECT c.[CountryCode] , mc.[MountainId]  FROM [Countries] AS c
LEFT JOIN [MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
WHERE [MountainId] IS NULL) AS [CountQuery];


--PROBLEM - 17
SELECT TOP(5) c.[CountryName], MAX(p.[Elevation]) AS [HighestPeakElevation], MAX(r.[Length]) AS [LongestRiverLength]
	FROM [Countries] AS c
LEFT  JOIN [CountriesRivers] AS cr ON cr.CountryCode = c.[CountryCode]
LEFT  JOIN [Rivers] AS r ON r.[Id] = cr.[RiverId]
LEFT  JOIN [MountainsCountries] AS mc ON mc.[CountryCode] = c.[CountryCode]
LEFT JOIN [Mountains] AS m ON m.Id = mc.MountainId
LEFT JOIN [Peaks] AS p ON p.MountainId = m.[Id]
GROUP BY c.[CountryName]
ORDER BY [HighestPeakElevation] DESC,[LongestRiverLength] DESC,c.[CountryName]



-- PROBLEM - 18
SELECT TOP(5)[Country],
	CASE
		WHEN [PeakName] IS NULL THEN '(no highest peak)'
		ELSE [PeakName]
	END AS [Highest Peak Name],
	CASE
		WHEN [Elevation] IS NULL THEN  0
		ELSE [Elevation]
	END AS [Highest Peak Elevation],
CASE
		WHEN [MountainRange] IS NULL THEN  '(no mountain)'
		ELSE [MountainRange]
	END AS [Mountain] FROM
(
	SELECT *,DENSE_RANK() OVER(PARTITION BY [Country] ORDER BY [Elevation] DESC) AS [PeakRank]
	FROM (
			SELECT [CountryName] AS [Country], p.[PeakName],p.[Elevation],m.[MountainRange]
			FROM [Countries] AS c
			LEFT JOIN [MountainsCountries] AS mc ON mc.CountryCode = c.CountryCode
			LEFT JOIN [Mountains] AS m ON m.[Id] = mc.MountainId
			LEFT JOIN [Peaks] AS p ON p.[MountainId] = m.Id
		) AS [FullInfoQuery]
) AS [PeakRankingQuery]
WHERE [PeakRank] = 1
ORDER BY [Country], [Highest Peak Name]




--Support Queries
SELECT * FROM [Continents]
SELECT * FROM [Countries]
SELECT * FROM [CountriesRivers]
SELECT * FROM [Currencies]
SELECT * FROM [Mountains]
SELECT * FROM [MountainsCountries]
SELECT * FROM [Peaks]
SELECT * FROM [Rivers]