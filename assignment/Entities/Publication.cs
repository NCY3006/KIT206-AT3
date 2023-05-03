﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP.Entities
{
    public class Publication
    {
        public string DOI { get; set; } //pk
        public string Title { get; set; }
        public string Authors { get; set; }
        public int PublicationYear { get; set; }
        public OutPutType type { get; set; }
        public Ranking ranking { get; set; }
        public string CiteAs { get; set; }
        public DateTime Available { get; set; }

        // calculate the age
        public int Age()
        {
            var today = DateTime.Today;
            var age = today.Year - PublicationYear;
            return age;
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
