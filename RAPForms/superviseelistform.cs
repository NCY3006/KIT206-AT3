using RAPLibrary.Entities;

namespace RAPForms
{
    public partial class superviseelistform : Form
    {
        List<Student> supervisees;
        public superviseelistform(List<Student> _supervisees)
        {
            InitializeComponent();
            this.supervisees = _supervisees;
        }

        private void superviseelistform_Load(object sender, EventArgs e)
        {
            lsbsupervisees.Items.Clear();
            foreach (var student in supervisees)
            {
                lsbsupervisees.Items.Add(student.ToString());
            }
        }
    }
}
