using RAPLibrary.Controller;
using RAPLibrary.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppForms
{
    /// <summary>
    /// Interaction logic for PerformanceReport.xaml
    /// Functions of the report where populate a list of performance report
    /// Display the final percentage result of the selected researcher 
    /// </summary>
    public partial class PerformanceReport : Window
    {

        private ResearcherController _researcherController;
        private List<Researcher> researchers = new List<Researcher>();
        private List<RAPLibrary.Entities.PerformanceReport> performanceReport;

        public PerformanceReport()
        {
            InitializeComponent();
            _researcherController = new ResearcherController();
            performanceReport = _researcherController.GeneratePerformanceReport();

            PopulateListBox(listPoor, "Poor");
            PopulateListBox(listBelowExpectations, "Below Average");
            PopulateListBox(listMeetingMinimum, "Meeting Minimum");
            PopulateListBox(listStarPerformers, "Star Performers");
        }
        
        private void PopulateListBox(ListBox listBox, string category)
        {
            listBox.Items.Clear(); // Clear the existing items
            var report = performanceReport.FirstOrDefault(r => r.Category == category);
            if (report != null)
            {
                listBox.ItemsSource = report.Researchers.Select(r => $"{r.Item2}% - {r.Item1.FamilyName}").ToList();
            }
        }

    /// Allow user to copy the selected researcher's email address
        public void CopyEmails()
        {
            researchers = _researcherController.Reseachers;
            var emails = researchers.ToList().Select(r => r.Email).ToList();
            var emailString = string.Join(", ", emails);
            Clipboard.SetText(emailString);
        }
        private void Btncopyemails_Click(object sender, RoutedEventArgs e)
        {
            CopyEmails();
        }


    }
}
