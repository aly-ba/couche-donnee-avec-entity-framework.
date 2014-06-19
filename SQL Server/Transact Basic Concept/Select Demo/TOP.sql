-- Demo : TOP

--No Top
SELECT [FirstName],
		[LastName],
		[StartDate],
		[EndDate]
FROM [HumanResources].[vEmployeeDepartmentHistory] AS [edh]
ORDER By [edh].[StartDate];

--Top Rows
SELECT TOP(10)
		[FirstName],
		[LastName],
		[StartDate],
		[EndDate]
FROM [HumanResources].[vEmployeeDepartmentHistory] AS [edh]
ORDER By [edh].[StartDate];

SELECT TOP(50) PERCENT
		[FirstName],
		[LastName],
		[StartDate],
		[EndDate]
FROM [HumanResources].[vEmployeeDepartmentHistory] AS [edh]
ORDER By [edh].[StartDate];


SELECT TOP(10) WITH TIES
		[FirstName],
		[LastName],
		[StartDate],
		[EndDate]
FROM [HumanResources].[vEmployeeDepartmentHistory] AS [edh]
ORDER By [edh].[StartDate];