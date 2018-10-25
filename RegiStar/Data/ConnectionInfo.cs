using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace RegiStar.Data
{
    public class ConnectionInfo
    {
        private string _sqlCommand;
        public static string connectionString = "Data Source=DESKTOP-7C48ELV;Initial Catalog=wpfRegistar;Integrated Security=True";

        public string SqlCommand { get => _sqlCommand; set => _sqlCommand = value; }
        public delegate void Action();

        public void ConnectToDB(Action action)
        {
            //Setup connection to database.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Create query.
                using (SqlCommand cmd = new SqlCommand(SqlCommand, conn))
                {
                    try
                    {
                        if (conn == null)
                            throw new Exception("Couldn't connect to the database. Check the connection string.");
                        if (cmd == null)
                            throw new Exception("SQL command error, Please check syntax.");

                        //Open the connection.
                        conn.Open();

                        action.Invoke();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ERROR: " + ex.Message.ToString());
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
