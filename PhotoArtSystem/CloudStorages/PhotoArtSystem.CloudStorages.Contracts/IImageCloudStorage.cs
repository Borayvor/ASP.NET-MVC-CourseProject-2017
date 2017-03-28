namespace PhotoArtSystem.CloudStorages.Contracts
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IImageCloudStorage : ICloudStorage
    {
        /// <summary>
        /// Uploads a file as a stream with givven name and returns its download url.
        /// </summary>
        /// <param name="stream">The file stream to be uploaded.</param>
        /// <param name="filename">The filename that will be saved.</param>
        /// <param name="filetype">The type of the file that will be saved.</param>
        /// <param name="width">The width of the image that will be saved.</param>
        /// <param name="height">The height of the image that will be saved.</param>
        /// <param name="path">Optional path for the location on the cloud storage.</param>
        /// <returns>The uploaded file url.</returns>
        Task<string> UploadFile(Stream stream, string filename, string filetype, uint width, uint height, string path = "/");
    }
}
