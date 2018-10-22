CREATE VIEW [ViewGetAllArchive]
AS
SELECT     ID, ID_ColourGoods, DateComing, Profile, City, Dealer, Notes, Counts, Colour, DateToWork, DateReady, StatusProfile, StatusGoods, Action, UserName, 
                      DataTimeChange, Role
FROM         dbo.Archive;