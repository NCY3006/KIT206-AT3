using RAPLibrary.Controller;
using RAPLibrary.Entities;

namespace RAPForms
{
    public partial class Form1 : Form
    {
        private ResearcherController _researcherController;
        private Researcher selectedResearcher;
        public Form1()
        {
            InitializeComponent();
            listresearchers.View = View.Details;
            listresearchers.Columns.Add("Family Name", 120);
            listresearchers.Columns.Add("Title", 120);
            listresearchers.Columns.Add("Employment Level", 120);
            _researcherController = new ResearcherController();

            // Call the necessary methods to load the data then sort them
            var researchers = _researcherController.Reseachers.OrderBy(r => r.FamilyName).ToList();
            selectedResearcher = researchers.First();
            // Do something with the data, such as populate a listbox
            foreach (var researcher in researchers)
            {
                var item = new ListViewItem(researcher.ToString());
                item.SubItems.Add(researcher.CurrentJobTitle());
                item.SubItems.Add(researcher.GetCurrentJob().Level.ToString());
                listresearchers.Items.Add(item);
            }
        }

        private void btnperformancedetails_Click(object sender, EventArgs e)
        {
            performancedetailsform frm = new performancedetailsform(researcher: selectedResearcher);
            frm.ShowDialog();
        }

        private void btncumulativecount_Click(object sender, EventArgs e)
        {

            cumulativecountform frm = new cumulativecountform(selectedresearcher: selectedResearcher); ;
            frm.ShowDialog();
        }

        private void btnsupervisiondetails_Click(object sender, EventArgs e)
        {
            //check to see if it is a staff
            if (selectedResearcher is Staff staffMember)
            {
                List<Student> supervisees = staffMember.Supervisions;

                superviseelistform superviseelistformfrm = new superviseelistform(_supervisees: supervisees);
                superviseelistformfrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No Supervisees Found");
            }
        }

        private void btngenerateperformancereport_Click(object sender, EventArgs e)
        {
            List<Researcher> allresearchers = _researcherController.Reseachers;

            performancereportform frm = new performancereportform(allResearchers: allresearchers);
            frm.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panelresearcherdetails.Visible = false;
            panelresearcherpublications.Visible = false;
        }

        /// <summary>
        /// when the button for searching researchers is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnsearchresearchers_Click(object sender, EventArgs e)
        {
            //get the value added to the txtsearch
            //if not null, then perform the search. 
            string searchtext = txtname.Text.ToString();

            if (string.IsNullOrEmpty(searchtext))
            {
                MessageBox.Show("Please enter a search term");
                return;
            }


            var students = _researcherController.Reseachers.Where(r => r.FamilyName.Contains(searchtext));
            listresearchers.Items.Clear();
            if (students.Count() < 1)
            {
                MessageBox.Show("No researchers found.");
            }
            else
            {
                foreach (var student in students)
                {
                    var item = new ListViewItem(student.FamilyName);
                    item.SubItems.Add(student.CurrentJobTitle());
                    item.SubItems.Add(student.GetCurrentJob().Level.ToString());
                    listresearchers.Items.Add(item);
                }
            }


        }
        /// <summary>
        /// when the drop down value is changed 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cmblevelfilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            //get the selected value
            //return only the data that has that value.
            string selectedValue = cmblevelfilter.SelectedItem.ToString();
            if (selectedValue == "Students Only")
            {
                // Filter by students
                var students = _researcherController.Reseachers.Where(r => r.Type == "Student");
                listresearchers.Items.Clear();
                foreach (var student in students)
                {
                    var item = new ListViewItem(student.FamilyName);
                    item.SubItems.Add(student.CurrentJobTitle());
                    item.SubItems.Add(student.GetCurrentJob().Level.ToString());
                    listresearchers.Items.Add(item);
                }
            }
            else
            {
                // Filter by employment level
                var filtered = _researcherController.Reseachers.Where(r => r.GetCurrentJob().Level.ToString() == selectedValue.Split(' ')[1]);
                listresearchers.Items.Clear();
                foreach (var researcher in filtered)
                {
                    var item = new ListViewItem(researcher.FamilyName);
                    item.SubItems.Add(researcher.CurrentJobTitle());
                    item.SubItems.Add(researcher.GetCurrentJob().Level.ToString());
                    listresearchers.Items.Add(item);
                }
            }
        }
        /// <summary>
        /// When enter key is pressed for the txtname field
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtname_KeyPress(object sender, KeyPressEventArgs e)
        {
            //check first and make sure it is the enter key
            if (e.KeyChar == (char)Keys.Enter)
            {
                string searchtext = txtname.Text.ToString();
                if (string.IsNullOrEmpty(searchtext))
                {
                    MessageBox.Show("Please enter a value to search.");
                    return;
                }
                var students = _researcherController.Reseachers.Where(r => r.FamilyName.Contains(searchtext));
                listresearchers.Items.Clear();
                if (students.Count() == 0)
                {
                    MessageBox.Show("No researchers found.");
                }
                else
                {
                    foreach (var student in students)
                    {
                        var item = new ListViewItem(student.FamilyName);
                        item.SubItems.Add(student.CurrentJobTitle());
                        item.SubItems.Add(student.GetCurrentJob().Level.ToString());
                        listresearchers.Items.Add(item);
                    }
                }


            }
        }

        private void listresearchers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listresearchers.SelectedItems.Count == 1)
            {
                var selectedItem = listresearchers.SelectedItems[0];
                string selectedResearcherName = selectedItem.Text;
                selectedResearcher = _researcherController.Reseachers
                                               .FirstOrDefault(r => r.FamilyName == selectedResearcherName);


                //
                // ... add other details as needed
                var researchdetails = _researcherController.LoadResearcherDetails(selectedResearcher);
                if (selectedResearcher is Student studentdetails)
                {
                    lbldegree.Text = studentdetails.Degree.ToString();
                    lblsupervisor.Text = studentdetails.SupervisorName.ToString();
                }
                else
                {
                    lbldegree.Text = "N/A";
                    lblsupervisor.Text = "N/A";
                }

                lblname.Text = researchdetails.FamilyName.ToString();
                lblemail.Text = researchdetails.Email.ToString();
                lbljob.Text = researchdetails.GetCurrentJob().ToString();
                lbltitle.Text = researchdetails.CurrentJobTitle().ToString();
                lblschoolorunit.Text = researchdetails.School.ToString();
                lbltenure.Text = researchdetails.Tenure().ToString();
                lbljob.Text = researchdetails.CurrentJobStart().ToString();
                ptbphotourl.Image = Image.FromFile(researchdetails.Photo.AbsolutePath);
                lblcommenceinstitution.Text = researchdetails.CurrentJobStart().ToString();

                if (researchdetails is Staff staff)
                {
                    foreach (var position in staff.Positions)
                    {
                        var item = new ListViewItem(position.Title);
                        item.SubItems.Add(position.Start.ToString());
                        item.SubItems.Add(position.End.ToString());
                        lstpreviouspositions.Items.Add(item);
                    }
                    foreach (var item in staff.Publications)
                    {
                        txtpublications.AppendText(item.Title.ToString());
                        txtpublications.AppendText(" , ");

                        var listitem = new ListViewItem(item.Year.ToString());
                        listitem.SubItems.Add(item.Title.ToString());
                        lstpublications.Items.Add(listitem);

                    }

                }
                else
                {
                    lstpreviouspositions.Items.Add("N/A");
                    lstpublications.Items.Add("N/A");

                }

                if (researchdetails is Staff staffdetails)
                {
                    panelresearcherdetails.Visible = true;
                    panelresearcherpublications.Visible = true;
                }
            }
            else
            {
                panelresearcherdetails.Visible = false;
            }
        }

        private void btninvertorderpublications_Click(object sender, EventArgs e)
        {
            var researchdetails = _researcherController.LoadResearcherDetails(selectedResearcher);
            lstpublications.Items.Clear();

            var publications = researchdetails.Publications;
            publications.Reverse();

            foreach (var item in publications)
            {

                var listitem = new ListViewItem(item.Year.ToString());
                listitem.SubItems.Add(item.Title.ToString());
                lstpublications.Items.Add(listitem);
            }

        }

        private void btnsearchpublications_Click(object sender, EventArgs e)
        {
            int yearFrom = 0;
            int yearTo = 0;
            bool isValidYearFrom = int.TryParse(txtyearfrom.Text, out yearFrom);
            bool isValidYearTo = int.TryParse(txtyearto.Text, out yearTo);

            if (isValidYearFrom && isValidYearTo)
            {
                var researchdetails = _researcherController.LoadResearcherDetails(selectedResearcher);
                lstpublications.Items.Clear();

                var publications = researchdetails.Publications;
                var filteredPublications = publications
                    .Where(p => p.Year.Year >= yearFrom && p.Year.Year <= yearTo)
                    .ToList();
                foreach (var item in filteredPublications)
                {

                    var listitem = new ListViewItem(item.Year.ToString());
                    listitem.SubItems.Add(item.Title.ToString());
                    lstpublications.Items.Add(listitem);
                }

                // do something with the filtered publications
            }
            else
            {
                MessageBox.Show("Please enter valid years");
            }

        }
    }
}
