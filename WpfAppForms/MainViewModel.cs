using System.Collections.ObjectModel;

namespace WpfAppForms
{
    public class MainViewModel
    {
        public ObservableCollection<string> Levels { get; set; }

        public MainViewModel()
        {
            Levels = new ObservableCollection<string>
            {
                "All Levels",
                "Students Only",
                "Level A",
                "Level B",
                "Level C",
                "Level D",
                "Level E"
            };
        }
    }
}
