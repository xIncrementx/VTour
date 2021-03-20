
-- Search and check if DB exists
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'TourDb')
	CREATE DATABASE [TourDb]
-- Else drop tables
ELSE
	DROP TABLE IF EXISTS Users;
	DROP TABLE IF EXISTS Cities;
	DROP TABLE IF EXISTS TourguideTimes;
	DROP TABLE IF EXISTS TourguideLanguages;
	DROP TABLE IF EXISTS Languages;
	DROP TABLE IF EXISTS Tourguides;
	DROP TABLE IF EXISTS TourTimes;
	DROP TABLE IF EXISTS TourguideTours;
	DROP TABLE IF EXISTS Tours;

USE TourDb

--User
CREATE TABLE Cities (
	PostalCode INT,
	City VARCHAR(255),
	PRIMARY KEY(PostalCode)
);

CREATE TABLE Users (
	Id INT IDENTITY(1,1),
	Email VARCHAR(255),
	PhoneNumber VARCHAR(255),
	HashedPassword VARCHAR(255),
	FirstName VARCHAR(255),
	Surname VARCHAR(255),
	PostalCode INT,
	StreetAddress VARCHAR(255),
	Country VARCHAR(255),
	PRIMARY KEY (Id),
	FOREIGN KEY (PostalCode) REFERENCES Cities(PostalCode)
);

-- Tourguide
CREATE TABLE Tourguides (
	Id INT IDENTITY(1,1),
	Email VARCHAR(255),
	PhoneNumber VARCHAR(255),
	FirstName VARCHAR(255),
	Surname VARCHAR(255),
	PRIMARY KEY (Id),
);

CREATE TABLE TourguideTimes (
	DateAndTime DATETIME,
	Occupied BIT,
	Tourguide_Id INT,
	PRIMARY KEY (DateAndTime),
	FOREIGN KEY (Tourguide_id) REFERENCES Tourguides (Id)
);

CREATE TABLE Languages (
	Id INT IDENTITY(1,1),
	LanguageName VARCHAR(255),
	LanguageImage VARCHAR(1024),
	PRIMARY KEY (Id),
);

CREATE TABLE TourguideLanguages (
	Id INT IDENTITY(1,1),
	Language_Id INT,
	Tourguide_Id INT,
	PRIMARY KEY (Id),
	FOREIGN KEY (Language_id) REFERENCES Languages(Id),
	FOREIGN KEY (Tourguide_id) REFERENCES Tourguides(Id)
);

-- Tour
CREATE TABLE Tours (
	Id INT IDENTITY(1,1),
	Price DECIMAL,
	TourName VARCHAR(255),
	TourImage VARCHAR(1024),
	PRIMARY KEY (Id)
);

CREATE TABLE TourTimes (
	DateAndTime DATETIME,
	Occupied BIT,
	Tour_Id INT,
	PRIMARY KEY (DateAndTime),
	FOREIGN KEY (Tour_id) REFERENCES Tours (Id)
);

CREATE TABLE TourguideTours (
	Id INT,
	Tourguide_Id INT,
	Tour_Id INT,
	PRIMARY KEY (Id),
	FOREIGN KEY (Tour_id) REFERENCES Tours (Id),
	FOREIGN KEY (Tourguide_id) REFERENCES Tours (Id)
);