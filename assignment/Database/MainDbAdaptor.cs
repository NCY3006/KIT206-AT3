using MySql.Data.MySqlClient;

namespace RAP.Database
{
    public class MainDbAdaptor
    {
        private string _serverName;
        private string _username;
        private string _password;
        private string _database;

        public MainDbAdaptor(string serverName, string username, string password, string database)
        {
            _serverName = serverName;
            _username = username;
            _password = password;
            _database = database;
        }

        public MySqlConnection DatabaseConnect()
        {
            string connectionString = $"server={_serverName};uid={_username};pwd={_password};database={_database}";
            MySqlConnection connection = new MySqlConnection(connectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connected to the database successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
            return connection;
        }
    }
}

