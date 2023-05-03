using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using RAP.Entities;
using RAP.Controller;
using RAP;

namespace RAP.DataSource
{
  //private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\PublicationRecord");

    public class ResearcherDatabaseAdapter
    {
        private static bool reportingErrors = false;

        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// Creates and returns the connection to the database.

        private static MySqlConnection GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
            return conn;
        }

            public Researcher[] researchers;

            public ResearcherDatabaseAdapter()
            {
                researchers = new Researcher[] {
                    new Student(123, "Oscar", "Huang", "UTAS", "Launceston", "123@123.com", "dawd", new Position[] {new Position(EmploymentLevel.Student, new Date(2023, 4, 25), new Date(2023, 4, 26)) }, new Publication[] { }),
                    new Staff(123, "O", "H", "UTAS", "Launceston", "123@123.com", "dawd", new Position[] {new Position(EmploymentLevel.B, new Date(2023, 4, 25), new Date(2023, 4, 26)) }, new Publication[] { })
                };
        }
    }
}
