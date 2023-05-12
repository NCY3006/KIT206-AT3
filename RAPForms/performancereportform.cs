using RAPLibrary.Entities;

namespace RAPForms
{
    public partial class performancereportform : Form
    {
        List<Researcher> researchers;
        public performancereportform(List<Researcher> allResearchers)
        {
            researchers = allResearchers;
            InitializeComponent();
        }

        private void performancereportform_Load(object sender, EventArgs e)
        {
            var poorPerformers = new List<(string Name, float Performance)>();
            var belowExpectations = new List<(string Name, float Performance)>();
            var meetingMinimum = new List<(string Name, float Performance)>();
            var starPerformers = new List<(string Name, float Performance)>();

            foreach (var selectedResearcher in researchers)
            {
                float performance = 0; // Assuming you have a method to calculate performance

                if (selectedResearcher is Staff staffmember)
                {
                    performance = staffmember.Performance();
                }

                if (performance < 50) // Adjust these thresholds as necessary
                {
                    poorPerformers.Add((selectedResearcher.ToString(), performance));
                }
                else if (performance < 70)
                {
                    belowExpectations.Add((selectedResearcher.ToString(), performance));
                }
                else if (performance < 90)
                {
                    meetingMinimum.Add((selectedResearcher.ToString(), performance));
                }
                else
                {
                    starPerformers.Add((selectedResearcher.ToString(), performance));
                }

            }
            poorPerformers.Sort((x, y) => y.Performance.CompareTo(x.Performance));
            belowExpectations.Sort((x, y) => y.Performance.CompareTo(x.Performance));
            meetingMinimum.Sort((x, y) => y.Performance.CompareTo(x.Performance));
            starPerformers.Sort((x, y) => y.Performance.CompareTo(x.Performance));

            foreach (var item in poorPerformers)
            {
                lsbpoor.Items.Add(item);
            }
            foreach (var item in belowExpectations)
            {
                lsbbelow.Items.Add(item);
            }
            foreach (var item in meetingMinimum)
            {
                lsbminimum.Items.Add(item);
            }
            foreach (var item in starPerformers)
            {
                lsbstar.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var emails = researchers.Select(r => r.Email).ToList();
            var emailString = string.Join(", ", emails);
            Clipboard.SetText(emailString);
        }
    }
}
