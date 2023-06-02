namespace RAPLibrary.Entities
{

    public class Staff : Researcher
    {
        // Variables
        private List<Student> supervisions;

        public List<Student> Supervisions
        {
            get { return supervisions; }
            set { supervisions = value; }
        }

       
        // Functions methods
        // Adds a single student to the staff member's supervision list
        public void AddSupervision(Student student)
        {
            Supervisions.Add(student);
        }

        // Average publications over three years
        public float ThreeYearAverage()
        {
            return PublicationsCount3Year() / 3f;
        }

        // Performance value calculation (ThreeYearAverage / expected number of puclications)
        public float Performance()
        {
            // Get employment level
            float p = 1f;
            EmploymentLevel pos = GetCurrentJob().Level;

            switch (pos)
            {
                case EmploymentLevel.A:
                    p = 0.5f;
                    break;
                case EmploymentLevel.B:
                    p = 1f;
                    break;
                case EmploymentLevel.C:
                    p = 2;
                    break;
                case EmploymentLevel.D:
                    p = 3.2f;
                    break;
                case EmploymentLevel.E:
                    p = 4f;
                    break;
            }

            // calculate performance
            return (float)Math.Round(100f * (ThreeYearAverage() / p), 1);
        }
    }
}
