using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public static class Db
    {
        public const string ConnectionString =
            @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\LENOVO\source\repos\OOP_Hospital_Schedule_Management\OOP_Hospital_Schedule_Management\database\Database1.mdf;Integrated Security=True";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}