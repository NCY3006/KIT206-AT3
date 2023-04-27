using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearcherDatabaseAdapter adapter = new ResearcherDatabaseAdapter();
            Researcher[] researchers = Controller.allResearchers(adapter);
            foreach (Researcher re in researchers)
            {
                Console.WriteLine(re);
            }
        }
    }
}
