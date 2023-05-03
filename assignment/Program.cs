using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.DataSource;
using RAP.Entities;


namespace assignment
{
    class Program
    {

        static void Main(string[] args)
        {
            ERDAdapter adapter = new ERDAdapter();
            Researcher[] researchers = adapter.fetchBasicResearcherDetails();
            foreach (Researcher r in researchers)
            {
                Console.WriteLine(r);
            }
        }
    }
}
