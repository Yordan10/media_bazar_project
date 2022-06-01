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
   public class SalesManagement
    {
        private DBConnection dBConnection;

        public SalesManagement()
        {
            dBConnection = new DBConnection();
            ShowAllRequests();
        }

        public List<Product> PopulateComboboxProduct(int selectedType)
        {
            return dBConnection.SelectAllProductsPerType(selectedType);
        }
        public List<ProductType> PopulateComboboxProductType()
        {
            return dBConnection.SelectAllProductTypes();
        }
        public DataTable ShowAllRequests()
        {
            return dBConnection.SelectAllRequests();
        }

        public void AddRequest(int productId, int quantity)
        {
            string query = $"INSERT INTO `request` (`ID`, `product_id`, `quantity`, `status_id`) VALUES (null, {productId}, {quantity}, 1); ";

            var isAdded = dBConnection.InsertOrUpdateOrDel(query);
            if (!isAdded)
            {
                MessageBox.Show("Request sent:Failed");
            }
            else
            {
                MessageBox.Show("Request sent successfully");
            }

        }
    }
}
