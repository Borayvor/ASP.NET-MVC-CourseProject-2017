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
    using Contracts;

    public class CloudinaryCloudStorage : IImageCloudStorage
    {
        private const string Name = "";
        private const string Key = "";
        private const string Secret = "";
        private const int DefaultWidth = 100;
        private const int DefaultHeight = 100;
        private const string DefaultCropMode = "fill";
        private const string DefaultOutputFormat = "jpg";

        private readonly Cloudinary cloud;
        private readonly Account account;

        public CloudinaryCloudStorage()
        {
            this.account = new Account(Name, Key, Secret);
            this.cloud = new Cloudinary(this.account);
        }

        public async Task<string> UploadFile(
            Stream stream,
            string fileName,
            string fileType,
            int width = DefaultWidth,
            int height = DefaultHeight,
            string cropMode = DefaultCropMode,
            string outputFormat = DefaultOutputFormat)
        {
            Guard.WhenArgument(stream, nameof(stream)).IsNull().Throw();
            Guard.WhenArgument(fileName, nameof(fileName)).IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(fileType, nameof(fileType)).IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(width, nameof(width)).IsLessThanOrEqual(0).Throw();
            Guard.WhenArgument(height, nameof(height)).IsLessThanOrEqual(0).Throw();

            if (!stream.CanRead)
            {
                throw new ArgumentException(nameof(stream));
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
            Guard.WhenArgument(fileName, nameof(fileName)).IsNullOrWhiteSpace().Throw();

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
