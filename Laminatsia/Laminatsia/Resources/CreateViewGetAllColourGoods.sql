CREATE PROCEDURE [GetColourGoodsByNotes]
	-- Add the parameters for the stored procedure here
	@FindInNotes nvarchar(100)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT * FROM dbo.ViewGetAllColourGoods WHERE dbo.ViewGetAllColourGoods.Notes LIKE  '%' + @FindInNotes + '%'
END;