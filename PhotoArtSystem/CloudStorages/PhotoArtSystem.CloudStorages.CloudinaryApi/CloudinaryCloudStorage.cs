namespace PhotoArtSystem.CloudStorages.CloudinaryApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using Bytes2you.Validation;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Constants;
    using Common.Providers.Contracts;
    using Contracts;

    public class CloudinaryCloudStorage : IImageCloudStorage
    {
        private const int DefaultWidth = 100;
        private const int DefaultHeight = 100;
        private const string DefaultCropMode = "fill";
        private const string DefaultOutputFormat = "jpg";

        private readonly Cloudinary cloud;
        private readonly Account account;

        public CloudinaryCloudStorage(ICloudStorageConfigurationProvider config)
        {
            this.account = new Account(
                config.ImageUploadName,
                config.ImageUploadApiKey,
                config.ImageUploadApiSecret);
            this.cloud = new Cloudinary(this.account);
        }

        public async Task<string> UploadFile(
            Stream stream,
            string fileName,
            string fileType,
            int width,
            int height,
            string cropMode,
            string outputFormat)
        {
            Guard.WhenArgument(
                stream,
                GlobalConstants.StreamRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                fileName,
                GlobalConstants.FileNameRequiredExceptionMessage).IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(
                fileType,
                GlobalConstants.FileTypeRequiredExceptionMessage).IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(
                width,
                GlobalConstants.ImageWidthRequiredExceptionMessage).IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(
                height,
                GlobalConstants.ImageHeightRequiredExceptionMessage).IsLessThanOrEqual(0).Throw();

            if (!stream.CanRead)
            {
                throw new ArgumentException(GlobalConstants.StreamRequiredExceptionMessage);
            }

            if (width == 0)
            {
                width = DefaultWidth;
            }

            if (height == 0)
            {
                height = DefaultHeight;
            }

            if (string.IsNullOrWhiteSpace(cropMode))
            {
                cropMode = DefaultCropMode;
            }

            if (string.IsNullOrWhiteSpace(outputFormat))
            {
                outputFormat = DefaultOutputFormat;
            }

            var imageUploadParams = new ImageUploadParams
            {
                File = new FileDescription(fileName, stream),
                Transformation = new Transformation()
                                            .Width(width)
                                            .Height(height)
                                            .Crop(cropMode)
                                            .FetchFormat(outputFormat),
                PublicId = fileName
            };

            ImageUploadResult result = null;

            try
            {
                result = await this.cloud.UploadAsync(imageUploadParams);
            }
            catch (Exception)
            {
                // Log stuff
            }

            return result?.Uri?.AbsoluteUri;
        }

        public async Task<bool> DeleteFile(string fileName)
        {
            Guard.WhenArgument(
                fileName,
                GlobalConstants.FileNameRequiredExceptionMessage).IsNullOrWhiteSpace().Throw();

            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { fileName },
                Invalidate = true
            };

            DelResResult delResult = null;

            try
            {
                delResult = await this.cloud.DeleteResourcesAsync(delParams);
            }
            catch (Exception)
            {
                // Log stuff
            }

            return delResult.StatusCode == HttpStatusCode.OK;
        }
    }
}
