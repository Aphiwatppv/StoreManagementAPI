CREATE PROCEDURE [dbo].[spIncreaseStock]
    @ProductID INT,
    @Amount INT
AS
BEGIN
    UPDATE MainStoreTb
    SET StockQuantity = StockQuantity + @Amount
    WHERE ProductID = @ProductID
END
