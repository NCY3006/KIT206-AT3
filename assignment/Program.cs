using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP.DataSource;
using RAP.Controller;
using RAP.Entities;
using RAP.PublicationController;

namespace assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            ERDAdapter adapter = new ERDAdapter();
            ResearcherController researcherController = new ResearcherController(adapter);
            PublicationController publicationController = new PublicationController(adapter);

            researcherController.filterResearchersByName("John");
            foreach (Researcher r in researcherController.Researchers)
            {
                Console.WriteLine(r);
            }
        }
    }
}
