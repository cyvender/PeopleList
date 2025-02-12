using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleList.Data
{
    public class PeopleDBManager
    {

        private string _connectionString;

        public PeopleDBManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Person> GetPeople()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"SELECT * FROM Person";
            connection.Open();

            var people = new List<Person>();

            SqlDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                people.Add(
                new Person
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"]
                });
            }

            return people;
        }

        public void AddPerson(Person person)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = @"INSERT INTO Person 
                                VALUES (@FirstName, @LastName, @Age)";
            cmd.Parameters.AddWithValue("@FirstName", person.FirstName);
            cmd.Parameters.AddWithValue("@LastName", person.LastName);
            cmd.Parameters.AddWithValue("@Age", person.Age);
            connection.Open();

            cmd.ExecuteNonQuery();
        }

        public void AddPeople(List<Person> people)
        {
           foreach(Person p in people)
            {
                AddPerson(p);
            }
        }
    }
}
