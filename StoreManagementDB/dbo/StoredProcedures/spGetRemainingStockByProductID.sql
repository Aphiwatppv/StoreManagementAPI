CREATE PROCEDURE [dbo].[spGetRemainingStockByProductID]
@ProductID INT
AS
BEGIN
    SELECT ProductName, ProductID, StockQuantity
    FROM MainStoreTb
    WHERE ProductID = @ProductID
END