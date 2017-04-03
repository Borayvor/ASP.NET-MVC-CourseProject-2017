namespace PhotoArtSystem.CloudStorages.Contracts
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IImageCloudStorage
    {
        /// <summary>
        /// Uploads a file as a stream with givven name and returns its download url.
        /// </summary>
        /// <param name="stream">The file stream to be uploaded.</param>
        /// <param name="fileName">The filename that will be saved.</param>
        /// <param name="fileType">The type of the file that will be saved.</param>
        /// <param name="width">The width of the image that will be saved.</param>
        /// <param name="height">The height of the image that will be saved.</param>
        /// <param name="cropMode">Mode to adapt the image to fit into the requested size.</param>
        /// <param name="outputFormat">Output format conversion of the image.</param>
        /// <returns>The uploaded file url.</returns>
        Task<string> UploadFile(Stream stream, string fileName, string fileType, int width, int height, string cropMode, string outputFormat);

        /// <summary>
        /// Deletes a file by its name.
        /// </summary>
        /// <param name="fileName">The name of the file to be deleted.</param>
        /// <returns>If the operation has succeeded.</returns>
        Task<bool> DeleteFile(string fileName);
    }
}
