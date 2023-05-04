using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAP.DataSource;
using RAP.Entities;

namespace RAP.Controller
{
    class ResearcherController
    {
        public List<Researcher> Researchers { get; set; }
        public Researcher CurrentResearcher { get; set; }

        public ResearcherController()
        {
            Researchers = new List<Researcher>();
        }

        public void initialize()
        {
            ERDAdapter adapter = new ERDAdapter();
            Researchers = adapter.fetchBasicResearcherDetails();
        }

        public void filterResearchersByName(string name)
        {
            IEnumerable<Researcher> filtered = from r in Researchers
                           where (r.GivenName == name)
                           select r;
            List<Researcher> newR = new List<Researcher>();
            foreach (Researcher researcher in filtered.ToList())
            {
                newR.Add(researcher);
            }
            Researchers = newR;
        }
    }
    
}