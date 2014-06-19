DECLARE @count INT
SET @count =1
WHILE (@count <= 10000)
BEGIN 
	INSERT INTO PASSES VALUES(15, 1,0,0,1,2013, 7,1);
SET @count = @count +1
END