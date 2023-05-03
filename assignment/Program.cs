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

            Console.WriteLine("Testing fetchBasicResearcherDetails");
            foreach (Researcher r in researchers)
            {
                Console.WriteLine(r);
            }

            Console.WriteLine("Testing fetchFullResearcherDetails");
            foreach (Researcher r in researchers)
            {
                Console.WriteLine(adapter.fetchFullResearcherDetails(r.id));
            }

            Console.WriteLine("Testing completeResearcherDertails");
            foreach (Researcher r in researchers)
            {
                Console.WriteLine(adapter.completeResearcherDetails(r));
            }

            Console.WriteLine("Testing fetchBasicPublicationDetails");
            foreach (Researcher r in researchers)
            {
                foreach (Publication p in adapter.fetchBasicPublicationDetails(r))
                {
                    Console.WriteLine(p);
                }
            }

            Console.WriteLine("Testing completePublicationDetails");
            foreach (Researcher r in researchers)
            {
                foreach (Publication p in adapter.fetchBasicPublicationDetails(r))
                {
                    Console.WriteLine(adapter.completePublicationDetails(p));
                }
            }

        }
    }
}
