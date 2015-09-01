using System.Data.SQLite;

namespace EasyCalendar.DAL
{
    public  class Database
    {
        public static readonly string DatabaseName = "Events.db";
        public static readonly string ConnectionString = $"Data Source={DatabaseName};Version=3;";

        public static void CreateDb()
        {
            SQLiteConnection.CreateFile(DatabaseName);

            var dbConnection = new SQLiteConnection(ConnectionString);
            dbConnection.Open();

            string sql = "create table highscores (name varchar(20), score int)";

            SQLiteCommand command = new SQLiteCommand(sql, dbConnection);
            command.ExecuteNonQuery();

            dbConnection.Close();
        }
    }
}
