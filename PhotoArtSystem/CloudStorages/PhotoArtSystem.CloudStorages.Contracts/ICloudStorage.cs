namespace PhotoArtSystem.CloudStorages.Contracts
{
    using System.IO;
    using System.Threading.Tasks;

    public interface ICloudStorage
    {
        /// <summary>
        /// Uploads a file as a base 64 string with givven name and returns its download url.
        /// </summary>
        /// <param name="base64">The file as a base 64 string to be uploaded.</param>
        /// <param name="filename">The filename that will be saved.</param>
        /// <param name="filetype">The type of the file that will be saved.</param>
        /// <param name="path">Optional path for the location on the cloud storage.</param>
        /// <returns>The uploaded file url.</returns>
        Task<string> UploadFile(string base64, string filename, string filetype, string path = "/");

        /// <summary>
        /// Uploads a file as a byte array with givven name and returns its download url.
        /// </summary>
        /// <param name="bytes">The file as a byte array to be uploaded.</param>
        /// <param name="filename">The filename that will be saved.</param>
        /// <param name="filetype">The type of the file that will be saved.</param>
        /// <param name="path">Optional path for the location on the cloud storage.</param>
        /// <returns>The uploaded file url.</returns>
        Task<string> UploadFile(byte[] bytes, string filename, string filetype, string path = "/");

        /// <summary>
        /// Uploads a file as a stream with givven name and returns its download url.
        /// </summary>
        /// <param name="stream">The file stream to be uploaded.</param>
        /// <param name="filename">The filename that will be saved.</param>
        /// <param name="filetype">The type of the file that will be saved.</param>
        /// <param name="path">Optional path for the location on the cloud storage.</param>
        /// <returns>The uploaded file url.</returns>
        Task<string> UploadFile(Stream stream, string filename, string filetype, string path = "/");

        /// <summary>
        /// Deletes a file by its name.
        /// </summary>
        /// <param name="filename">The name of the file to be deleted.</param>
        /// <returns>If the operation has succeeded.</returns>
        Task<bool> DeleteFile(string filename);
    }
}
