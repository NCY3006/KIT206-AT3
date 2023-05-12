using RAPLibrary.Entities;

namespace RAPForms
{
    public partial class performancedetailsform : Form
    {
        private Researcher _researcherdetails;
        public performancedetailsform(Researcher researcher)
        {
            _researcherdetails = researcher;
            InitializeComponent();
        }

        private void performancedetailsform_Load(object sender, EventArgs e)
        {
            if (_researcherdetails.Publications.Count < 1)
            {
                MessageBox.Show("No Publications Found");
            }
            else
            {
                lbl3yearaverage.Text = _researcherdetails.PublicationsCount3Year().ToString();
                lblcampus.Text = _researcherdetails.Campus.ToString();
                lblemail.Text = _researcherdetails.Email.ToString();
                lblname.Text = _researcherdetails.FamilyName.ToString();
                lblq1percentage.Text = _researcherdetails.Q1Percentage().ToString();

                lbltitle.Text = _researcherdetails.Title.ToString();
                lblperformancebypublication.Text = _researcherdetails.PerformanceByPublication().ToString();

                if (_researcherdetails is Staff staffmember)
                {
                    lblperformancebyfunding.Text = staffmember.Performance().ToString();
                    lblschoolorunit.Text = staffmember.School.ToString();

                }
            }

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
