CREATE PROCEDURE [dbo].[spGetRemainingStockByProductName]
	@Productname NVARCHAR(255)
AS
BEGIN
    SELECT ProductName, StockQuantity --select two heades 
    FROM MainStoreTb
    WHERE ProductName = @ProductName
END