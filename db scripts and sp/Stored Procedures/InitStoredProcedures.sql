DROP PROCEDURE CreateUser;
DROP PROCEDURE ReadUser;
DROP PROCEDURE UpdateUser;
DROP PROCEDURE DeleteUser;
GO
-- Create User
CREATE PROCEDURE CreateUser @Id int, 
							@Email varchar(255),
							@Phonenumber varchar(255),
							@UserPassword varchar(255),
							@Firstname varchar(255),
							@Surname varchar(255),
							@PostalCode int,
							@StreetAddress varchar(255)
AS
INSERT INTO Users
VALUES (
	@Id,
	@Email,
	@Phonenumber,
	@UserPassword,
	@Firstname,
	@Surname,
	@PostalCode,
	@StreetAddress
);
GO
-- Read User
CREATE PROCEDURE ReadUser   @Email varchar(255)
AS
SELECT * FROM Users where Email = @Email;
GO
-- Update user
CREATE PROCEDURE UpdateUser @Id int, 
							@Email varchar(255),
							@Phonenumber varchar(255),
							@UserPassword varchar(255),
							@Firstname varchar(255),
							@Surname varchar(255),
							@PostalCode int,
							@StreetAddress varchar(255)
AS
UPDATE Users
SET Email = @Email,
	Phonenumber = @Phonenumber,
	UserPassword = @UserPassword,
	Firstname = @Firstname,
	Surname = @Surname,
	PostalCode = @PostalCode,
	StreetAddress = @StreetAddress
WHERE Id = @Id;
GO
-- Delete user
CREATE PROCEDURE DeleteUser @Id int
AS
DELETE FROM Users WHERE Id = @Id;