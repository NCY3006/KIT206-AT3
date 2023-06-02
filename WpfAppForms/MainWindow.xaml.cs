using RAPLibrary.Controller;
using RAPLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfAppForms
{


    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ResearcherController _researcherController;
        private Researcher selectedResearcher;
        private PublicationController publicationController;

        public List<Publication> Publications { get; set; } = new List<Publication>();
        public List<Position> Positions { get; set; } = new List<Position>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            cmblevels.SelectionChanged += Cmblevels_SelectionChanged;
            btnsearchname.Click += Btnsearchname_Click;
            publicationController = new PublicationController();


            // Initialize the research controller from Controller folder
            _researcherController = new ResearcherController();

            // Call the necessary methods to load the data then sort them
            var researchers = _researcherController.Reseachers.OrderBy(r => r.FamilyName).ToList();
            if ((researchers != null) && (researchers.Count > 0))
            {
                selectedResearcher = researchers.First();

            }
            // Do something with the data, such as populate a listbox
            listResearcher.ItemsSource = researchers;

            panel2.Visibility = Visibility.Collapsed;
            panel3.Visibility = Visibility.Collapsed;
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Get the selected item from the ListBox
            var selectedresearcher = (Researcher)listResearcher.SelectedItem;


            // Handle the click event for the selected item
            if (selectedresearcher != null)
            {
                selectedResearcher = selectedresearcher;
                // Do something with the selectedResearcher, such as displaying details or performing an action
                populateEntries();
            }
            panel2.Visibility = Visibility.Visible;
            panel3.Visibility = Visibility.Visible;
        }

        private void populateEntries()
        {
            Researcher researcher = _researcherController.LoadResearcherDetails(selectedResearcher);
            Publications = publicationController.LoadPublicationsFor(researcher);
            // Assign the publications list to your desired control in the UI

            string uriString = researcher.Photo.AbsoluteUri;

            // Create a new Uri using the uriString
            Uri imageUri = new Uri(uriString);

            // Create a new BitmapImage
            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = imageUri;
            bitmapImage.EndInit();

            // Assign the BitmapImage as the source of the PictureBox
            imgpath.Width = 70;
            imgpath.Height = 150;

            imgpath.Source = bitmapImage;
            lblschoolunit.Content = researcher.School.ToString();
            lblemail.Content = researcher.Email.ToString();
            lbljobtitle.Content = researcher.CurrentJobTitle();
            lblname.Content = researcher.FamilyName.ToString();
            lblpublications.Content = researcher.PublicationsCount().ToString();
            lblcommencedcurrentposition.Content = researcher.CurrentJobStart().ToString();
            lbltenure.Content = researcher.Tenure().ToString();


            if (researcher is Staff staff)
            {
                lblsupervisions.Content = staff.PublicationsCount();
                lblcommencedwithinstitution.Content = staff.CurrentJobStart().ToString();
            }
            if (researcher is Student student)
            {
                lblsupervisor.Content = student.SupervisorName;

                lbldegree.Content = student.Degree.ToString();

            }
            Positions = researcher.Positions;
            lstpositions.ItemsSource = Positions;
            lstResearcherPublications.ItemsSource = Publications;

        }
        // On selection changed
        private void Cmblevels_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            string selectedValue = cmblevels.SelectedItem.ToString();
            if (selectedValue == "All Levels")
            {
                var allResearchers = _researcherController.Reseachers;
                listResearcher.ItemsSource = null;
                listResearcher.ItemsSource = allResearchers;
            }
            else if (selectedValue == "Students Only")
            {
                // Filter by students
                var students = _researcherController.Reseachers.Where(r => r.Type == "Student");
                listResearcher.ItemsSource = null;
                listResearcher.ItemsSource = students;
            }
            else
            {
                // Filter by employment level
                var filtered = _researcherController.Reseachers.Where(r => r.GetCurrentJob().Level.ToString() == selectedValue.Split(' ')[1]);
                listResearcher.ItemsSource = null;
                listResearcher.ItemsSource = filtered;
            }
        }
        private void Btnsearchname_Click(object sender, RoutedEventArgs e)
        {
            string searchtext = txtsearchname.Text.ToString();

            if (string.IsNullOrEmpty(searchtext))
            {
                MessageBox.Show("Please enter a search term");
                return;
            }


            var students = _researcherController.Reseachers.Where(r => (r.FamilyName + " " + r.GivenName).ToUpperInvariant().Contains(searchtext.ToUpperInvariant())
            || (r.GivenName + " " + r.FamilyName).ToUpperInvariant().Contains(searchtext.ToUpperInvariant()));
            listResearcher.ItemsSource = null;
            if (students.Count() < 1)
            {
                MessageBox.Show("No researchers found.");
            }
            else
            {
                listResearcher.ItemsSource = students;
            }

        }
        private void filterbutton_click(object sender, RoutedEventArgs e)
        {

            try
            {
                int minYear = int.Parse(txtyearfrom.Text);
                int maxYear = int.Parse(txtyearto.Text);
                var filtered = from Publication p in Publications
                               where p.Year.Year >= minYear && p.Year.Year <= maxYear
                               select p;


                lstResearcherPublications.ItemsSource = null;
                lstResearcherPublications.ItemsSource = filtered;

            }
            catch (System.Exception)
            {

                MessageBox.Show("Something wrong happened");
            }
        }
        private void ResearcherPublications_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // Get the selected publication
            var selectedPublication = (Publication)lstResearcherPublications.SelectedItem;


            // Open the Publication window with the selected publication
            PublicationDetails publicationWindow = new PublicationDetails(selectedPublication);
            publicationWindow.Show();
        }

        private void GeneratePerformanceReportButton_Click(object sender, RoutedEventArgs e)
        {
            PerformanceReport performanceReportWindow = new PerformanceReport();
            performanceReportWindow.ShowDialog();
        }
        private void PerformanceDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            Researcher reseacher = _researcherController.LoadResearcherDetails(selectedResearcher);
            Performancedetails performanceDetailsWindow = new Performancedetails(researcher: reseacher);
            performanceDetailsWindow.ShowDialog();
        }

        private void CumulativeCountButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedResearcher != null)
            {
                var testdata = selectedResearcher.CumulativeCount;
                var researcher = _researcherController.LoadResearcherDetails(selectedResearcher);
                IDictionary<string, int> cumulativecount = researcher.CumulativeCount;
                CumulativeCount cumulativeCountWindow = new CumulativeCount(cumulativecount: cumulativecount);
                cumulativeCountWindow.ShowDialog();
            }

        }
        private void SupervisionDetailsButton_Click(object sender, RoutedEventArgs e)
        {
            var researcher = _researcherController.LoadResearcherDetails(selectedResearcher);
            try
            {
                if (researcher is Staff staffmember)
                {
                    List<Student> students = staffmember.Supervisions;
                    Supervisees superviseesWindow = new Supervisees(Supervisees: students);
                    superviseesWindow.ShowDialog();
                }
                else
                {
                    MessageBox.Show("The Researcher is a Student");
                }
            }
            catch (System.Exception)
            {

                MessageBox.Show("The Researcher is a student");
            }

        }


        //when the invert order button is clicked
        private void InvertOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Get the reference to the ListBox
            ListBox listBox = lstResearcherPublications;
            lstResearcherPublications.ItemsSource = null;

            Publications.Reverse();
            lstResearcherPublications.ItemsSource = Publications;

        }

        private void cmblevels_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void btnsearchname_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
