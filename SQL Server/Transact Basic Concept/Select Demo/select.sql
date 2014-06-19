-- Demo : SELECT CLAUSE
USE  AdventureWorks2012;

--No data source 
SELECT '1' As [col01],
		'2' AS [col2];

--check avaibl data source columns
EXEC sp_help 'Production.TransacionHistory';
--one data source
SELECT  [TransactionID],
		[ProductID],
		[Quantity],
		[ActualCost],
		'Batch 1' As [BatchID],
		([Quantity]* [ActualCost] ) AS [TotalCost]
FROM [Production].[TransactionHistory];
