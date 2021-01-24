SELECT [CountryName], [IsoCode] FROM [Countries]
	WHERE [CountryName] LIKE '%a%a%a%'
	ORDER BY [IsoCode];


SELECT [PeakName],[RiverName],LOWER(CONCAT(p.[PeakName],SUBSTRING(r.[RiverName],2,LEN(r.[RiverName])-1))) AS MIX
	FROM [Peaks] AS p, [Rivers] AS r
	WHERE  LEFT(r.[RiverName],1) LIKE RIGHT(p.[PeakName],1)
	ORDER BY [MIX]





