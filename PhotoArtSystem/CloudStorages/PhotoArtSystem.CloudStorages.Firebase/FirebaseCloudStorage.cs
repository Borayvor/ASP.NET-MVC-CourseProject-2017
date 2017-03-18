namespace PhotoArtSystem.CloudStorages.Firebase
{
    using System;
    using System.IO;
    using Common.Validators;
    using Contracts;
    using global::Firebase.Auth;
    using global::Firebase.Storage;

    public class FirebaseCloudStorage :
        ICloudStorage, IImageCloudStorage, IVideoCloudStorage
    {
        private const string ApiKey = "AIzaSyDtgXR3Tmmnn1g6eFRXzVCFceiAxeR_uWI";
        private const string Bucket = "photoartsystem.appspot.com";
        private const string AuthEmail = "your@email.com";
        private const string AuthPassword = "yourpasword";

        private readonly FirebaseStorage client;
        private readonly FirebaseAuthProvider auth;

        public FirebaseCloudStorage()
        {
            // Construct FirebaseStorage with path to where you want to upload the file and put it there
            this.client = new FirebaseStorage(Bucket);
            this.auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        }

        public string UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            var task = this.client
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream);

            // Track progress of the upload
            task.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // Await the task to wait until upload is completed and get the download url
            ////var downloadUrl = await task;

            throw new NotImplementedException();
        }

        public string UploadFile(byte[] bytes, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateByteArray(bytes);

            return this.UploadFile(new MemoryStream(bytes), filename, filetype, path);
        }

        public string UploadFile(string base64, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateBase64(base64);

            return this.UploadFile(Convert.FromBase64String(base64), filename, filetype, path);
        }

        public bool DeleteFile(string filename)
        {
            ////var meta = this.client.Delete(filename);

            ////return meta.Is_Deleted;

            throw new NotImplementedException();
        }
    }
}
