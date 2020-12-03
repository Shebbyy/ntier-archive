using Models;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace DataAccess
{
    public class SQLLessonRepository : ILessonRepository
    {
        private List<Lessons> LessonList;

        public SQLLessonRepository()
        {
            LessonList = new List<Lessons>();

            var DataPath = ConfigurationManager.AppSettings["SqlLessonRepoPath"];

            var MySQLConnection = new SqlConnection();
            MySQLConnection.ConnectionString = @$"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename='{DataPath}';Integrated Security=True;Connect Timeout=30";

            MySQLConnection.Open();

            var mySqlCommand = new SqlCommand();
            mySqlCommand.Connection = MySQLConnection;
            mySqlCommand.CommandText = "SELECT * FROM Customers";

            var myDataReader = mySqlCommand.ExecuteReader();

            while (myDataReader.Read())
            {
                var LessonName = myDataReader["CustomerID"].ToString();
                var Description = myDataReader["CompanyName"].ToString();
                var Teacher = myDataReader["ContactName"].ToString();

                LessonList.Add(new Lessons() { LessonName = LessonName, Description = Description, Teacher = Teacher });
            }

            MySQLConnection.Close();
        }


        public List<Lessons> Get()
        {
            return LessonList;
        }

        public List<Lessons> GetById(string LessonID)
        {
            throw new NotImplementedException();
        }
    }
}
