USE NFL;
CREATE TABLE Passes (
	Quarterback NVARCHAR(50)
	,Attempts INT
	,Completions INT
	,Yards INT
	,Touchdowns INT
	,Interceptions INT
	,Year INT
	,Week INT
);
GO

INSERT INTO Passes VALUES ('Peyton Manning', 33, 42, 414, 4, 1, 2013, 5);
INSERT INTO Passes VALUES ('Tony Romo', 25, 36, 506, 5, 1, 2013, 5);

SELECT * FROM Passes;

DROP TABLE Passes;
CREATE TABLE Passes (
	Quarterback NVARCHAR(50)
	,YardsGained INT
	,Quarter INT
	,WasTouchdown BIT
	,WasInterception BIT
	,WasComplete BIT
	,Year INT
	,Week INT
);

INSERT INTO PASSES VALUES ('Peyton Manning', 23, 1, 0, 0, 1, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 7, 1, 0, 0, 1, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 12, 1, 0, 0, 1, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 0, 1, 0, 0, 0, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 15, 1, 1, 0, 1, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 15, 1, 1, 0, 1, 2013, 5);
INSERT INTO PASSES VALUES ('Peyton Manning', 15, 1, 1, 0, 1, 2013, 5);

INSERT INTO PASSES VALUES ('Peyton Manning', 28, 1, 1, 0, 1, 2013, 6);

SELECT COUNT(YardsGained) As TotalYards 
FROM Passes
WHERE Quarterback = 'Peyton Manning' AND (Year = 2013 AND Week = 5);

SELECT COUNT(WasTouchdown) As Touchdowns 
FROM Passes
WHERE Quarterback = 'Peyton Manning' AND WasTouchdown = 1 AND (Year = 2013 AND Week = 5);