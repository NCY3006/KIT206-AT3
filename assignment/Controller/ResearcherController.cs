using System.Collections.ObjectModel;

namespace RAP.Controller
{
    public class ResearcherController
    {
        public static List<Entities.Researcher> researchers; //Basic researcher list
        public ObservableCollection<Entities.Researcher> ViewableResearchers; //
        public PublicationController pubController; //Publications controllor
                                                    //  private MainWindow Window { get { return Application.Current.MainWindow as MainWindow; } } //CUrrent main window
        private List<Entities.Researcher> currentListCopy; //Copy of basic researcher list for filtering

        //Properties
        public List<Entities.Researcher> Reseachers
        {
            get { return researchers; }
            set { researchers = value; }
        }

        public ObservableCollection<Entities.Researcher> GetViewableList()
        {
            return ViewableResearchers;
        }

        public List<Entities.Researcher> CurrentListCopy
        {
            get { return currentListCopy; }
            set { currentListCopy = value; }
        }

        /////////Methods/////////

        /// <summary>
        /// <para>Basic ResearchController constructor</para>
        /// <para>Gets the basic researcher list and adds it to the view</para>
        /// </summary>
        public ResearcherController()
        {
            researchers = DataSource.ERDAdapter.FetchBasicResearcherDetails();
            CurrentListCopy = researchers;
            ViewableResearchers = new ObservableCollection<Entities.Researcher>(researchers as List<Entities.Researcher>);
            pubController = new Controller.PublicationController();
        }

        /// <summary>
        /// Filters the researcher list by an employment level
        /// </summary>
        /// <param name="l">Employment level being filtered for</param>
        /// <returns>Filtered list</returns>
        public List<Entities.Researcher> FilterByLevel(Entities.EmploymentLevel l)
        {
            var filtered = from Entities.Researcher r in CurrentListCopy
                           where r.GetCurrentJob().Level == l
                           orderby r.FamilyName ascending, r.GivenName ascending
                           select r;
            CurrentListCopy = new List<Entities.Researcher>(filtered);
            return CurrentListCopy;
        }

        /// <summary>
        /// Filters the research list by a name
        /// </summary>
        /// <param name="inputName">Text being filtered for</param>
        /// <returns>Filtered list</returns>
        public List<Entities.Researcher> FilterByName(string inputName)
        {
            var filtered = from Entities.Researcher r in CurrentListCopy
                           where r.GivenName.ToLower().Contains(inputName.ToLower()) || r.FamilyName.ToLower().Contains(inputName.ToLower())
                           select r;
            CurrentListCopy = new List<Entities.Researcher>(filtered);
            return CurrentListCopy;
        }

        /// <summary>
        /// Loads full researcher details
        /// </summary>
        /// <param name="researcher">A researcher object with basic details</param>
        public void LoadResearcherDetails(Entities.Researcher researcher)
        {
            //Get full details
            Entities.Researcher details = DataSource.ERDAdapter.FetchFullResearcherDetails(researcher.ID, Reseachers);

            //Get publications
            details.Publications = pubController.LoadPublicationsFor(details);
            pubController.CurrentListCopy = details.Publications;

            //Adds details to view
            //  Window.ResearcherDetailView.SetDetails(details);
            //  Window.ResearcherDetailView.ActivatePubList();
            //  Window.CumulativeCountView.LoadCumulativeCount(details);
        }
    }
}