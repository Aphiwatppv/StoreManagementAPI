using DataAccess.Models;

namespace DataAccess.DataBaseAccess;

public interface IMainStoreAccess
{
    Task spAddNewProduct(MainStoreItems mainStoreItems);
    Task spDecreaseStock(int prodcutid, int amount);
    Task<IEnumerable<MainStoreItems>> spGetAllProduct();
    Task<IEnumerable<MainStoreItems>> spGetProductsCloseToAlertLimit();
    Task<MainStoreItems?> spGetRemainingStockByProductID(int id);
    Task<MainStoreItems?> spGetRemainingStockByProductName(string name);
    Task spIncreaseStock(int prodcutid, int amount);
    Task spRemoveProduct(int ID);
}