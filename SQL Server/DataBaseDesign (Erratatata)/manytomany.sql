ALTER TABLE Players DROP CONSTRAINT FK_Players_Positions;
ALTER TABLE Players DROP COLUMN PositionId;

CREATE TABLE PlayersPositions (
	PlayerId INT
	,PositionId INT
	,PRIMARY KEY(PlayerId, Positionid)
);

INSERT INTO PlayersPositions VALUES (5, 2);
INSERT INTO PlayersPositions VALUES (5, 3);

SELECT * FROM PlayersPositions;

INSERT INTO Players VALUES ('Calvin', 'Johnson');

INSERT INTO PlayersPositions VALUES (6, 2);

ALTER TABLE PlayersPositions
ADD CONSTRAINT FK_PlayersPositions_Players
FOREIGN KEY (PlayerId)
REFERENCES Players(PlayerId)

ALTER TABLE PlayersPositions
ADD CONSTRAINT FK_PlayersPositions_Positions
FOREIGN KEY (PositionId)
REFERENCES Positions(PositionId)
