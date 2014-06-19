Create table Positions (
	PositionId Int IDENTITY
	,Name NVARCHAR(100) NOT NULL
	,Abbreviation NVARCHAR(3) NOT NULL
	,PRIMARY KEY (PositionId)
);

INSERT INTO Positions values ('Quarterback', 'QB');
INSERT INTO Positions values ('Runningback', 'QB');
INSERT INTO Positions values ('Wide Receiver', 'WR');
 
ALTER TABLE Players ADD PositionId INT

INSERT INTO Players
values('Eyebe', 'TouchDown', 3);



ALTER TABLE Players
ADD CONSTRAINT FK_PLayers_Positions
FOREIGN KEY (PositionId)
REFERENCES  Positions(PositionId);

UPDATE Players
SET PositionId=1;