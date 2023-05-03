﻿using System;
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

namespace RAP.DataSource
{
    //private static readonly string filePath = Path.Combine(Directory.GetCurrentDirectory(), "\\PublicationRecord");

    public class ERDAdapter
    {
        private static bool reportingErrors = false;

        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;
        MySqlDataReader rdr = null;
        public Researcher[] researchers;

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
        public Researcher[] fetchBasicResearcherDetails()
        {
            List<Researcher> researchers = new List<Researcher>();
            
            conn.Open();

            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select given_name, family_name, title, level from researcher", conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    Researcher cur = new Researcher();
                    cur.GivenName = row["given_name"].ToString();
                    cur.FamilyName = row["family_name"].ToString();
                    cur.level = (EmploymentLevel)row["level"];
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

            return researchers.ToArray();
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
                    researcher.Email = row["email"].ToString();
                    researcher.Photo = row["photo"].ToString();
                    researcher.Degree = row["degree"].ToString();
                    researcher.SupervisorId = (int)row["supervisor_id"];
                    researcher.type = (ResearcherType)row["type"];
                    researcher.level = (EmploymentLevel)row["level"];
                    researcher.start = (DateTime)row["start"];
                    researcher.start = (DateTime)row["end"];
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

        public Researcher completeResearcherDertails(Researcher r)
        {
            conn.Open();

            try
            {
                var researcherDataSet = new DataSet();
                var researcherAdapter = new MySqlDataAdapter("select * from researcher where id = " + r.id, conn);
                researcherAdapter.Fill(researcherDataSet, "researcher");

                foreach (DataRow row in researcherDataSet.Tables["researcher"].Rows)
                {
                    r.GivenName = row["given_name"].ToString();
                    r.FamilyName = row["family_name"].ToString();
                    r.Title = row["title"].ToString();
                    r.Unit = row["unit"].ToString();
                    r.Campus = row["campus"].ToString();
                    r.Email = row["email"].ToString();
                    r.Photo = row["photo"].ToString();
                    r.Degree = row["degree"].ToString();
                    r.SupervisorId = (int)row["supervisor_id"];
                    r.type = (ResearcherType)row["type"];
                    r.level = (EmploymentLevel)row["level"];
                    r.start = (DateTime)row["start"];
                    r.start = (DateTime)row["end"];
                }
                return r;
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

        public Publication[] fetchBasicPublicationDetails(Researcher r)
        {
            List<Publication> publications = new List<Publication>();
            conn.Open();

            try
            {
                var publicationDataSet = new DataSet();
                var publicationAdapter = new MySqlDataAdapter("select publication.year, publication.title from publication, researcher, researcher_publication where researcher_publication.researcher_id = researcher.id and researcher_publication.doi = publication.doi" + r.id, conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    Publication cur = new Publication();
                    cur.Title = row["title"].ToString();
                    cur.PublicationYear = (int)row["year"];

                    publications.Add(cur);
                }
                return publications.ToArray();
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
                var publicationAdapter = new MySqlDataAdapter("select * from publications where doi = " + p.DOI, conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    p.DOI = row["doi"].ToString();
                    p.Title = row["title"].ToString();
                    p.Authors = row["authors"].ToString();
                    p.ranking = (Ranking)row["ranking"];
                    p.type = (OutPutType)row["type"];
                    p.CiteAs = row["cite_as"].ToString();
                    p.Available = (DateTime)row["available"];
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
                var publicationAdapter = new MySqlDataAdapter("select year from publications where year >= " + from + "and year <= " + to, conn);
                publicationAdapter.Fill(publicationDataSet, "publication");

                foreach (DataRow row in publicationDataSet.Tables["publication"].Rows)
                {
                    counts[(int)row["year"] - from] += 1;
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

        public ERDAdapter()
        {
            GetConnection();
        }
    }
}

