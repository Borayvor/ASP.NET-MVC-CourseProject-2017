namespace PhotoArtSystem.Services.Web.Contracts
{
    using System;

    public interface ICacheService
    {
        T Get<T>(string itemName, Func<T> getDataFunc, uint durationInSeconds)
            where T : class;

        void Remove(string itemName);
    }
}
