using Microsoft.Data.SqlClient;
using System.IO;

namespace OOP_Hospital_Schedule_Management
{
    public static class Db
    {
        public static string ConnectionString { get; } = BuildConnectionString();

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        // Walks up from bin\Debug\... until it finds database\Database1.mdf,
        // so it works on any computer with no hardcoded path.
        private static string BuildConnectionString()
        {
            DirectoryInfo? dir = new DirectoryInfo(AppContext.BaseDirectory);
            while (dir != null)
            {
                string candidate = Path.Combine(dir.FullName, "database", "Database1.mdf");
                if (File.Exists(candidate))
                {
                    return new SqlConnectionStringBuilder
                    {
                        DataSource = @"(LocalDB)\MSSQLLocalDB",
                        AttachDBFilename = candidate,
                        IntegratedSecurity = true,
                        Encrypt = false,
                        ConnectTimeout = 30
                    }.ConnectionString;
                }
                dir = dir.Parent;
            }

            throw new FileNotFoundException(
                "Could not find database\\Database1.mdf above " + AppContext.BaseDirectory);
        }
    }
}