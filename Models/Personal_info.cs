using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace TP3_Habib_Sellami.Models;

public class Personal_info
{
    private static string dbSource = "Data Source=database1.db;";
   public List<Person> GetAllPerson()
    {
        List<Person> list = new List<Person>();
        SqliteConnection dbCon = new SqliteConnection("Data Source=database1.db;");
        dbCon.Open();

        using (dbCon)
        {
            SqliteCommand cmd = new SqliteCommand("SELECT * FROM personal_info", dbCon);
            SqliteDataReader reader = cmd.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    long id = (long)reader["id"];
                    string first_name = (string)reader["first_name"];
                    string last_name = (string)reader["last_name"];
                    string email = (string)reader["email"];
                    //   DateTime date_birth = Convert.ToDateTime((string)reader["date_birth"].ToString());
                    string image = (string)reader["image"];
                    string country = (string)reader["country"];
                    list.Add(new Person(id, first_name, last_name, email, image, country));
                }
            }
        }

        return list;
    }

    public Person GetPerson(int idQuery)
    {
        SQLiteConnection sqlite_conn;
        // Create a new database connection:
        sqlite_conn = new SQLiteConnection(dbSource);
        // Open the connection:
        try
        {
            sqlite_conn.Open();
        }
        catch (Exception ex)
        {
        }

        SQLiteCommand sqlite_cmd_get_id;
        sqlite_cmd_get_id = sqlite_conn.CreateCommand();
        sqlite_cmd_get_id.CommandText = "SELECT * FROM personal_info WHERE id = TRIM(@id)";
        sqlite_cmd_get_id.Parameters.AddWithValue("id", idQuery);

        sqlite_cmd_get_id.ExecuteNonQuery();
        SQLiteDataReader resultUsers = sqlite_cmd_get_id.ExecuteReader();

        Person ResultPerson = null;

        using (resultUsers)
        {
            while (resultUsers.Read())
            {
                int id = (int)resultUsers["id"];
                string first_name = (string)resultUsers["first_name"];
                string last_name = (string)resultUsers["last_name"];
                string email = (string)resultUsers["email"];
                //DateTime date_birth = DateTime.ParseExact((String)results["date_birth"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string image = (string)resultUsers["image"];
                string country = (string)resultUsers["country"];
                ResultPerson = new Person(id, first_name, last_name, email, image, country);
            }
        }

        sqlite_conn.Close();

        return ResultPerson;
    }

    public Person GetPersonBySearch(string firstName, string countrySearch)
    {
        SQLiteConnection sqlite_conn;
        sqlite_conn = new SQLiteConnection(dbSource);

        try
        {
            sqlite_conn.Open();
        }
        catch (Exception err)
        {
        }

        SQLiteCommand sqlite_query;
        sqlite_query = sqlite_conn.CreateCommand();
        sqlite_query.CommandText =
            "SELECT * FROM personal_info WHERE TRIM(UPPER(first_name)) = TRIM(UPPER(@firstName)) AND TRIM(UPPER(country)) = TRIM(UPPER(@country))";
        sqlite_query.Parameters.AddWithValue("firstName", firstName);
        sqlite_query.Parameters.AddWithValue("country", countrySearch);

        sqlite_query.ExecuteNonQuery();
        SQLiteDataReader resultUser = sqlite_query.ExecuteReader();

        Person resultPerson = null;
        using (resultUser)
        {
            while (resultUser.Read())
            {
                int id = (int)resultUser["id"];
                string first_name = (string)resultUser["first_name"];
                string last_name = (string)resultUser["last_name"];
                string email = (string)resultUser["email"];
                //DateTime date_birth = DateTime.ParseExact((String)results["date_birth"], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string image = (string)resultUser["image"];
                string country = (string)resultUser["country"];
                resultPerson = new Person(id, first_name, last_name, email, image, country);
            }
        }

        sqlite_conn.Close();

        return resultPerson;
    }
}
