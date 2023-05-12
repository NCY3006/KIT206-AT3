//using MySql.Data.MySqlClient;
//using RAP.Entities;

//namespace RAP.Database
//{
//    public class PublicationDbAdaptor
//    {
//        private readonly MainDbAdaptor _mainDbAdaptor;

//        public PublicationDbAdaptor(MainDbAdaptor mainDbAdaptor)
//        {
//            _mainDbAdaptor = mainDbAdaptor;
//        }

//        public List<Publication> FetchPublicationList()
//        {
//            List<Publication> publicationList = new List<Publication>();

//            try
//            {
//                using MySqlConnection connection = _mainDbAdaptor.DatabaseConnect();
//                connection.Open();

//                MySqlCommand cmd = new MySqlCommand("SELECT * FROM publication", connection);

//                using MySqlDataReader reader = cmd.ExecuteReader();

//                while (reader.Read())
//                {
//                    string doi = reader.GetString("doi");
//                    string title = reader.GetString("title");
//                    int publicationYear = reader.GetInt32("publicationYear");
//                    int ranking = reader.GetInt32("ranking");
//                    PublicationType type = (PublicationType)Enum.Parse(typeof(PublicationType), reader.GetString("type"));
//                    string cite = reader.GetString("cite");
//                    int age = reader.GetInt32("age");

//                    List<string> authors = new List<string>();
//                    string authorsString = reader.GetString("authors");
//                    char[] delimiterChars = { ',' };
//                    string[] authorArray = reader.GetString("authors").Split(delimiterChars);

//                    authors.AddRange(authorArray);

//                    Publication publication = new Publication(doi, title, authors, publicationYear, ranking, type, cite, age);
//                    publicationList.Add(publication);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error fetching publication list: {ex.Message}");
//            }

//            return publicationList;
//        }
//        public Publication FetchPublicationById(int id)
//        {
//            Publication publication = null;

//            string sql = "SELECT * FROM publication WHERE id = @id";
//            using MySqlConnection connection = _mainDbAdaptor.DatabaseConnect();
//            using MySqlCommand command = new MySqlCommand(sql, connection);
//            command.Parameters.AddWithValue("@id", id);
//            using MySqlDataReader reader = command.ExecuteReader();

//            if (reader.Read())
//            {
//                string doi = reader.GetString("doi");
//                string title = reader.GetString("title");
//                string[] authors = reader.GetString("authors").Split(',');
//                int publicationYear = reader.GetInt32("publicationYear");
//                int ranking = reader.GetInt32("ranking");
//                PublicationType type = (PublicationType)Enum.Parse(typeof(PublicationType), reader.GetString("type"));
//                string cite = reader.GetString("cite");
//                int age = reader.GetInt32("age");
//                publication = new Publication(doi, title, authors.ToList(), publicationYear, ranking, type, cite, age);
//            }

//            return publication;
//        }

//    }
//}

