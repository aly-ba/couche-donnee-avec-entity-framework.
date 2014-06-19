
SELECT [sod].[salesOrderID]
FROM [Sales].[SalesOrderDetail] AS [sod]
WHERE [sod].[CarrierTrackingNumber] ='4911-403c-98';

--With DISTINCT
SELECT DISTINCT [sod].[SalesOrderID]
FROM [Sales].[SalesOrderDetail] AS [sod]
WHERE [sod].[CarrierTrackingNumber] ='4911-403c-98';

--Count of rows with null
SELECT Count(*)
FROM [Sales].[SalesOrderDetail] AS [sod]
WHERE [CarrierTrackingNumber] IS NULL;


