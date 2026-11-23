using Microsoft.Data.SqlClient;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace OOP_Hospital_Schedule_Management
{
    /// <summary>
    /// Connects to a per-Windows-user LocalDB database. On first launch, creates
    /// the database and loads the checked-in setup script. No MDF path is required.
    /// </summary>
    public static class Db
    {
        private const string DatabaseName = "MediQueue";
        private static readonly object InitializationLock = new();
        private static volatile bool _initialized;

        public static string ConnectionString { get; } = new SqlConnectionStringBuilder
        {
            DataSource = @"(LocalDB)\MSSQLLocalDB",
            InitialCatalog = DatabaseName,
            IntegratedSecurity = true,
            Encrypt = false,
            ConnectTimeout = 30
        }.ConnectionString;

        public static SqlConnection GetConnection()
        {
            EnsureDatabaseReady();
            return new SqlConnection(ConnectionString);
        }

        private static void EnsureDatabaseReady()
        {
            if (_initialized) return;

            lock (InitializationLock)
            {
                if (_initialized) return;

                bool created = EnsureDatabaseExists();
                bool schemaReady = HasApplicationSchema();

                if (!schemaReady)
                {
                    if (!created)
                    {
                        throw new InvalidOperationException(
                            $"The LocalDB database '{DatabaseName}' exists but is missing the MediQueue schema. " +
                            "Back up any data, then remove or rename that database and restart the app to initialize a fresh one.");
                    }

                    InitializeSchema();
                    if (!HasApplicationSchema())
                        throw new InvalidOperationException("The MediQueue setup script ran, but required tables were not created.");
                }

                _initialized = true;
            }
        }

        private static bool EnsureDatabaseExists()
        {
            var masterBuilder = new SqlConnectionStringBuilder(ConnectionString)
            {
                InitialCatalog = "master"
            };

            using var connection = new SqlConnection(masterBuilder.ConnectionString);
            connection.Open();

            using (var check = new SqlCommand("SELECT DB_ID(@databaseName)", connection))
            {
                check.Parameters.Add("@databaseName", SqlDbType.NVarChar, 128).Value = DatabaseName;
                object? databaseId = check.ExecuteScalar();
                if (databaseId is not null && databaseId != DBNull.Value)
                    return false;
            }

            using var create = new SqlCommand("CREATE DATABASE [MediQueue]", connection);
            create.ExecuteNonQuery();
            return true;
        }

        private static bool HasApplicationSchema()
        {
            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            const string sql = @"
                SELECT CASE WHEN OBJECT_ID('dbo.Users', 'U') IS NOT NULL
                                  AND OBJECT_ID('dbo.Appointments', 'U') IS NOT NULL
                                  AND OBJECT_ID('dbo.Patients', 'U') IS NOT NULL
                                  AND OBJECT_ID('dbo.vw_PatientVisitHistory', 'V') IS NOT NULL
                            THEN 1 ELSE 0 END";
            using var command = new SqlCommand(sql, connection);
            return Convert.ToInt32(command.ExecuteScalar()) == 1;
        }

        private static void InitializeSchema()
        {
            string scriptPath = Path.Combine(AppContext.BaseDirectory, "database", "mediqueue_setup.sql");
            if (!File.Exists(scriptPath))
            {
                throw new FileNotFoundException(
                    "The MediQueue setup script was not found beside the application. Rebuild the project so it is copied to the output folder.",
                    scriptPath);
            }

            string script = File.ReadAllText(scriptPath);
            string[] batches = Regex.Split(script, @"^\s*GO\s*(?:--.*)?\s*$",
                RegexOptions.Multiline | RegexOptions.IgnoreCase);

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            foreach (string batch in batches)
            {
                if (string.IsNullOrWhiteSpace(batch)) continue;
                using var command = new SqlCommand(batch, connection)
                {
                    CommandTimeout = 120
                };
                command.ExecuteNonQuery();
            }
        }
    }
}
