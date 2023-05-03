using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAP.Entities;

namespace RAP.Controller
{
    class ResearcherController
    {
        public static List<Researcher> Researchers { get; set; }
        public static Researcher CurrentResearcher { get; set; }
    }

}