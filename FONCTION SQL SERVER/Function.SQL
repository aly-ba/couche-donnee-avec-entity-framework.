-- SQL Server 2012


USE Northwind;
GO

--------------------------------------------
-- Scalar Functions
--------------------------------------------

CREATE FUNCTION dbo.fnProductsSold() 
	RETURNS INT
AS
	BEGIN
		DECLARE @Total AS INT;
		SELECT @Total = SUM(Quantity)
			FROM dbo.[Order Details];
		RETURN @Total;
	END
GO

SELECT dbo.fnProductsSold();
GO

SELECT AVG(UnitPrice) AS AvgPrice, 
	dbo.fnProductsSold() AS TotalSold
FROM Products;
GO

-- Scalar function with parameter
CREATE FUNCTION dbo.fnProductsSoldByProduct
	(@ProductID INT = null) 
	RETURNS INT
	WITH RETURNS NULL ON NULL INPUT
AS
	BEGIN
		DECLARE @total INT;
		SELECT @Total = SUM(Quantity)
			FROM dbo.[Order Details]
		WHERE ProductID = @ProductID;
		
		RETURN @Total;
	END
GO

SELECT dbo.fnProductsSoldByProduct(NULL);
SELECT dbo.fnProductsSoldByProduct(DEFAULT);
SELECT dbo.fnProductsSoldByProduct(3);

-- Causes an error:
SELECT dbo.fnProductsSoldByProduct();
GO

--------------------------------------------
-- Inline Table Valued Functions
--------------------------------------------

CREATE FUNCTION dbo.fnProductStatistics() 
	RETURNS TABLE 
AS
RETURN 
	SELECT dbo.fnProductsSold() AS UnitsSold, 
		SUM(UnitPrice * Quantity) AS TotalSales, 
		AVG(UnitPrice) AS AveragePrice, 
		COUNT(*) AS LineItems
	FROM dbo.[Order Details]; 
GO

-- returns an error
SELECT dbo.fnProductSelectStatistics();

-- correct calling syntax
SELECT * FROM dbo.fnProductStatistics();

SELECT UnitsSold, TotalSales, AveragePrice, LineItems 
FROM dbo.fnProductStatistics();
GO

-- Inline function with parameter
CREATE FUNCTION dbo.fnStatisticsByProduct
	(@ProductID INT = NULL) 
RETURNS TABLE 
AS
	RETURN 
		SELECT dbo.fnProductsSoldByProduct(@ProductID) 
			AS UnitsSold, 
			SUM(UnitPrice * Quantity) AS TotalSales, 
			COUNT(*) AS LineItems
		FROM dbo.[Order Details]
		WHERE ProductID = @ProductID; 
GO

-- execute the function
SELECT UnitsSold, TotalSales, LineItems
	FROM fnStatisticsByProduct(4);

SELECT *  FROM dbo.fnStatisticsByProduct(DEFAULT);

SELECT *  FROM dbo.fnStatisticsByProduct(NULL);
GO

-- Update from inline function
CREATE FUNCTION fnProductByID
	(@ProductID INT)
RETURNS TABLE 
AS
	RETURN 
		SELECT ProductID, ProductName, UnitPrice, UnitsInStock
		FROM dbo.Products
		WHERE ProductID = @ProductID
			AND Discontinued = 0;
GO

-- Execute as SELECT
-- Note the UnitsInStock value
SELECT * FROM dbo.fnProductByID(3);

-- Update data using the UDF
UPDATE dbo.fnProductByID(3)
	SET UnitsInStock = 63;

-- Display modified data
SELECT ProductID, UnitsInStock FROM dbo.fnProductByID(3);
GO

--------------------------------------------
-- Multi-Statement Table Valued Functions
--------------------------------------------

-- get orders by employee or country
CREATE FUNCTION dbo.fnOrdersByEmployee_Country
(
	@EmployeeID INT = NULL, 
	@ShipCountry nvarchar(15) = NULL
)
RETURNS @Order TABLE 
(
	ShipCountry nvarchar(15) NOT NULL,
	CustomerID nchar(5) NOT NULL,
	OrderID INT NOT NULL,
	EmployeeID INT NOT NULL
)
AS
BEGIN
	-- If all inputs null, return all rows.
	IF @EmployeeID IS NULL AND @ShipCountry IS NULL
		INSERT @Order 
		SELECT ShipCountry, CustomerID, OrderID, EmployeeID
			FROM dbo.Orders

	ELSE IF @EmployeeID IS NULL AND @ShipCountry IS NOT NULL
		-- Filter by ShipCountry.
		INSERT @Order
		SELECT ShipCountry, CustomerID, OrderID, EmployeeID
			FROM dbo.Orders
		WHERE ShipCountry=@ShipCountry

	ELSE IF @EmployeeID IS NOT NULL AND @ShipCountry IS NULL
		-- Filter by EmployeeID.
		INSERT @Order
		SELECT ShipCountry, CustomerID, OrderID, EmployeeID
			FROM dbo.Orders
		WHERE EmployeeID=@EmployeeID

	ELSE IF @EmployeeID IS NOT NULL AND @ShipCountry IS NOT NULL
		-- Filter by ShipCountry and EmployeeID.
		INSERT @Order
		SELECT ShipCountry, CustomerID, OrderID, EmployeeID
			FROM dbo.Orders
		WHERE ShipCountry = @ShipCountry AND EmployeeID = @EmployeeID
	RETURN
END;
GO

-- Execute the function, passing in NULL parameters
DECLARE @EmployeeID nchar(5) = NULL;
DECLARE @ShipCountry nvarchar(15) = NULL;

SELECT ShipCountry, CustomerID, OrderID, EmployeeID 
FROM dbo.fnOrdersByEmployee_Country(@EmployeeID, @ShipCountry)
ORDER BY ShipCountry, CustomerID, OrderID, EmployeeID;
GO

-- Filter on employee
SELECT ShipCountry, CustomerID, OrderID
FROM dbo.fnOrdersByEmployee_Country(6, NULL)
ORDER BY ShipCountry, CustomerID, OrderID;
GO

-- Rearrange column and sort orders
SELECT CustomerID, EmployeeID, OrderID 
FROM dbo.fnOrdersByEmployee_Country(NULL, 'Spain')
ORDER BY CustomerID, EmployeeID, OrderID;
GO

-- List distinct countries
SELECT DISTINCT ShipCountry
FROM dbo.fnOrdersByEmployee_Country(6, NULL);
GO

-- Joining functions to tables
SELECT E.LastName, E.FirstName, O.CustomerID, O.OrderID
FROM dbo.fnOrdersByEmployee_Country(NULL, 'Italy') AS O
INNER JOIN dbo.Employees AS E 
	ON O.EmployeeID = E.EmployeeID
ORDER BY E.LastName;
GO

---------------------------------------------------
-- Using Functions
---------------------------------------------------

-- Create a scalar function to calculate a discount
CREATE FUNCTION dbo.fnCalcDiscountPrice 
(
	@price MONEY,
	@discount INT
)
RETURNS MONEY
WITH RETURNS NULL ON NULL INPUT
AS
	BEGIN
		DECLARE @work MONEY
		SELECT @work = @price - (@price * (@discount * .01))
		RETURN @work
	END;
GO

-- Execute the function against the Products table
SELECT ProductID, ProductName, UnitPrice, 
	dbo.fnCalcDiscountPrice(UnitPrice,5) AS [5% Off],
	dbo.fnCalcDiscountPrice(UnitPrice,3) AS [3% Off]
FROM dbo.Products
ORDER BY UnitPrice DESC;

-- Using Table-Valued Functions in a subquery
-- Compute order total
IF Object_id('dbo.fnOrderTotal') IS NOT NULL
	DROP FUNCTION dbo.fnOrderTotal;
GO
CREATE FUNCTION dbo.fnOrderTotal()
RETURNS TABLE 
AS
	RETURN SELECT
		OrderID, SUM(UnitPrice*Quantity) AS Total
	FROM dbo.[Order Details] 
	GROUP BY OrderID
GO

-- Using functions in subqueries
SELECT O.CustomerID, O.OrderID, T.Total
FROM dbo.fnOrdersByEmployee_Country(NULL, 'USA') AS O
INNER JOIN dbo.fnOrderTotal() AS T
	ON O.OrderID = T.OrderID
WHERE T.Total >
	(SELECT AVG(Total) FROM dbo.fnOrderTotal())
ORDER BY CustomerID, Total DESC;
GO

---------------------------------------------------
-- UDF Performance
---------------------------------------------------

USE AdventureWorks2012;
GO

CREATE FUNCTION dbo.fnTotalOrders()
RETURNS MONEY
AS
	BEGIN
		RETURN (SELECT SUM(TotalDue) FROM Sales.SalesOrderHeader);
	END
GO

-- Test the function
SELECT dbo.fnTotalOrders();

SELECT TOP 1000 [SalesOrderID], [CarrierTrackingNumber], [OrderQty], 
	[UnitPrice], [LineTotal], (LineTotal/dbo.fnTotalOrders()) * 100 AS PercentOfTotal
FROM Sales.SalesOrderDetail

DECLARE @TotalOrders MONEY = dbo.fnTotalOrders();
SELECT TOP 1000 [SalesOrderID], [CarrierTrackingNumber], [OrderQty], 
	[UnitPrice], [LineTotal], (LineTotal/@TotalOrders) * 100 AS PercentOfTotal
FROM Sales.SalesOrderDetail

-- Cleanup
USE Northwind;
GO
IF Object_id('dbo.fnProductsSold') IS NOT NULL
  DROP FUNCTION dbo.fnProductsSold;
IF Object_id('dbo.fnProductsSoldByProduct') IS NOT NULL
  DROP FUNCTION dbo.fnProductsSoldByProduct;
IF Object_id('dbo.fnProductStatistics') IS NOT NULL
  DROP FUNCTION dbo.fnProductStatistics;
IF Object_id('dbo.fnStatisticsByProduct') IS NOT NULL
  DROP FUNCTION dbo.fnStatisticsByProduct;
IF Object_id('dbo.fnProductByID') IS NOT NULL
  DROP FUNCTION dbo.fnProductByID;
IF OBJECT_ID (N'dbo.fnOrdersByEmployee_Country') IS NOT NULL
   DROP FUNCTION dbo.fnOrdersByEmployee_Country;
IF Object_id('dbo.fnCalcDiscountPrice') IS NOT NULL
  DROP FUNCTION dbo.fnCalcDiscountPrice;
IF Object_id('dbo.fnOrderTotal') IS NOT NULL
  DROP FUNCTION dbo.fnOrderTotal;

USE AdventureWorks2012;
GO
IF Object_id('dbo.fnTotalOrders') IS NOT NULL
  DROP FUNCTION dbo.fnTotalOrders;
