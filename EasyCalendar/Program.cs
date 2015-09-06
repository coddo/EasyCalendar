using EasyCalendar.DAL;
using System;
using System.Windows.Forms;

namespace EasyCalendar
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Clean up and reschedule necessary events at program startup
            using (var db = new UnitOfWork())
            {
                db.EventsRepository.RescheduleRecursiveEvents();
            }

            // Start the app
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new App.CalendarForm());
        }
    }
}
