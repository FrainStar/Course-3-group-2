using Microsoft.Data.Sqlite;

namespace ProjectAdo
{
    public class ContactManager
    {
        private readonly string _connectionString;

        public ContactManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void CreateTable()
        {
            using (SqliteConnection cnn = new SqliteConnection(_connectionString))
            {
                cnn.Open();

                string createTableQuery =
                    "CREATE TABLE IF NOT EXISTS Contacts (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT NOT NULL, PhoneNumber TEXT NOT NULL)";
                using (SqliteCommand cmd = new SqliteCommand(createTableQuery, cnn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddContact(string name, string phoneNumber)
        {
            using (SqliteConnection cnn = new SqliteConnection(_connectionString))
            {
                cnn.Open();

                string iQuery = "INSERT INTO Contacts (Name, PhoneNumber) VALUES (@Name, @PhoneNumber)";

                using (SqliteCommand cmd = new SqliteCommand(iQuery, cnn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteContact(string name)
        {
            using (SqliteConnection cnn = new SqliteConnection(_connectionString))
            {
                cnn.Open();
                string deleteQuery = "DELETE FROM Contacts WHERE Name LIKE @Name";
                using (SqliteCommand cmd = new SqliteCommand(deleteQuery, cnn))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void SearchContacts(string searchString)
        {
            using (SqliteConnection cnn = new SqliteConnection(_connectionString))
            {
                cnn.Open();

                string searchQuery = "SELECT * FROM Contacts WHERE Name LIKE @Name";
                using (SqliteCommand cmd = new SqliteCommand(searchQuery, cnn))
                {
                    cmd.Parameters.AddWithValue("@Name", searchString);

                    using (SqliteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine(
                                $"ID: {reader["ID"]}, Name: {reader["Name"]}, PhoneNumber: {reader["PhoneNumber"]}");
                        }
                    }
                }
            }
        }
    }
}