namespace PhotoArtSystem.CloudStorages.CloudinaryApi
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Threading.Tasks;
    using CloudinaryDotNet;
    using CloudinaryDotNet.Actions;
    using Common.Validators;
    using Contracts;

    public class CloudinaryCloudStorage : ICloudStorage, IImageCloudStorage
    {
        private const string Name = "";
        private const string Key = "";
        private const string Secret = "";
        private const uint DefaultWidth = 0;
        private const uint DefaultHeight = 0;

        private readonly Cloudinary cloud;
        private readonly Account account;

        public CloudinaryCloudStorage()
        {
            this.account = new Account(Name, Key, Secret);
            this.cloud = new Cloudinary(this.account);
        }

        public async Task<string> UploadFile(Stream stream, string filename, string filetype, uint width, uint height, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            var name = filename + "_" + Guid.NewGuid().ToString();

            var imageUploadParams = new ImageUploadParams
            {
                File = new FileDescription(name, stream),
                Transformation = new Transformation()
                                            .Width(width)
                                            .Height(height)
                                            .Crop("fit")
                                            .FetchFormat("jpg"),
                PublicId = name
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

        public async Task<string> UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            return await this.UploadFile(stream, filename, filetype, DefaultWidth, DefaultHeight, path);
        }

        public async Task<string> UploadFile(byte[] bytes, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateByteArray(bytes);

            return await this.UploadFile(new MemoryStream(bytes), filename, filetype, path);
        }

        public async Task<string> UploadFile(string base64, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateBase64(base64);

            return await this.UploadFile(Convert.FromBase64String(base64), filename, filetype, path);
        }

        public async Task<bool> DeleteFile(string filename)
        {
            var delParams = new DelResParams()
            {
                PublicIds = new List<string>() { filename },
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

            return delResult != null && (delResult.StatusCode == HttpStatusCode.Created);
        }
    }
}
