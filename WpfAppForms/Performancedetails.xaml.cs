using RAPLibrary.Controller;
using RAPLibrary.Entities;
using System.Windows;

namespace WpfAppForms
{
    /// <summary>
    /// Interaction logic for Performancedetails.xaml
    /// </summary>
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

    /// Functions of the researcher's performance
    /// Calculate and display the average numbers based on the researcher's publication years
        private void Performancedetails_Loaded(object sender, RoutedEventArgs e)
        {

            var researchervalue = _researchercontroller.LoadResearcherDetails(_researcher);
            lbl3yearaverage.Content = (researchervalue.Type == "Staff") ? ((float)researchervalue.PublicationsCount3Year() / 3f).ToString() : "/";
            lblemail.Content = researchervalue.Email.ToString();
            lblcampus.Content = researchervalue.Campus.ToString();
            lblName.Content = researchervalue.FamilyName.ToString();
            lblq1percentage.Content = researchervalue.Q1Percentage().ToString();
            lblschoolorunit.Content = researchervalue.School.ToString();
            lbltitle.Content = researchervalue.Title.ToString();

            lblperformancebyfunding.Content = (researchervalue.Type == "Staff") ? researchervalue.PerformanceByPublication().ToString() : "/";
            lblperformancebypublication.Content = (researchervalue.Type == "Staff") ? researchervalue.PerformanceByPublication().ToString() : "/";

            lblstudentdegree.Content = (researchervalue.Type == "Student") ? ((Student)researchervalue).Degree : "/";
            lblstudentsupervisor.Content = (researchervalue.Type == "Student") ? ((Student)researchervalue).SupervisorName : "/";
        }
    }
}
