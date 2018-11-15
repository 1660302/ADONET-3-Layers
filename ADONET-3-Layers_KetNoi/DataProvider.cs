using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_3_Layers_KetNoi
{
    public class DataProvider
    {
        static String mConnectionString;
        static SqlConnection mConnection;
        public DataProvider()
        {
           
        }

        private static string ConnectionString
        {
            get
            {
                mConnectionString = ConfigurationManager.ConnectionStrings["NorthWnd"].ConnectionString;
                return mConnectionString;
            }
        }
        public static void Connect()
        {

            try
            {
                if (mConnection == null)
                    mConnection = new SqlConnection(ConnectionString);

                if (mConnection.State != System.Data.ConnectionState.Closed)
                    mConnection.Close();

                mConnection.Open();
                Console.WriteLine(">> Connected to DB");
            }
            catch (SqlException e)
            {
                throw e;
            }


        }

        public static void Disconnect()
        {
            if (mConnection != null && mConnection.State != System.Data.ConnectionState.Closed)
                mConnection.Close();
        }

        public static int ExecuteNonQuery(CommandType cmdType, String cmdText)
        {
            try
            {
                SqlCommand cmd = mConnection.CreateCommand();
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        public static int ExecuteNonQuery(CommandType cmdType, String cmdText, params SqlParameter[] parameters)
        {
            try
            {
                SqlCommand cmd = mConnection.CreateCommand();
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                if(parameters!= null && parameters.Length >0)
                    cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static SqlDataReader GetReader(CommandType cmdType, String cmdText)
        {
            try
            {
                SqlCommand cmd = mConnection.CreateCommand();
                cmd.CommandType = cmdType;
                cmd.CommandText = cmdText;
                return cmd.ExecuteReader();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
        public static DataTable Select(CommandType cmdType, String cmdText)
        {
            SqlCommand cmd = mConnection.CreateCommand();
            cmd.CommandType = cmdType;
            cmd.CommandText = cmdText;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            adapter.Fill(table);
            return table;
        }
    }
}
