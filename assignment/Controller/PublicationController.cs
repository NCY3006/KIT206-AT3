using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAP.Entities;
using RAP.DataSource;

namespace RAP.PublicationController
{
    class PublicationController
    {
        public List<string> PublicationYears { get; set; }
        public List<Publication> Publications { get; set; }
        private ERDAdapter adapter;

        public PublicationController(ERDAdapter _adapter)
        {
            adapter = _adapter;
        }

        public void filterPublicationByResearcher(Researcher researcher)
        {
            Publications = adapter.fetchBasicPublicationDetails(researcher);
        }
    }
}
