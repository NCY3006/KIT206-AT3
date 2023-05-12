using RAP.Entities;

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

        public PublicationController()
        {

        }

        public List<Entities.Publication> LoadPublicationsFor(Entities.Researcher researcher)
        {
            //set variables for current researcher
            currentResearcher = researcher;

            //return the basic publication details
            return DataSource.ERDAdapter.fetchBasicPublicationDetails(researcher);
        }

        public List<Entities.Publication> filterByYear(int range_min, int range_max)
        {
            var filtered = from Entities.Publication p in CurrentListCopy
                           where p.Year.Year >= range_min && p.Year.Year <= range_max
                           select p;
            CurrentListCopy = new List<Entities.Publication>(filtered);
            return CurrentListCopy;
        }



        public Publication loadPublicationDetails(Entities.Publication publication)
        {
            //get details
            Entities.Publication p = DataSource.ERDAdapter.fetchFullPublicationDetails(publication);
            return p;
            //load view
            // Window.PublicationsDetailsView.SetDetails(p);

        }

    }
}

