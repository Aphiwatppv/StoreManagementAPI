using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models;

public class MainStoreItems
{
    public int ID { get; set; }
    public string ProductName { get; set; }
    public int ProductID { get; set; }
    public int StockQuantity { get; set; }
    public string StockUnit { get; set; }
    public int AlertingLimit { get; set; }
    public decimal Price { get; set; }
    public string PriceUnit { get; set; }
    public string Description { get; set; }
}
