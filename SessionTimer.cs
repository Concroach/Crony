using System;

namespace Crony
{
    public static class SessionTimer
    {
        private static DateTime sessionStartTime = DateTime.Now;

        public static string GetCurrentSessionTime()
        {
            var sessionDuration = DateTime.Now - sessionStartTime;
            return sessionDuration.ToString(@"hh\:mm\:ss");
        }
    }
}