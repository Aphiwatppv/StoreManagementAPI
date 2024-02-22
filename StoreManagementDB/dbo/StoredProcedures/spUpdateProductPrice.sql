CREATE PROCEDURE [dbo].[spUpdateProductPrice]
    @ProductID INT,
    @NewPrice DECIMAL(19, 4)
AS
BEGIN
    SET NOCOUNT ON;

    -- Check if the product exists
    IF NOT EXISTS (SELECT 1 FROM MainStoreTb WHERE ProductID = @ProductID)
    BEGIN
        RAISERROR('Product not found', 16, 1);
        RETURN;
    END

    -- Update the price of the product
    UPDATE MainStoreTb
    SET Price = @NewPrice
    WHERE ProductID = @ProductID;
END;