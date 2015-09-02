using System.Data.Entity;

namespace EasyCalendar.DAL.Context
{
    internal class DatabaseInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
    }
}