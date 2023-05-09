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
using System.Data;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;

namespace RAP.DataSource
{
    //private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\PublicationRecord");

    public class ERDAdapter
    {
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private MySqlConnection conn = null;

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// Creates and returns the connection to the database.

        private void GetConnection()
        {
            if (conn == null)
            {
                string connectionString = String.Format("Database={0};Data Source={1};User Id={2};Password={3}", db, server, user, pass);
                conn = new MySqlConnection(connectionString);
            }
        }

        // id, name, title, level
        public List<Researcher> fetchBasicResearcherDetails()
        {
            List<Researcher> researchers = new List<Researcher>();
            conn.Open();

            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select id, given_name, family_name, title, level from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");
                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    Researcher cur = new Researcher();
                    cur.id = (int)row["id"];
                    cur.GivenName = row["given_name"].ToString();
                    cur.FamilyName = row["family_name"].ToString();
                    if (row["level"].ToString() != "")
                    {
                        cur.level = (EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), row["level"].ToString());
                    }
                    else
                    {
                        cur.level = EmploymentLevel.Student;
                    }
                    cur.Title = row["title"].ToString();
                    researchers.Add(cur);
                }
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }

            return researchers;
        }

        public Researcher fetchFullResearcherDetails(int id)
        {
            Researcher researcher = new Researcher();

            conn.Open();

            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher where id = " + id, conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    researcher.GivenName = row["given_name"].ToString();
                    researcher.FamilyName = row["family_name"].ToString();
                    researcher.Title = row["title"].ToString();
                    researcher.Unit = row["unit"].ToString();
                    researcher.Campus = row["campus"].ToString();
                    if (row["email"].ToString() != null)
                    {
                        researcher.Email = row["email"].ToString();
                    }
                    else
                    {
                        researcher.Email = null;
                    }
                    if (row["photo"].ToString() == "")
                    {
                        researcher.Photo = row["photo"].ToString();
                    }
                    researcher.Degree = row["degree"].ToString();
                    if (row["supervisor_id"].ToString() != "") {
                        researcher.SupervisorId = (int)row["supervisor_id"];
                    }
                    else
                    {
                        researcher.SupervisorId = null;
                    }
                    researcher.type = (ResearcherType)Enum.Parse(typeof(ResearcherType), row["type"].ToString());
                    if (row["level"].ToString() != "")
                    {
                        researcher.level = (EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), row["level"].ToString());
                    }
                    else
                    {
                        researcher.level = EmploymentLevel.Student;
                    }
                    if (row["utas_start"].ToString() != "")
                    {
                        researcher.utasStart = Convert.ToDateTime(row["utas_start"]);
                    }
                    else
                    {
                        researcher.utasStart = null;
                    }
                    if (row["current_start"].ToString() != "")
                    {
                        researcher.currentStart = Convert.ToDateTime(row["current_start"]);
                    }
                    else
                    {
                        researcher.currentStart = null;
                    }
                }
                return researcher;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Researcher completeResearcherDetails(Researcher researcher)
        {
            conn.Open();

            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher where id = " + researcher.id, conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    researcher.GivenName = row["given_name"].ToString();
                    researcher.FamilyName = row["family_name"].ToString();
                    researcher.Title = row["title"].ToString();
                    researcher.Unit = row["unit"].ToString();
                    researcher.Campus = row["campus"].ToString();
                    if (row["email"].ToString() != null)
                    {
                        researcher.Email = row["email"].ToString();
                    }
                    else
                    {
                        researcher.Email = null;
                    }
                    if (row["photo"].ToString() == "")
                    {
                        researcher.Photo = row["photo"].ToString();
                    }
                    researcher.Degree = row["degree"].ToString();
                    if (row["supervisor_id"].ToString() != "")
                    {
                        researcher.SupervisorId = (int)row["supervisor_id"];
                    }
                    else
                    {
                        researcher.SupervisorId = null;
                    }
                    researcher.type = (ResearcherType)Enum.Parse(typeof(ResearcherType), row["type"].ToString());
                    if (row["level"].ToString() != "")
                    {
                        researcher.level = (EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), row["level"].ToString());
                    }
                    else
                    {
                        researcher.level = EmploymentLevel.Student;
                    }
                    if (row["utas_start"].ToString() != "")
                    {
                        researcher.utasStart = Convert.ToDateTime(row["utas_start"]);
                    }
                    else
                    {
                        researcher.utasStart = null;
                    }
                    if (row["current_start"].ToString() != "")
                    {
                        researcher.currentStart = Convert.ToDateTime(row["current_start"]);
                    }
                    else
                    {
                        researcher.currentStart = null;
                    }
                }
                return researcher;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Publication> fetchBasicPublicationDetails(Researcher r)
        {
            List<Publication> publications = new List<Publication>();
            conn.Open();
            try
            {
                var publicationDataSet = new DataSet();
                var publicationAdapter = new MySqlDataAdapter("select publication.doi, publication.year, publication.title from publication, researcher, researcher_publication where researcher_publication.researcher_id = researcher.id and researcher_publication.doi = publication.doi and researcher.id = " + r.id, conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    Publication cur = new Publication();
                    cur.Title = row["title"].ToString();
                    cur.DOI = row["doi"].ToString();
                    cur.PublicationYear = int.Parse(row["year"].ToString());

                    publications.Add(cur);
                }
                return publications;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public Publication completePublicationDetails(Publication p)
        {
            conn.Open();

            try
            {
                var publicationDataSet = new DataSet();
                var publicationAdapter = new MySqlDataAdapter("select * from publication where doi = '" + p.DOI + "'", conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    p.DOI = row["doi"].ToString();
                    p.Title = row["title"].ToString();
                    p.Authors = row["authors"].ToString();
                    p.ranking = (Ranking)Enum.Parse(typeof(Ranking), row["ranking"].ToString());
                    p.type = (OutPutType)Enum.Parse(typeof(OutPutType), row["type"].ToString());
                    p.CiteAs = row["cite_as"].ToString();
                    p.Available = Convert.ToDateTime(row["available"]);
                }
                return p;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public int[] fetchPublicationCounts(int from, int to)
        {
            int[] counts = new int[to - from + 1];
            for (int i = 0; i < counts.Length; i++)
                counts[i] = 0;
            conn.Open();

            try
            {
                var publicationDataSet = new DataSet();
                var publicationAdapter = new MySqlDataAdapter("select year from publication where year >= " + from + " and year <= " + to, conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    counts[int.Parse(row["year"].ToString()) - from] += 1;
                }
                return counts;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public List<Position> fetchPositionFromId(int id)
        {
            List<Position> positions = new List<Position>();
            conn.Open();
            try
            {
                var publicationDataSet = new DataSet();
                var publicationAdapter = new MySqlDataAdapter("select * from position where id = " + id, conn);
                publicationAdapter.Fill(publicationDataSet, "position");

                foreach (DataRow row in publicationDataSet.Tables["position"].Rows)
                {
                    Position cur = new Position();
                    cur.level = (EmploymentLevel)Enum.Parse(typeof(EmploymentLevel), row["level"].ToString());
                    cur.start = Convert.ToDateTime(row["start"]);
                    if (row["end"].ToString() != "") {
                        cur.end = Convert.ToDateTime(row["end"]);
                    }
                    else
                    {
                        cur.end = null;
                    }

                    positions.Add(cur);
                }
                return positions;
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }

        public ERDAdapter()
        {
            GetConnection();
        }
    }
}
