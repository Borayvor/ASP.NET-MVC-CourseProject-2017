namespace PhotoArtSystem.Services.Data.Contracts
{
    using System.IO;
    using System.Threading.Tasks;

    public interface IUploadImageService
    {
        Task<string> Create(
            Stream fileStream,
            string filename,
            string mimeType,
            uint width,
            uint height);
    }
}
