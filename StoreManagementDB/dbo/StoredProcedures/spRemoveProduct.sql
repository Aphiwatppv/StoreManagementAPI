CREATE PROCEDURE [dbo].[spRemoveProduct]
    @ProductID INT
AS
BEGIN
    DELETE FROM MainStoreTb
    WHERE ProductID = @ProductID
END