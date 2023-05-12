namespace RAP.Controller
{
    public class PublicationController
    {
        private Entities.Researcher currentResearcher; //Currently displayed researcher details
        private List<Entities.Publication> currentListCopy; //Copy of the currently displayed researcher list
                                                            // private MainWindow Window { get { return Application.Current.MainWindow as MainWindow; } } //Main application window

        public Entities.Researcher CurrentResearcher
        {
            get { return currentResearcher; }
        }

        public List<Entities.Publication> CurrentListCopy
        {
            get { return currentListCopy; }
            set { currentListCopy = value; }
        }

        /// <summary>
        /// Basic constructor for PublicationController
        /// </summary>
        public PublicationController()
        {

        }

        /////////Methods/////////

        /// <summary>
        /// Loads all publications for a given researcher
        /// </summary>
        /// <param name="researcher">The researcher whose publications are being loaded</param>
        /// <returns>A list of basic publications</returns>
        public List<Entities.Publication> LoadPublicationsFor(Entities.Researcher researcher)
        {
            //set variables for current researcher
            currentResearcher = researcher;

            //return the basic publication details
            return DataSource.ERDAdapter.fetchBasicPublicationDetails(researcher);
        }

        /// <summary>
        /// Filters the publication list by a given year range
        /// </summary>
        /// <param name="range_min">The lower range of years</param>
        /// <param name="range_max">The upper range of years</param>
        /// <returns>A list of publications filtered by year</returns>
        public List<Entities.Publication> filterByYear(int range_min, int range_max)
        {
            var filtered = from Entities.Publication p in CurrentListCopy
                           where p.Year.Year >= range_min && p.Year.Year <= range_max
                           select p;
            CurrentListCopy = new List<Entities.Publication>(filtered);
            return CurrentListCopy;
        }

        /// <summary>
        /// Loads the full details of a given publication and adds them to the view
        /// </summary>
        /// <param name="publication">The given publication</param>
        public void loadPublicationDetails(Entities.Publication publication)
        {
            //get details
            Entities.Publication p = DataSource.ERDAdapter.fetchFullPublicationDetails(publication);

            //load view
            // Window.PublicationsDetailsView.SetDetails(p);

        }
    }
}
