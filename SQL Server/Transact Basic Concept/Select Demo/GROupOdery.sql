-- Demo: GROUP BY clause

-- GROUP BY , single Column (notice it isn't ordered)
SELECT [sod].[ProductID],
		SUM([sod].OrderQty) AS [OrderQtyByProdcutId]
FROM [sales].[SalesOrderDetail] AS[sod]
GROUP By [sod].[ProductID];

-- GROUP BY , single Column ( ordered)
SELECT [sod].[ProductID],
		SUM([sod].OrderQty) AS [OrderQtyByProdcutId]
FROM [sales].[SalesOrderDetail] AS[sod]
GROUP By [sod].[ProductID]
ORDER By [sod].[ProductID];

--GROUP BY, mutli-column , with ordering
SELECT [sod].[ProductID],
		SUM([sod].OrderQty) AS [OrderQtyByProdcutId]
FROM [sales].[SalesOrderDetail] AS[sod]
GROUP By [sod].[ProductID],
			[sod].[SpecialOfferID]
ORDER By [sod].[ProductID];

