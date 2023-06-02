﻿namespace RAPLibrary.Entities
{

    public enum EmploymentLevel { Student, A, B, C, D, E }
    public class Position
    {
        //variables
        private EmploymentLevel level;
        private DateTime start;
        private DateTime end;

        public EmploymentLevel Level
        {
            get { return level; }
            set { level = value; }
        }

        public DateTime Start
        {
            get { return start.Date; }
            set { start = value; }
        }

        public DateTime End
        {
            get { return end.Date; }
            set { end = value; }
        }

        public string Title
        {
            get { return ToTitle(Level); }
        }


       
        // Functions methods
        /// <summary>
        /// "Converts" enum of employment level to a string
        /// </summary>
        /// <param name="l"></param>
        /// <returns>String of title that was represented by enum</returns>
        public string ToTitle(EmploymentLevel l)
        {
            string job = "N/A";
            // Get the employment levels
            switch (l)
            {
                case EmploymentLevel.Student:
                    job = "Student";
                    break;
                case EmploymentLevel.A:
                    job = "Postdoc";
                    break;
                case EmploymentLevel.B:
                    job = "Lecturer";
                    break;
                case EmploymentLevel.C:
                    job = "Senior Lecturer";
                    break;
                case EmploymentLevel.D:
                    job = "Associate Professor";
                    break;
                case EmploymentLevel.E:
                    job = "Professor";
                    break;
            }

            return job;
        }


    }

}
