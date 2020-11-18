using System.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace Dimension_Data.DataLayer
{
    public class dbConnect: DbContext
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
