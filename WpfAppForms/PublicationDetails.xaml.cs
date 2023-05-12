using RAP.Entities;
using RAP.Controller;
using System.Windows;

namespace WpfAppForms
{
   

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
            // Obtain the publication from your data source


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
        }
    }
}
