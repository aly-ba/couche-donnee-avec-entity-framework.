-- Demo : Where Clause
-- One predicate
SELECT [sod].[SalesOrderID],
	   [sod].[SalesOrderDetailID]
FROM [Sales].[SalesOrderDetail] AS  [sod]
WHERE [sod].[CarrierTrackingNumber]=  '4911-403C-98';

SELECT [sod].[SalesOrderID],
	   [sod].[SalesOrderDetailID],
	   [sod].[SpecialOfferID],
	    [sod].[CarrierTrackingNumber]
FROM [Sales].[SalesOrderDetail] AS  [sod]
WHERE [sod].[CarrierTrackingNumber]=  '4911-403C-98' AND [sod].[SpecialOfferID] =1;

SELECT [sod].[SalesOrderID],
	   [sod].[SalesOrderDetailID],
	   [sod].[SpecialOfferID],
	    [sod].[CarrierTrackingNumber]
FROM [Sales].[SalesOrderDetail] AS  [sod]
WHERE [sod].[CarrierTrackingNumber]=  '4911-403C-98' OR [sod].[SpecialOfferID] =1  ;


