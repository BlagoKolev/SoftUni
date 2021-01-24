SELECT * FROM [Orders]


SELECT [ProductName], [OrderDate],
DATEADD(day,3,[OrderDate]) AS 'Pay Due',
DATEADD(month,1,[OrderDate]) As 'Deliver Due'
	FROM [Orders]