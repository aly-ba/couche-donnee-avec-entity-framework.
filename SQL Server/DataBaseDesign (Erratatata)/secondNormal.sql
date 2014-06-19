SELECT * FROM Passes;

CREATE TABLE Players (
	PlayerId INT IDENTITY
	,FirstName NVARCHAR(100)
	,LastName NVARCHAR(100)
	,PRIMARY KEY(PlayerId)
);

INSERT INTO Players VALUES ('Peyton', 'Manning');

SELECT * FROM Players;

ALTER TABLE Passes DROP COLUMN Quarterback;
ALTER TABLE Passes ADD PlayerId INT;

UPDATE Passes
SET PlayerId = 1


SELECT pl.FirstName + pl.LastName AS PlayerName
		,COUNT(WasTouchdown) 
FROM Passes AS p
INNER JOIN Players AS pl
ON p.PlayerId = pl.PlayerId
WHERE WasTouchdown = 1
GROUP BY pl.FirstName + pl.LastName