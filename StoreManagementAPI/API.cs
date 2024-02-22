using Microsoft.OpenApi.Models;

namespace StoreManagementAPI;

public static class API
{
    public static void ConfigurationAPI(this WebApplication app)
    {
        // Mapping Endpoint of API // Get, Post , Put ,Delete Base URL then Endpoint
        app.MapGet(pattern: "/GetAllProducts", GetAllProducts);
        app.MapGet(pattern: "/GetProductsCloseToAlertLimit/", GetProductsCloseToAlertLimit);
        app.MapGet(pattern: "/GetRemainingStockByProductName/{name}", GetRemainingStockByProductName);
        app.MapGet(pattern: "/GetRemainingStockByProductID/{ID}", GetRemainingStockByProductID);
        app.MapPost(pattern: "/IncreaseStock/", IncreaseStock);
        app.MapPost(pattern: "/DecreaseStock/", DecreaseStock);
        app.MapPut(pattern: "/UpdateProductPrice/", UpdateProductPrice);
        app.MapDelete(pattern: "/RemoveProduct/{ID}", RemoveProduct);

    }

    public static async Task<IResult> GetAllProducts(IMainStoreAccess storeAccess)
    {
        try
        {
            return Results.Ok(await storeAccess.spGetAllProduct());
        }
        catch(Exception ex)
        {
            return Results.Problem(ex.Message); 
        }
    }
    public static async Task<IResult> AddNewProduct(IMainStoreAccess storeAccess, MainStoreItems mainStoreItems)
    {
        try
        {
            await storeAccess.spAddNewProduct(mainStoreItems);
            return Results.Ok("Product added successfully.");
        } 
        catch(Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
    public static async Task<IResult> RemoveProduct(IMainStoreAccess storeAccess, int id)
    {
        try
        {
            await storeAccess.spRemoveProduct(id);
            return Results.Ok("Product removed successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
    public static async Task<IResult> IncreaseStock(IMainStoreAccess storeAccess, int id , int amount)
    {
        try
        {
            await storeAccess.spIncreaseStock(id,amount);
            return Results.Ok("Increased stock successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
    public static async Task<IResult> DecreaseStock(IMainStoreAccess storeAccess, int id, int amount)
    {
        try
        {
            await storeAccess.spDecreaseStock(id, amount);
            return Results.Ok("Decreased stock successfully.");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }

    }
    public static async Task<IResult> GetProductsCloseToAlertLimit(IMainStoreAccess storeAccess)
    {
        try
        {
            return Results.Ok(await storeAccess.spGetProductsCloseToAlertLimit());
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    public static async Task<IResult> GetRemainingStockByProductID(IMainStoreAccess storeAccess,int id)
    {
        try
        {
            return Results.Ok(await storeAccess.spGetRemainingStockByProductID(id));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
    public static async Task<IResult> GetRemainingStockByProductName(IMainStoreAccess storeAccess,string name)
    {
        try
        {
            return Results.Ok(await storeAccess.spGetRemainingStockByProductName(name));
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    public static async Task<IResult> UpdateProductPrice(IMainStoreAccess storeAccess, int id , decimal newprice)
    {
        try
        {
            await storeAccess.spUpdateProductPrice(id, newprice);
            return Results.Ok($"Price of product:{id} has already updated");
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }





}
