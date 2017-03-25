namespace PhotoArtSystem.Common.DateTime
{
    using System;

    public class ServerDateTime
    {
        public static DateTime Now()
        {
            return DateTime.UtcNow;
        }
    }
}
