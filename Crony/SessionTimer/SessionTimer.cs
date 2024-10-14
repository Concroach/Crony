using System;

namespace Crony
{
    public static class SessionTimer
    {
        private static DateTime _sessionStartTime = DateTime.Now;

        public static string GetCurrentSessionTime()
        {
            var sessionDuration = DateTime.Now - _sessionStartTime;
            return sessionDuration.ToString(@"hh\:mm\:ss");
        }
    }
}