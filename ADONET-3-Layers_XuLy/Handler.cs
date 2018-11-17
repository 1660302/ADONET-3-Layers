using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADONET_3_Layers_KetNoi;
using System.Data.SqlClient;

namespace ADONET_3_Layers_XuLy
{
    public class Handler
    {
       //private static object product;

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
        public static bool insertProducts( string name, int supplier, int category, string quantity, float price, int stock, int order, int reorder, bool discontinued)
        {

            DataProvider.Connect();
            string query = "INSERT INTO Products VALUES(@name,@supplier,@category,@quantity,@price,@stock,@order,@reorder,@discontinued)";
            DataProvider.ExecuteNonQuery(CommandType.Text, query
            , new SqlParameter { ParameterName = "@name", Value = name }
            , new SqlParameter { ParameterName = "@supplier", Value = supplier }
            , new SqlParameter { ParameterName = "@category", Value = category }
            , new SqlParameter { ParameterName = "@quantity", Value = quantity }
            , new SqlParameter { ParameterName = "@price", Value = price }
            , new SqlParameter { ParameterName = "@stock", Value = stock }
            , new SqlParameter { ParameterName = "@order", Value = order }
            , new SqlParameter { ParameterName = "@reorder", Value = reorder }
            , new SqlParameter { ParameterName = "@discontinued", Value = discontinued }
            );
            DataProvider.Disconnect();
            return true;
        }
        public static bool UpdateProducts(int id, string name, int supplier, int category, string quantity, float price, int stock, int order, int reorder, bool discontinued)
        {
            DataProvider.Connect();
            if ((DataProvider.Select(CommandType.Text, "SELECT * FROM Categories where CategoryID = " + category).Rows.Count == 0) || (DataProvider.Select(CommandType.Text, "SELECT * FROM Suppliers where SupplierID = " + supplier).Rows.Count == 0))
            {
                DataProvider.Disconnect();
                return false;
            }
            string query = "UPDATE [Products] SET [ProductName] = @name,[SupplierID] =@supplier,[CategoryID] =@category,[QuantityPerUnit] =@quantity,[UnitPrice] =@price,[UnitsInStock] = @stock,[UnitsOnOrder] =@order,[ReorderLevel] =@reorder,[Discontinued] =@discontinued where [ProductID] = @oldid";
            DataProvider.ExecuteNonQuery(CommandType.Text, query
           , new SqlParameter { ParameterName = "@name", Value = name }
           , new SqlParameter { ParameterName = "@supplier", Value = supplier }
           , new SqlParameter { ParameterName = "@category", Value = category }
           , new SqlParameter { ParameterName = "@quantity", Value = quantity }
           , new SqlParameter { ParameterName = "@price", Value = price }
           , new SqlParameter { ParameterName = "@stock", Value = stock }
           , new SqlParameter { ParameterName = "@order", Value = order }
           , new SqlParameter { ParameterName = "@reorder", Value = reorder }
           , new SqlParameter { ParameterName = "@discontinued", Value = discontinued }
           , new SqlParameter { ParameterName = "@oldid", Value = id }
           );
            DataProvider.Disconnect();
            return true;
        }

    }
}
