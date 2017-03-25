namespace PhotoArtSystem.Services.Web
{
    using System;
    using Contracts;

    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime Now
        {
            get
            {
                return DateTime.UtcNow;
            }
        }
    }
}
