namespace PhotoArtSystem.Common.Providers.Contracts
{
    public interface ICloudStorageConfigurationProvider
    {
        string ImageUploadName { get; }

        string ImageUploadApiKey { get; }

        string ImageUploadApiSecret { get; }
    }
}
