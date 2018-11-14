using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_3_Layers_KetNoi
{
    public class XLyHelper
    {
        public DataTable LayDSKhachHang()
        {
            //Tạo kết nối
            SqlConnection sqlConnection = KetNoi.ConnectDatabase();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "Select * from Nhom";
            sqlCommand.CommandType = CommandType.Text;

            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            sqlDataAdapter.Fill(dataTable);

            KetNoi.CloseConnection(sqlConnection);

            return dataTable;

        }
    }
}
