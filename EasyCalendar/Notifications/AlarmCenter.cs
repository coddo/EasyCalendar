using System.Media;
using System.Threading;

namespace EasyCalendar.Notifications
{
    public static class AlarmCenter
    {
        public static void PlayAlarm(int numberOfReplays = 5)
        {
            // Run the sound player in the background
            new Thread(() =>
            {
                SoundPlayer player = new SoundPlayer
                {
                    Stream = global::EasyCalendar.Properties.Resources.alarm
                };

                for (int i = 0; i < numberOfReplays; i++)
                {
                    player.PlaySync();
                }

            }).Start();
        }
    }
}
