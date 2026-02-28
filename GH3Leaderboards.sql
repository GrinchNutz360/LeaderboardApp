--fine, ill do it myself.
USE master
GO

ALTER DATABASE GH3DB
SET SINGLE_USER WITH ROLLBACK IMMEDIATE
GO

DROP DATABASE IF EXISTS GH3DB

CREATE DATABASE GH3DB
GO

CREATE TABLE Users(
userID smallint NOT NULL PRIMARY KEY,
username varchar(50) NOT NULL,
email varchar(60) NOT NULL
)
GO

CREATE TABLE Songs(
songID smallint NOT NULL PRIMARY KEY,
songName varchar(100) NOT NULL,
songArtist varchar(50) NOT NULL,
coveredBy varchar(50) NULL
)
GO

CREATE TABLE Scores(
scoreID smallint NOT NULL PRIMARY KEY,
userID smallint NOT NULL FOREIGN KEY REFERENCES Users(userID),
songID smallint NOT NULL FOREIGN KEY REFERENCES Songs(songID),
score int NOT NULL
)
GO

INSERT INTO Users(userID, username, email)
VALUES
(001, 'admin', 'coleneely87@gmail.com'),
(002, 'moosejaw', 'email1@email.com'),
(003, 'abe','mclovin@gmail.com')
GO

-- for now, only going to have the first ten songs of the career.
INSERT INTO Songs(songID, songName, songArtist, coveredBy)
VALUES
(01, 'Slow Ride', 'Foghat', 'Wavegroup'),
(02,'Talk Dirty to Me', 'Poison', 'Steve Ouimette'),
(03,'Hit Me With Your Best Shot', 'Pat Benatar', 'Steve Ouimette'),
(04, 'Story of My Life', 'Social Distortion', 'Wavegroup'),
(05,'Rock And Roll All Nite', 'KISS', 'LINE6'),
(06,'Mississippi Queen', 'Mountain', 'Steve Ouimette'),
(07,'Schools Out','Alice Cooper','Steve Ouimette'),
(08,'Sunshine of Your Love', 'Cream', 'LINE6'),
(09,'Barracuda', 'Heart', 'Steve Ouimette'),
(10,'Bulls on Parade','Rage Against the Machine',NULL)
GO

INSERT INTO Scores(ScoreID, userID, songID, score)
VALUES
(1,001,05, 200987),
(2,003,10, 1009),
(3,003, 04, 9999999)
GO

UPDATE Scores SET score = 9999
WHERE ScoreID = 1


-- general score view!
SELECT username, songName, score
FROM Scores

INNER JOIN Users ON Scores.userID = Users.userID
INNER JOIN Songs ON Scores.songID = Songs.songID

ORDER BY score DESC
