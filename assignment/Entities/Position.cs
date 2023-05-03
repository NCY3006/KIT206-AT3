using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP.Entities
{
    public class Position
    {
        public int id { get; set; }
        public EmploymentLevel level;
        public DateTime start;
        public DateTime end;

        public Position(EmploymentLevel _level, DateTime _start, DateTime _end)
        {
            level = _level;
            start = _start;
            end = _end;
        }

        // Ask the tutor what we should do with the title
        // It's easy to see if it's a Dr, but what about Mr, Mrs, Ms
        public string Title()
        {
            return "";
        }
    }
}
