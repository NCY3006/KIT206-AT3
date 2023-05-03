using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP.Entities
{
    public enum EmploymentLevel
    {
        Student, A, B, C, D, E
    }

    public enum OutPutType
    {
        Conference, Journal, Other
    }

    public class Date
    {
        public int year;
        public int month;
        public int day;

        public Date(int _year, int _month, int _day)
        {
            year = _year;
            month = _month;
            day = _day;
        }

        public override string ToString()
        {
            return year + "/" + month + "/" + day;
        }
    }
}
