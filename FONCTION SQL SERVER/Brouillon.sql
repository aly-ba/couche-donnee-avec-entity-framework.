--get order by employee  or Country
CREATE FUNCTION dbo.fnOrderByEmployee(@EmployeeID INT =NULL,
@ShipCountry nvchar(15) =NULL)
RETURNS @Order TABLE
(
	ShipCountry nvarchar(15) NOT NULL,
	CustomerID nchar(5) NOT NULL,
	OrderID INT NOT NULL,
	EmployeeID INT NOT NULL,
)
AS
BEGIN 
	--if all inputs null, return all rows.
	IF @EmpolyeeID IS NULL AND @ShipCountry is NULL
		INSERT @Order
		SELECT  ShipCountry, CustomerID, OrderID, EmployeeID
				FROm dbo.Orders
	ELSE IF @EmployeeID IS NULL AND @ShipCountry IS NOT NULL
	--FIlter  by ShipCountry
	INSERT @Order
	SELECT ShipCountry, CustomerID, OrderID, EmployeeID
		FROM dbo.Orders;
	WHERE ShipCountry =@ShipCoutnry

   ELSE IF @EmployeeID IS NOT NULL AND @ShipCountry IS NULL
     --Filter by EmpoyeeID
	  INSERT @Order
	  SELECT ShipCountry , CustomerID, OrderID, EmployeeID
	    FROM dbo.Orderd
	  WHERE EmployeeID=@EmployeeID
	RETURN
END;
GO	
          