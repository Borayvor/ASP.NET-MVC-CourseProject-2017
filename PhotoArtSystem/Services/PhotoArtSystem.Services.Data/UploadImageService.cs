namespace PhotoArtSystem.Services.Data
{
    using System.IO;
    using System.Threading.Tasks;
    using Bytes2you.Validation;
    using CloudStorages.Contracts;
    using Common.Constants;
    using Contracts;

    public class UploadImageService : IUploadImageService
    {
        private readonly IImageCloudStorage storage;

        public UploadImageService(IImageCloudStorage storage)
        {
            Guard.WhenArgument(
                storage,
                GlobalConstants.CloudStorageRequiredExceptionMessage).IsNull().Throw();

            this.storage = storage;
        }

        public async Task<string> Create(
            Stream fileStream,
            string filename,
            string mimeType,
            uint width,
            uint height)
        {
            Guard.WhenArgument(
               fileStream,
               GlobalConstants.FileStreamRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
               filename,
               GlobalConstants.FilenameRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
               mimeType,
               GlobalConstants.MimeTypeRequiredExceptionMessage).IsNull().Throw();

            var urlPath = await this.storage.UploadFile(fileStream, filename, mimeType, width, height);

            return urlPath;
        }
    }
}
