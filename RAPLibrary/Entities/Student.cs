﻿namespace RAP.Entities
{
    // Class for Student inheriting from Researcher
    public class Student : Researcher
    {
        //variables
        private string degree;
        private int supervisor;
        private string supervisorName;

        public string Degree
        {
            get { return degree; }
            set { degree = value; }
        }

        public int Supervisor
        {
            get { return supervisor; }
            set { supervisor = value; }
        }

        public string SupervisorName
        {
            get { return supervisorName; }
            set { supervisorName = value; }
        }
        public override string ToString()
        {
            return $"{GivenName} {FamilyName}, pursuing {Degree}, supervised by {SupervisorName}";
        }

    }


}
