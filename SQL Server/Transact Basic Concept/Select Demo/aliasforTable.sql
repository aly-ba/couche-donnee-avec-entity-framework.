-- Demo: TAbles ALiases

-- Table allias
SELECT [dept].[Name]
FROM [HUmanResources]. [Department] AS [dept];

-- Compact table alias example
SELECT [d].[Name]
FROM [HumanResources].[Department] AS [d];

-- Counter -intuitive table alias example
SELECT [q].[Name]
FROM [HumanResources].[Department] AS [q];