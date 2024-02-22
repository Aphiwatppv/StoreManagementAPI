using DataAccess.Models;
using DataAccess.SQLAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.DataBaseAccess;

public class MainStoreAccess : IMainStoreAccess
{
    private readonly ISqlDataAceess _sqlDataAceess;

    public MainStoreAccess(ISqlDataAceess sqlDataAceess)
    {
        _sqlDataAceess = sqlDataAceess;
    }
    #region Loading data Methods
    public async Task<IEnumerable<MainStoreItems>> spGetAllProduct() =>
        await _sqlDataAceess.LoadData<MainStoreItems, dynamic>(storedprocedures: "dbo.spGetAllProducts", new { });

    public async Task<IEnumerable<MainStoreItems>> spGetProductsCloseToAlertLimit() =>
        await _sqlDataAceess.LoadData<MainStoreItems, dynamic>(storedprocedures: "dbo.spGetProductsCloseToAlertLimit", new { });

    public async Task<MainStoreItems?> spGetRemainingStockByProductID(int id)
    {
        var result = await _sqlDataAceess.LoadData<MainStoreItems, dynamic>(storedprocedures: "dbo.spGetRemainingStockByProductID", new { ProductId = id });
        return result.FirstOrDefault();
    }

    public async Task<MainStoreItems?> spGetRemainingStockByProductName(string name)
    {
        var result = await _sqlDataAceess.LoadData<MainStoreItems, dynamic>(storedprocedures: "dbo.spGetRemainingStockByProductName", new { ProductName = name });
        return result.FirstOrDefault();
    }
    #endregion


    #region Saving data methods
    public async Task spAddNewProduct(MainStoreItems mainStoreItems)
    {
        await _sqlDataAceess.Savedata(storedprocedures: "dbo.spAddNewProduct", new
        {
            mainStoreItems.ID,
            mainStoreItems.ProductName,
            mainStoreItems.ProductID,
            mainStoreItems.StockQuantity,
            mainStoreItems.StockUnit,
            mainStoreItems.AlertingLimit,
            mainStoreItems.Price,
            mainStoreItems.PriceUnit,
            mainStoreItems.Description
        });
    }

    public async Task spRemoveProduct(int ID)
    {
        await _sqlDataAceess.Savedata(storedprocedures: "dbo.spRemoveProduct", new { productID = ID });
    }

    public async Task spIncreaseStock(int prodcutid, int amount)
    {
        await _sqlDataAceess.Savedata(storedprocedures: "dbo.spIncreaseStock", new { prodcutID = prodcutid, Amount = amount });
    }

    public async Task spDecreaseStock(int prodcutid, int amount)
    {
        await _sqlDataAceess.Savedata(storedprocedures: "dbo.spDecreaseStock", new { prodcutID = prodcutid, Amount = amount });
    }


    #endregion




}
