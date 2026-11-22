using Microsoft.Data.SqlClient;
using System;
using System.IO;

namespace OOP_Hospital_Schedule_Management
{
    // Same class name and GetConnection() as before, so no other file has to change.
    // The difference: it finds database\Database1.mdf by itself, so nobody has to
    // type their own C:\ path here (and nobody commits a personal path by mistake).
    public static class Db
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (_connectionString == null)
                {
                    _connectionString =
                        @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                        "Initial Catalog=Database1;" +
                        "AttachDbFilename=" + FindDatabaseFile() + ";" +
                        "Integrated Security=True;Encrypt=False";
                }
                return _connectionString;
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Walks up from the .exe folder (bin\Debug\net10.0-windows) until it finds database\Database1.mdf
        private static string FindDatabaseFile()
        {
            string dir = AppDomain.CurrentDomain.BaseDirectory;

            for (int i = 0; i < 8 && !string.IsNullOrEmpty(dir); i++)
            {
                string candidate = Path.Combine(dir, "database", "Database1.mdf");
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                DirectoryInfo parent = Directory.GetParent(dir.TrimEnd(Path.DirectorySeparatorChar));
                dir = parent == null ? null : parent.FullName;
            }

            throw new FileNotFoundException(
                "Could not find database\\Database1.mdf. Create it in the 'database' folder " +
                "and run database\\mediqueue_setup.sql.");
        }
    }
}
