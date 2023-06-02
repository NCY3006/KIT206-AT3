namespace RAPLibrary.Entities
{
    public enum OutputType { Conference, Journal, Other };

    public class Publication
    {
        // Variables and display the DateTime format function 
        private string doi;
        private string title;
        private string authors;
        private DateTime year;
        private OutputType type;
        private string citeAs;
        private DateTime available;
        private int ranking;

        public string DOI
        {
            get { return doi; }
            set { doi = value; }
        }
        public int Ranking
        {
            get { return ranking; }
            set { ranking = value; }
        }
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Authors
        {
            get { return authors; }
            set { authors = value; }
        }

        public DateTime Year
        {
            get { return year; }
            set { year = value; }
        }

        public OutputType Type
        {
            get { return type; }
            set { type = value; }
        }

        public string CiteAs
        {
            get { return citeAs; }
            set { citeAs = value; }
        }

        public DateTime Available
        {
            get { return available; }
            set { available = value; }
        }

        
        // Functions methods 
        // Calculate the age of publications in days    
        // Return age in number of days
        public int Age()
        {
            // Current time - available
            return (DateTime.Now - Available).Days; 
        }

        public override string ToString()
        {
            return Year.Year + ", " + Title;
        }
    }
}
