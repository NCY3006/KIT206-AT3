using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;

namespace RAP.Entities
{
    public class Researcher
    {
        public int id { get; set; } //pk
        public int? SupervisorId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string Title { get; set; }
        public string School { get; set; }
        public string Campus { get; set; }
        public string? Email { get; set; }
        public string Unit { get; set; }
        public string? Photo { get; set; }
        public string? Degree { get; set; }
        public EmploymentLevel? level { get; set; }
        public DateTime? utasStart { get; set; }
        public DateTime? currentStart { get; set; }
        public ResearcherType type { get; set; }
        public Position[] positions { get; set; }
        public Publication[] publications { get; set; }

        public string CurrentJobTitle()
        {
            return Title;
        }

        public DateTime CurrentJobStart()
        {
            return positions.Last().start;
        }

        public Position GetCurrentJob()
        {
            return positions.Last();
        }

        public DateTime EarliestStart()
        {
            return positions.First().start;
        }

        // Don't want to do the calculation implementation tonight
        public int Tenure()
        {
            return 0;
        }

        public int PublicationsCount()
        {
            return publications.Count();
        }

        public override string ToString()
        {
            return GivenName;
        }
    }
}
