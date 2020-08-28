CREATE PROC SP_user_Add
@FirstName NVARCHAR (30),
@LastName NVARCHAR (30),
@Phone NVARCHAR (30),
@Email NVARCHAR (30)
AS
BEGIN
INSERT INTO Users VALUES(
@FirstName,
@LastName,
@Phone,
@Email
)
END