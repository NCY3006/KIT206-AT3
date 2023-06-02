using RAPLibrary.Controller;
using RAPLibrary.Entities;
using System.Windows;

namespace WpfAppForms
{
    /// <summary>
    /// Interaction logic for PublicationDetails.xaml
    /// </summary>
    public partial class PublicationDetails : Window
    {
        Publication publication;
        private PublicationController publicationController;

        public PublicationDetails(Publication Publication)
        {
            publication = Publication;
            publicationController = new PublicationController();

            InitializeComponent();
            loadContent();
        }
        private void PublicationDetails_Loaded(object sender, RoutedEventArgs e)
        {
            // Obtain the publication details from database
            // Load the contents of the researcher
            // Display the contents result from the database 


        }
        private void loadContent()
        {
            var publicationdetails = publicationController.loadPublicationDetails(publication);
            lblage.Content = publicationdetails.Age().ToString();
            lblauthors.Content = publicationdetails.Authors.ToString();
            lblcite.Content = publicationdetails.CiteAs.ToString();
            lblranking.Content = publicationdetails.Ranking.ToString();
            lbltitle.Content = publicationdetails.Title.ToString();
            lblyear.Content = publicationdetails.Year.ToString();
            lbldoi.Content = publicationdetails.DOI.ToString();
            lbldate.Content = publicationdetails.Available.ToString("yyyy/MM/dd");
            lblconference.Content = publicationdetails.Type.ToString();
        }
    }
}
