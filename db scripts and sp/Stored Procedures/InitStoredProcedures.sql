DROP PROCEDURE IF EXISTS CreateUser;
DROP PROCEDURE IF EXISTS ReadUser;
DROP PROCEDURE IF EXISTS UpdateUser;
DROP PROCEDURE IF EXISTS DeleteUser;
GO

-- Create User
CREATE PROCEDURE CreateUser 
@Email varchar(255),
@PhoneNumber varchar(255),
@HashedPassword varchar(255),
@FirstName varchar(255),
@Surname varchar(255),
@PostalCode int,
@StreetAddress varchar(255),
@Country varchar(255)
AS INSERT INTO Users
VALUES (
@Email,
@PhoneNumber,
@HashedPassword,
@FirstName,
@Surname,
@PostalCode,
@StreetAddress,
@Country
);
GO

-- Read User
CREATE PROCEDURE ReadUser @Email varchar(255)
AS
SELECT * FROM Users where Email = @Email;
GO

-- Update user
CREATE PROCEDURE UpdateUser 
@Email varchar(255),
@PhoneNumber varchar(255),
@HashedPassword varchar(255),
@FirstName varchar(255),
@Surname varchar(255),
@PostalCode int,
@StreetAddress varchar(255)
AS
UPDATE Users
SET 
FirstName = @FirstName,
Surname = @Surname,
Email = @Email,
PhoneNumber = @PhoneNumber,
HashedPassword = @HashedPassword,
PostalCode = @PostalCode,
StreetAddress = @StreetAddress
WHERE Email = @Email;
GO

-- Delete user
CREATE PROCEDURE DeleteUser @Id int
AS
DELETE FROM Users WHERE Id = @Id;