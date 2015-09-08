using System.Media;
using System.Threading;

namespace EasyCalendar.Notifications
{
    public static class AlarmCenter
    {
        private static SoundPlayer player;

        public static void PlayAlarm(int numberOfReplays = 5)
        {
            player = player ?? new SoundPlayer
            {
                Stream = global::EasyCalendar.Properties.Resources.alarm
            };

            // Run the sound player in the background
            new Thread(() =>
            {
                for (int i = 0; i < numberOfReplays; i++)
                {
                    player.PlaySync();
                }

            }).Start();
        }

        public static void InterrupAlarm()
        {
            player.Stop();
        }
    }
}
