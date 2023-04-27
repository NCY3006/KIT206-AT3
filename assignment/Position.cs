using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class Position
    {
        public EmploymentLevel level;
        public Date start;
        public Date end;

        public Position(EmploymentLevel _level, Date _start, Date _end)
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
