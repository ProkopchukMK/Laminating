CREATE VIEW [ViewGetAllColourGoods]
AS
SELECT     TOP (100) PERCENT ID, DateComing,
                          (SELECT     NameProfile
                            FROM          dbo.Profile
                            WHERE      (dbo.ColourGoods.Profile_ID = ID)) AS NameProfile,
                          (SELECT     City
                            FROM          dbo.Dealer
                            WHERE      (dbo.ColourGoods.Dealer_ID = ID)) AS City,
                          (SELECT     DealerName
                            FROM          dbo.Dealer AS Dealer_1
                            WHERE      (dbo.ColourGoods.Dealer_ID = ID)) AS DealerName, Notes, Counts,
                          (SELECT     Colour
                            FROM          dbo.ColourProfile
                            WHERE      (dbo.ColourGoods.Colour_ID = ID)) AS Colour, DateToWork, StatusProfile, DateReady, StatusGoods, DateRemove
FROM         dbo.ColourGoods
ORDER BY ID;