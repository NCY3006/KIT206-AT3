//using MySql.Data.MySqlClient;
//using RAP.Entities;

//namespace RAP.Database
//{
//    public class ResearcherDbAdaptor
//    {
//        private MainDbAdaptor _mainDbAdaptor;

//        public ResearcherDbAdaptor(MainDbAdaptor mainDbAdaptor)
//        {
//            _mainDbAdaptor = mainDbAdaptor;
//        }

//        public List<Researcher> FetchResearcherList()
//        {
//            List<Researcher> researcherList = new List<Researcher>();

//            string sql = "SELECT * FROM researcher";
//            using MySqlConnection connection = _mainDbAdaptor.DatabaseConnect();
//            using MySqlCommand command = new MySqlCommand(sql, connection);
//            using MySqlDataReader reader = command.ExecuteReader();

//            while (reader.Read())
//            {
//                string firstName = reader.GetString("firstName");
//                string lastName = reader.GetString("lastName");
//                string title = reader.GetString("title");
//                EmploymentLevel level = (EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), reader.GetString("level"));
//                string schoolUnit = reader.GetString("schoolUnit");
//                string campus = reader.GetString("campus");
//                string email = reader.GetString("email");
//                string jobTitle = reader.GetString("jobTitle");
//                DateTime commencedInstitution = reader.GetDateTime("commencedInstitution");
//                DateTime commencedPosition = reader.GetDateTime("commencedPosition");

//                List<Position> previousPositionList = new List<Position>();
//                string previousPositions = reader.GetString("previousPosition");
//                if (previousPositions != null && previousPositions.Length > 0)
//                {

//                    string[] positions = reader.GetString("previousPosition").Split(',');
//                    foreach (string position in positions)
//                    {
//                        string[] fields = position.Split(':');
//                        string positionTitle = fields[0];
//                        DateTime startDate = DateTime.Parse(fields[1]);
//                        DateTime endDate = DateTime.Parse(fields[2]);
//                        Position newPosition = new Position(positionTitle, startDate, endDate);
//                        previousPositionList.Add(newPosition);
//                    }
//                }

//                int publicationCount = reader.GetInt32("publicationCount");
//                List<Publication> publicationList = new List<Publication>();
//                string publicationIds = reader.GetString("publicationList");
//                if (publicationIds != null && publicationIds.Length > 0)
//                {
//                    string[] ids = publicationIds.Split(',');
//                    foreach (string id in ids)
//                    {
//                        Publication newPublication = new Publication();
//                        newPublication.Id = int.Parse(id);
//                        newPublication = PublicationDbAdaptor.FetchPublicationById(newPublication.Id);
//                        publicationList.Add(newPublication);
//                    }
//                }


//                Researcher newResearcher = new Researcher(firstName, lastName, title, level, schoolUnit, campus, email, jobTitle, commencedInstitution, commencedPosition, previousPositionList, publicationCount, publicationList);
//                researcherList.Add(newResearcher);
//            }

//            return researcherList;
//        }
//    }



//}
