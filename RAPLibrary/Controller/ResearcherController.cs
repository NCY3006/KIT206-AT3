using RAP.Entities;
using System.Collections.ObjectModel;

namespace RAP.Controller
{
    public class ResearcherController
    {
        public static List<Entities.Researcher> researchers; //Basic researcher list
        public ObservableCollection<Entities.Researcher> ViewableResearchers; //
        public PublicationController pubController; //Publications controllor
                                                    //  private MainWindow Window { get { return Application.Current.MainWindow as MainWindow; } } //CUrrent main window
        public List<Entities.Researcher> currentListCopy; //Copy of basic researcher list for filtering

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


        public ResearcherController()
        {
            researchers = DataSource.ERDAdapter.FetchBasicResearcherDetails();
            CurrentListCopy = researchers;
            ViewableResearchers = new ObservableCollection<Entities.Researcher>(researchers as List<Entities.Researcher>);
            pubController = new Controller.PublicationController();
        }


        public List<Entities.Researcher> FilterByLevel(Entities.EmploymentLevel l)
        {
            var filtered = from Entities.Researcher r in CurrentListCopy
                           where r.GetCurrentJob().Level == l
                           orderby r.FamilyName ascending, r.GivenName ascending
                           select r;
            CurrentListCopy = new List<Entities.Researcher>(filtered);
            return CurrentListCopy;
        }

        public List<Entities.Researcher> FilterByName(string inputName)
        {
            var filtered = from Entities.Researcher r in CurrentListCopy
                           where r.GivenName.ToLower().Contains(inputName.ToLower()) || r.FamilyName.ToLower().Contains(inputName.ToLower())
                           select r;
            CurrentListCopy = new List<Entities.Researcher>(filtered);
            return CurrentListCopy;
        }


        public Entities.Researcher LoadResearcherDetails(Entities.Researcher researcher)
        {
            //Get full details
            Entities.Researcher details = DataSource.ERDAdapter.FetchFullResearcherDetails(researcher.ID, Reseachers);

            //Get publications
            details.Publications = pubController.LoadPublicationsFor(details);
            details.CumulativeCount = LoadCumulativeAccountFor(details);

            //pubController.CurrentListCopy = details.Publications;
            return details;
            //Adds details to view
            //  Window.ResearcherDetailView.SetDetails(details);
            //  Window.ResearcherDetailView.ActivatePubList();
            //  Window.CumulativeCountView.LoadCumulativeCount(details);
        }
        public IDictionary<string, int> LoadCumulativeAccountFor(Entities.Researcher researcher)
        {
            Dictionary<string, int> cumulativeCount = new Dictionary<string, int>();

            foreach (Entities.Publication publication in researcher.Publications)
            {
                string year = publication.Year.Year.ToString();

                if (cumulativeCount.ContainsKey(year))
                {
                    cumulativeCount[year]++;
                }
                else
                {
                    cumulativeCount[year] = 1;
                }
            }

            return cumulativeCount;
        }
        public List<PerformanceReport> GeneratePerformanceReport()
        {
            List<PerformanceReport> performanceReport = new List<PerformanceReport>();

            // Create the report categories
            performanceReport.Add(new PerformanceReport { Category = "Poor" });
            performanceReport.Add(new PerformanceReport { Category = "Below Average" });
            performanceReport.Add(new PerformanceReport { Category = "Meeting Minimum" });
            performanceReport.Add(new PerformanceReport { Category = "Star Performers" });

            // Iterate over all researchers
            foreach (Entities.Researcher researcher in Reseachers)
            {
                int performance = CalculatePerformance(researcher);
                PerformanceReport category = GetCategory(performance, performanceReport);
                category.Researchers.Add((researcher, performance));
            }

            // Sort the researchers within each category
            foreach (PerformanceReport report in performanceReport)
            {
                if (report.Category == "Poor" || report.Category == "Below Average")
                {
                    report.Researchers = report.Researchers.OrderBy(r => r.Item2).ToList();
                }
                else
                {
                    report.Researchers = report.Researchers.OrderByDescending(r => r.Item2).ToList();
                }
            }

            return performanceReport;
        }


        private int CalculatePerformance(Entities.Researcher researcher)
        {
            var researcherfound = LoadResearcherDetails(researcher);
            int totalPublications = researcherfound.Publications.Count;
            int cumulativeScore = 0;

            foreach (var count in researcherfound.CumulativeCount)
            {
                int yearCount = count.Value;
                cumulativeScore += yearCount;
            }

            int performance = cumulativeScore * 100 / totalPublications;
            return performance;
        }

        private PerformanceReport GetCategory(int performance, List<PerformanceReport> performanceReport)
        {
            if (performance <= 70)
            {
                return performanceReport.Find(report => report.Category == "Poor");
            }
            else if (performance <= 110)
            {
                return performanceReport.Find(report => report.Category == "Below Average");
            }
            else if (performance <= 150)
            {
                return performanceReport.Find(report => report.Category == "Meeting Minimum");
            }
            else
            {
                return performanceReport.Find(report => report.Category == "Star Performers");
            }
        }

    }

}