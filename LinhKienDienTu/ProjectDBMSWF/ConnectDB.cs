using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDBMSWF
{
    internal class ConnectDB
    {
        private SqlConnection sqlCon;

        public ConnectDB(string connectionString)
        {
            sqlCon = new SqlConnection(connectionString);
        }
        public SqlConnection GetConnection()
        {
            return sqlCon;
        }

        public void Open()
        {
            try
            {

                if (sqlCon.State == ConnectionState.Closed)
                {
                    sqlCon.Open();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        public void Close()
        {
            if (sqlCon != null && sqlCon.State == ConnectionState.Open)
            {
                sqlCon.Close();
            }
            else
            {
                MessageBox.Show("NO CONNECTED");
            }
        }
    }
}
