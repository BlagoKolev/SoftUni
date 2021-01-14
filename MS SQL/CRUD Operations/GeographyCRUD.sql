USE [Geography];

SELECT [PeakName] FROM [Peaks]
	ORDER BY [PeakName];

SELECT TOP(30) [CountryName], [Population] FROM [Countries]
	WHERE [ContinentCode] = 'EU'
	ORDER BY [Population] DESC, [CountryName];

SELECT [CountryName],[CountryCode], 
	CASE
		WHEN [CurrencyCode] = 'EUR' THEN 'Euro'
		WHEN [CurrencyCode] != 'EUR' THEN 'Not Euro'
		WHEN [CurrencyCode] IS NULL THEN 'Not Euro'
		END AS [Currency]
		FROM [Countries]
		ORDER BY [CountryName];