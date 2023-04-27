using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace assignment
{
    class Controller
    {

        public Researcher[] allResearchers(ResearcherDatabaseAdapter adapter)
        {
            return adapter.researchers;
        }

        public Researcher[] FilterByLevel(ResearcherDatabaseAdapter adapter, EmploymentLevel level)
        {
            return adapter.researchers.Where(researcher => researcher.GetCurrentJob().level == level).ToArray();
        }

        private bool CheckName(Researcher researcher, string name)
        {
            if (researcher.GivenName.Contains(name))
            {
                return true;
            }
            else if (researcher.FamilyName.Contains(name))
            {
                return true;
            }
            else if ((researcher.GivenName + " " + researcher.FamilyName).Contains(name))
            {
                return true;
            }
            else if ((researcher.FamilyName + " " + researcher.GivenName).Contains(name))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Researcher[] FilterByName(ResearcherDatabaseAdapter adapter, string name)
        {
            return adapter.researchers.Where(researcher => CheckName(researcher, name)).ToArray();
        }

        public Publication[] LoadPublicationsFor(Researcher researcher)
        {
            return researcher.publications;
        }
    }
}
