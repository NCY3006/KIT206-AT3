using RAP.Controller;
using RAP.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace WpfAppForms
{

    public partial class PerformanceReport : Window
    {

        private ResearcherController _researcherController;
        private List<Researcher> researchers = new List<Researcher>();
        private List<RAP.Entities.PerformanceReport> performanceReport;

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
