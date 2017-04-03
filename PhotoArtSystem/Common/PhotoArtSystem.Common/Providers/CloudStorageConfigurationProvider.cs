namespace PhotoArtSystem.Common.Providers
{
    using System;
    using System.Configuration;
    using Contracts;

    public class CloudStorageConfigurationProvider : ICloudStorageConfigurationProvider
    {
        public string ImageUploadName => GetConfigValue(nameof(this.ImageUploadName));

        public string ImageUploadApiKey => GetConfigValue(nameof(this.ImageUploadApiKey));

        public string ImageUploadApiSecret => GetConfigValue(nameof(this.ImageUploadApiSecret));

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
