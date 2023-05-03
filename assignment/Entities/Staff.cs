using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAP;


namespace RAP.Entities
{
    public class Staff : Researcher
    {
        // IDK I just followed google. Anyone with a smarther way can just change it
        public Staff(int _id, string _GivenName, string _FamilyName, string _School, string _Campus, string _Email, string _Photo, Position[] _positions, Publication[] _publications) : base(_id, _GivenName, _FamilyName, _School, _Campus, _Email, _Photo, _positions, _publications)
        {

        }
    }
}
