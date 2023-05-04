using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.DataSource;
using RAP.Controller;
using RAP.Entities;


namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearcherController researcherController = new ResearcherController();
            researcherController.initialize();
            researcherController.filterResearchersByName("John");
            foreach (Researcher r in researcherController.Researchers)
            {
                Console.WriteLine(r);
            }
        }
    }
}
