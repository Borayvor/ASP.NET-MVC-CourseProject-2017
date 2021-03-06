﻿namespace PhotoArtSystem.Services.Web
{
    using System;
    using System.Web;
    using System.Web.Caching;
    using Bytes2you.Validation;
    using Common.Constants;
    using Common.DateTime;
    using Contracts;

    public class HttpCacheService : ICacheService
    {
        private static readonly object LockObject = new object();

        public T Get<T>(string itemName, Func<T> getDataFunc, uint durationInSeconds)
            where T : class
        {
            Guard.WhenArgument(
                itemName,
                GlobalConstants.ItemNameRequiredExceptionMessage).IsNull().Throw();

            if (HttpRuntime.Cache[itemName] == null)
            {
                lock (LockObject)
                {
                    if (HttpRuntime.Cache[itemName] == null)
                    {
                        var data = getDataFunc();
                        HttpRuntime.Cache.Insert(
                            itemName,
                            data,
                            null,
                            ServerDateTime.Now().AddSeconds(durationInSeconds),
                            Cache.NoSlidingExpiration);
                    }
                }
            }

            return (T)HttpRuntime.Cache[itemName];
        }

        public void Remove(string itemName)
        {
            Guard.WhenArgument(
                itemName,
                GlobalConstants.ItemNameRequiredExceptionMessage).IsNull().Throw();

            HttpRuntime.Cache.Remove(itemName);
        }
    }
}
