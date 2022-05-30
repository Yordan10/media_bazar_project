using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Media_Bazaar
{
    class Admin
    {
        private DBConnection DBConnection;

        public Admin()
        {
            DBConnection = new DBConnection();
        }
        public void Add_ProductType(string name)
        {
            var productType = new ProductType(name);
            string query = $"INSERT INTO `product_type` (`ID`, `Name`) VALUES (null, '{productType.Name}');";
            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            if (!isAdded)
            {
                MessageBox.Show("Product Type Added:Failed");
            }
            else
                MessageBox.Show("Product Type Added:successully");
        }
        public void Add_Product(int product_type_id, string name,string model,string brand,double weight,double height,double depth,int barcode,int cost)
        {
            var productType = new Product(name,model,brand,weight,height,depth,barcode,cost);

            string query = $"INSERT INTO `product` (`ID`, `Name`,`type_id`,`Model`,`Brand`,`Weight`,`Height`,`Depth`,`Barcode`,`Cost`) VALUES (null, '{productType.name}',{product_type_id},'{productType.Model}','{productType.Brand}',{productType.Weight},{productType.Height},{productType.Depth},{productType.Barcode},{productType.cost});";
            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            if (!isAdded)
            {
                MessageBox.Show("Product Type Added:Failed");
            }
            else
                MessageBox.Show("Product Type Added:successully");
        }

        public void Edit_ProductType(int ID, string name)
        {
            string query = $"UPDATE `product_type` Set `Name`='{name}' WHERE `ID` ={ID}";

            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Product Type Update:Failed");
            }
        }
        public void Edit_Product(int ID, string name, int typeid, string model, string brand, string weight, string height, string depth, int barcode, int cost)
        {
            string query = $"UPDATE `product` Set `Name`='{name}', `Type_ID`={typeid},`Model`={model},`Brand`='{brand}',`Weight`={weight},`Height`={height},`Depth`={depth},`Barcode`={barcode},`Cost`={cost} WHERE `ID` ={ID}";

            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Product  Update:Failed");
            }
        }
        public void DEL_ProductType(int ID)
        {
            string query = $"DELETE FROM `product_type` WHERE `ID` ={ID};";
             query += $"DELETE FROM `product` WHERE `Type_ID` ={ID};";
            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Product Type Del:Failed");
            }
        }
        public void DEL_Product(int ID)
        {
            string query = $"DELETE FROM `product` WHERE `ID` ={ID}";
            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Product Del:Failed");
            }
        }
        public void Edit_stock( int ID, int quantity, decimal price)
        {
            string query = $"UPDATE `product` Set `Quantity` = ifnull(`Quantity`,0) + {quantity},`Price`={price} WHERE `ID` ={ID}";

            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {          
                MessageBox.Show("Stock Update:Failed");
            }        
        }
        bool ReduceStockByQuantity(int ID)
        {
            string query = $"Update product p INNER JOIN request req on req.product_id=p.ID SET p.Quantity = ifnull(p.Quantity,0) - ifnull(req.Quantity,0) Where req.ID={ID} And p.ID = req.product_id";

            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                return false;
            }
            return true;
        }
        public void ProcessRequest(int ID,int amount)
        {
            string query = $"Update request Set Status_id = 2 Where ID ={ID}";
            var currentAmount = DBConnection.SelectProductQuantity(ID);
            if (amount > currentAmount)
            {
                MessageBox.Show("Your stock is insufficient!");
            }
            else
            {
                var reduceStock = ReduceStockByQuantity(ID);
                if (reduceStock)
                {
                    var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
                    if (!isUpdate)
                    {
                        MessageBox.Show("Something went wrong in processing");
                    }
                    else
                    {
                        MessageBox.Show("Successfully Processed!");
                    }
                }
                else
                {
                    MessageBox.Show("Something went wrong in processing");

                }
            }
        }
        private void Edit_Request(int ID)
        {
            string query = $"UPDATE `Requests` Set `Status`='Processed' Where `ID`={ID}";
            var isUpdate = DBConnection.InsertOrUpdateOrDel(query);
            if (!isUpdate)
            {
                MessageBox.Show("Request Processed:Failed");
            }
        }
        public DataTable Show_stock()
        {
            return DBConnection.SelectAllStock();      
        }
        public DataTable Filter_stock_By_Type(int type)
        {
            return DBConnection.SearchStockByTypes(type);
        }
        public DataTable Filter_products_By_Type(int type)
        {
            return DBConnection.SearchProductByTypes(type);
        }
        public DataTable Show_Requests()
        {
            return DBConnection.SelectAllRequests();
        }
        public DataTable Show_Products()
        {
            return DBConnection.SelectAllProductsDataTable();
        }
        public DataTable Show_ProductTypes()
        {
            return DBConnection.SelectAllProductTyes();
        }
        public List<ProductType> LoadAllStockTypes()
        {
            return DBConnection.SelectAllProductTyesList();
        }
        public SaleRepresentative GetSaleRepresentative(int ID)
        {
            return DBConnection.SelectSaleRepresentative(ID);
        }
        public List<string> LoadAllStockNames()
        {
            return DBConnection.SelectStockNames();
        }
        public bool RemoveStock(int ID)
        {
            string query = $"DELETE FROM `stock` WHERE `ID` ={ID}";
            var isDel = DBConnection.InsertOrUpdateOrDel(query);
            if (!isDel)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        //public bool ManageRequest(int id, string StockType,int productId, int quantity)
        //{

        //    string query = $"INSERT INTO `request` (`ID`, `product_id`,`Type`, `quantity`, `status_id`) VALUES ({id}, {productId},{StockType} ,{quantity}, 1)";
        //    var isProceed = DBConnection.InsertOrUpdateOrDel(query);
        //    if (!isProceed)
        //    {
        //        MessageBox.Show("RequestProceed:Failed");
        //    }

        //    return true;
            
        //}

        public string GetProductByID(int id)
        {
            var products = DBConnection.SelectAllProducts();
            foreach (Product p in products)
            {
                if (p.id==id)
                {
                    return p.name;
                }
                
            }
            return null;

            
        }

        public void AddEvou(int product_id, int addedquan, DateTime date)
        {
            string query = $"INSERT INTO `stock_evolution` (`ID`, `Product_ID`, `Added_Quantity`, `Date`) VALUES ({product_id}, '{ addedquan}', {date})";
            var isAdded = DBConnection.InsertOrUpdateOrDel(query);
            

        }


    }
}
