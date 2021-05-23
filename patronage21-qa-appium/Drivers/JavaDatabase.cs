using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace patronage21_qa_appium.Drivers
{
    class JavaDatabase
    {
        private static readonly string _connectionString = "Host=localhost;Database=patronative;Username=admin;Password=p4tron4tiv3;Port=5101;Persist Security Info=True";

        public string GetProperty(string property, string table, string key, string value)
        {
            string output = "";

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM " + table + " where " + key + " = " + value + ";";
            using var cmd = new NpgsqlCommand(sql, connection);

            using NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                output = reader[property].ToString();
            }
            return output;
        }

        public Dictionary<string, string> GetProperties(List<string> properties, string table, string key, string value)
        {
            Dictionary<string, string> output = new();

            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();

            string sql = "SELECT * FROM " + table + " where " + key + " = " + value + ";";
            using var cmd = new NpgsqlCommand(sql, connection);

            using NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                foreach (string property in properties)
                {
                    output.Add(property, reader[property].ToString());
                }
            }
            return output;
        }
    }
}
