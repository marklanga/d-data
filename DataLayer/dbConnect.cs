using System.Data;
using MySql.Data.MySqlClient;

namespace Dimension_Data.DataLayer
{
    public class dbConnect
    {
        public MySqlConnection conn;

        public dbConnect()
        {
            string connString = "";
            conn = new MySqlConnection(connString);
            conn.Open();

        }
    }
}
