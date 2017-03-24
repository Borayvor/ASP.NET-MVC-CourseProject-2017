namespace PhotoArtSystem.Services.Web.Contracts
{
    using System;

    public interface IDateTimeProvider
    {
        DateTime Now { get; }
    }
}
