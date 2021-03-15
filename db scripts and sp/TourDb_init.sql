DROP TABLE Users;
DROP TABLE Cities;
DROP TABLE TourguideTimes;
DROP TABLE TourguideLanguages;
DROP TABLE Languages;
DROP TABLE Tourguides;
DROP TABLE TourTimes;
DROP TABLE TourguideTours;
DROP TABLE Tours;

DROP DATABASE TourDb;
CREATE DATABASE TourDb;

USE TourDb;
--User
CREATE TABLE Cities (
	PostalCode integer,
	City varchar(255),
	PRIMARY KEY(PostalCode)
);

CREATE TABLE Users (
	Id integer,
	Email varchar(255),
	Phonenumber varchar(255),
	UserPassword varchar(255),
	Firstname varchar(255),
	Surname varchar(255),
	PostalCode integer,
	Streetaddress varchar(255),
	PRIMARY KEY (Id),
	FOREIGN KEY (PostalCode) REFERENCES Cities(PostalCode)
);

-- Tourguide
CREATE TABLE Tourguides (
	Id integer,
	Email varchar(255),
	Phonenumber varchar(255),
	Firstname varchar(255),
	Surname varchar(255),
	PRIMARY KEY (Id),
);

CREATE TABLE TourguideTimes (
	DateAndTime datetime,
	Occupied bit,
	Tourguide_id integer,
	PRIMARY KEY (DateAndTime),
	FOREIGN KEY (Tourguide_id) REFERENCES Tourguides (Id)
);

CREATE TABLE Languages (
	Id int,
	LanguageName varchar(255),
	LanguageImage varchar(1024),
	PRIMARY KEY (Id),
);

CREATE TABLE TourguideLanguages (
	Id int,
	Language_id int,
	Tourguide_id int,
	PRIMARY KEY (Id),
	FOREIGN KEY (Language_id) REFERENCES Languages(Id),
	FOREIGN KEY (Tourguide_id) REFERENCES Tourguides(Id)
);

-- Tour
CREATE TABLE Tours (
	Id int,
	Price decimal,
	TourName varchar(255),
	TourImage varchar(1024),
	PRIMARY KEY (Id)
);

CREATE TABLE TourTimes (
	DateAndTime datetime,
	Occupied bit,
	Tour_id int,
	PRIMARY KEY (DateAndTime),
	FOREIGN KEY (Tour_id) REFERENCES Tours (Id)
);

CREATE TABLE TourguideTours (
	Id int,
	Tourguide_id int,
	Tour_id int,
	PRIMARY KEY (Id),
	FOREIGN KEY (Tour_id) REFERENCES Tours (Id),
	FOREIGN KEY (Tourguide_id) REFERENCES Tours (Id)
);