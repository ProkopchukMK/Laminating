CREATE VIEW [ViewGetAllUsers]
AS
SELECT     ID, UserName, UserPassword, Role
FROM         dbo.Users;