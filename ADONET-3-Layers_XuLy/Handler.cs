using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONET_3_Layers_KetNoi;

namespace ADONET_3_Layers_XuLy
{
    public class Handler
    {
        public static DataTable getListOfProducts()
        {
            DataProvider.Connect();
            DataTable dt = DataProvider.Select(CommandType.Text, "SELECT * FROM Products");
            DataProvider.Disconnect();
            return dt;
        }

        public static void deleteRow(int id)
        {
            DataProvider.Connect();
            DataProvider.ExecuteNonQuery(CommandType.Text, "delete from [Order Details] where ProductID=" + id);
            DataProvider.ExecuteNonQuery(CommandType.Text, "delete from Products where ProductID=" + id);
            DataProvider.Disconnect();
        }

        public static List<Tuple<int,string>> getListOfSupplier()
        {
            DataProvider.Connect();
            DataTable dt = DataProvider.Select(CommandType.Text, "SELECT * FROM Suppliers");
            DataProvider.Disconnect();
            List<Tuple<int, string>> suppliers = new List<Tuple<int, string>>();
            foreach(DataRow row in dt.Rows)
            {
                suppliers.Add(new Tuple<int, string>((int)row["SupplierID"],row["CompanyName"].ToString()));
            }


            return suppliers;
        }

        public static List<Tuple<int, string>> getListOfCategorys()
        {
            DataProvider.Connect();
            DataTable dt = DataProvider.Select(CommandType.Text, "SELECT * FROM Categories");
            DataProvider.Disconnect();
            List<Tuple<int, string>> categories = new List<Tuple<int, string>>();
            foreach (DataRow row in dt.Rows)
            {
                categories.Add(new Tuple<int, string>((int)row["CategoryID"], row["CategoryName"].ToString()));
            }
            return categories;
        }
    }
}
