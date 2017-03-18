namespace PhotoArtSystem.CloudStorages.FirebaseApi
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;
    using Common.Validators;
    using Contracts;
    using Firebase.Auth;
    using Firebase.Storage;

    public class FirebaseCloudStorage :
        ICloudStorage, IImageCloudStorage, IVideoCloudStorage
    {
        private const string ApiKey = "AIzaSyDtgXR3Tmmnn1g6eFRXzVCFceiAxeR_uWI";
        private const string Bucket = "photoartsystem.appspot.com";
        private const string AuthEmail = "testuser@testuser.com";
        private const string AuthPassword = "testuser!@#";

        public string UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            ////this.RunFireBase(stream, filename, filetype, path);

            // TODO: Implement UploadFile
            return "";
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

        private async Task RunFireBase(Stream stream, string filename, string filetype, string path = "/")
        {
            var auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
            var authTask = await auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

            // you can use CancellationTokenSource to cancel the upload midway
            var cancellation = new CancellationTokenSource();

            var client = new FirebaseStorage(
                Bucket,
                new FirebaseStorageOptions
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(authTask.FirebaseToken),
                    ThrowOnCancel = true // when you cancel the upload, exception is thrown. By default no exception is thrown
                });

            var taskInOut = client
                .Child("data")
                .Child("random")
                .Child("file.png")
                .PutAsync(stream, cancellation.Token);

            // Track progress of the upload
            taskInOut.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

            // cancel the upload
            cancellation.Cancel();

            // Await the task to wait until upload is completed and get the download url
            var downloadUrl = await taskInOut;
        }
    }
}
