using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class ResearcherDatabaseAdapter
    {
        public Researcher[] researchers;

        public ResearcherDatabaseAdapter()
        {
            researchers = new Researcher[] {
                new Student(123, "Oscar", "Huang", "UTAS", "Launceston", "123@123.com", "dawd", new Position[] {new Position(EmploymentLevel.Student, new Date(2023, 4, 25), new Date(2023, 4, 26)) }, new Publication[] { }),
                new Staff(123, "O", "H", "UTAS", "Launceston", "123@123.com", "dawd", new Position[] {new Position(EmploymentLevel.B, new Date(2023, 4, 25), new Date(2023, 4, 26)) }, new Publication[] { })
            };
        }
    }
}
