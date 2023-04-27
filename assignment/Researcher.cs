using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment
{
    public class Researcher
    {
        public int id;
        public string GivenName;
        public string FamilyName;
        public string Title;
        public string School;
        public string Campus;
        public string Email;
        public string Photo;
        public Position[] positions;
        public Publication[] publications;

        public Researcher (int _id, string _GivenName, string _FamilyName, string _School, string _Campus, string _Email, string _Photo, Position[] _positions, Publication[] _publications)
        {
            id = _id;
            GivenName = _GivenName;
            FamilyName = _FamilyName;
            School = _School;
            Campus = _Campus;
            Email = _Email;
            Photo = _Photo; 
            positions = _positions;
            publications = _publications;

            // If last position has end date, raise an error
            if (positions.Last().end == null)
            {
                Console.WriteLine("Last job has end date");
                Environment.Exit(0);
            }

            Title = positions.Last().Title();
        }

        public string CurrentJobTitle()
        {
            return Title;
        }

        public Date CurrentJobStart()
        {
            return positions.Last().start;
        }

        public Position GetCurrentJob()
        {
            return positions.Last();
        }

        public Date EarliestStart()
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
