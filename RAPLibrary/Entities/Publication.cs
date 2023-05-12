namespace RAP.Entities
{
    public enum OutputType { Conference, Journal, Other };

    public class Publication
    {
        //variables
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


        public int Age()
        {
            return (DateTime.Now - Available).Days; //current time - available
        }

        public override string ToString()
        {
            return Year.Year + ", " + Title;
        }
    }
}
