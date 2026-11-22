using Microsoft.Data.SqlClient;

namespace OOP_Hospital_Schedule_Management
{
    public static class Db
    {
        public const string ConnectionString =
            @"Place your connection string here";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}