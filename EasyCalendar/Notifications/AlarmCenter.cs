using System.Media;
using System.Threading;

namespace EasyCalendar.Notifications
{
    public static class AlarmCenter
    {
        private static bool continueRinging = false;
        private static readonly SoundPlayer player = new SoundPlayer(global::EasyCalendar.Properties.Resources.alarm);

        public static void PlayAlarm(int numberOfReplays = 5)
        {
            continueRinging = true;

            // Run the sound player in the background
            new Thread(() =>
            {
                for (int i = 0; i < numberOfReplays && continueRinging; i++)
                {
                    player.Play();
                    Thread.Sleep(1700);
                }

            }).Start();
        }

        public static void InterrupAlarm()
        {
            continueRinging = false;
            player?.Stop();
        }
    }
}
