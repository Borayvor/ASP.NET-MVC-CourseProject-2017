namespace PhotoArtSystem.Common.Providers
{
    using System;
    using System.Configuration;
    using Contracts;

    public class CloudStorageConfigurationProvider : ICloudStorageConfigurationProvider
    {
        public string ImageUploadName
        {
            get
            {
                return GetConfigValue("ImageUploadName");
            }
        }

        public string ImageUploadApiKey
        {
            get
            {
                return GetConfigValue("ImageUploadApiKey");
            }
        }

        public string ImageUploadApiSecret
        {
            get
            {
                return GetConfigValue("ImageUploadApiSecret");
            }
        }

        private static string GetConfigValue(string settingName)
        {
            var value = ConfigurationManager.AppSettings[settingName];

            if (value == null)
            {
                throw new ArgumentException(string.Format("Missing configuration option: {0}", settingName));
            }

            return value;
        }
    }
}
