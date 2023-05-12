using RAP.Entities;
using RAP.Controller;
using System.Collections.Generic;
using System.Windows;

namespace WpfAppForms { 

    public partial class Supervisees : Window
    {
        private List<Student> supervisees;

        public Supervisees(List<Student> Supervisees)
        {
            InitializeComponent();
            supervisees = Supervisees;
            Loaded += Supervisees_Loaded;
        }
        private void Supervisees_Loaded(object sender, RoutedEventArgs e)
        {
            PopulateListBox();
        }
        private void PopulateListBox()
        {
            listsupervisees.Items.Clear();

            foreach (var student in supervisees)
            {
                listsupervisees.Items.Add(student.ToString());
            }
        }
    }
}
