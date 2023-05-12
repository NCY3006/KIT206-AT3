using RAP.Controller;
using RAP.Entities;
using System.Windows;

namespace WpfAppForms
{

    public partial class Performancedetails : Window
    {
        private Researcher _researcher;
        private ResearcherController _researchercontroller;
        public Performancedetails(Researcher researcher)
        {
            _researcher = researcher;
            InitializeComponent();
            Loaded += Performancedetails_Loaded;
            _researchercontroller = new ResearcherController();

        }
        private void Performancedetails_Loaded(object sender, RoutedEventArgs e)
        {
            var researchervalue = _researchercontroller.LoadResearcherDetails(_researcher);
            lbl3yearaverage.Content = researchervalue.PublicationsCount3Year().ToString();
            lblemail.Content = researchervalue.Email.ToString();
            lblcampus.Content = researchervalue.Campus.ToString();
            lblName.Content = researchervalue.FamilyName.ToString();
            lblq1percentage.Content = researchervalue.Q1Percentage().ToString();
            lblschoolorunit.Content = researchervalue.School.ToString();
            lbltitle.Content = researchervalue.Title.ToString();

            lblperformancebyfunding.Content = researchervalue.PerformanceByPublication().ToString();
            lblperformancebypublication.Content = researchervalue.PerformanceByPublication().ToString();




        }
    }
}
