using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class Publication
    {
        public string DOI { get; set; }
        public string Title { get; set; }
        public string Authors { get; set; }
        //public Date date;
        public int PublicationYear { get; set; }
        public OutPutType type{ get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }

        // calculate the age
        public int Age()
        {
            var today = DateTime.Today;
            var age = today.Year - PublicationYear;
            return age;
        }
    }
}
