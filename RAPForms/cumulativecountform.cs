using RAPLibrary.Entities;

namespace RAPForms
{
    public partial class cumulativecountform : Form
    {
        Researcher selectedResearcher;
        public cumulativecountform(Researcher selectedresearcher)
        {
            selectedResearcher = selectedresearcher;
            InitializeComponent();
        }

        private void cumulativecountform_Load(object sender, EventArgs e)
        {
            selectedResearcher.calPubPerYear();
            IDictionary<string, int> cumulativeCount = selectedResearcher.CumulativeCount;

            // Clear the ListView before adding new items
            lsbcumulativecount.Items.Clear();

            foreach (KeyValuePair<string, int> item in cumulativeCount)
            {
                // Create a new ListViewItem (row) for each dictionary entry
                ListViewItem listViewItem = new ListViewItem(item.Key); // First column
                listViewItem.SubItems.Add(item.Value.ToString()); // Second column

                // Add the row to the ListView
                lsbcumulativecount.Items.Add(listViewItem);
            }

        }
    }
}
