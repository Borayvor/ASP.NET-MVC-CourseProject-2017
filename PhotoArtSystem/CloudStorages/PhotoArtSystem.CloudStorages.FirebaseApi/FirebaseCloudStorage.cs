namespace PhotoArtSystem.CloudStorages.FirebaseApi
{
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Common.Validators;
    using Contracts;

    public class FirebaseCloudStorage : ICloudStorage
    {
        ////private const string ApiKey = "AIzaSyDtgXR3Tmmnn1g6eFRXzVCFceiAxeR_uWI";
        ////private const string Bucket = "photoartsystem.appspot.com";
        ////private const string AuthEmail = "testuser@testuser.com";
        ////private const string AuthPassword = "testuser!@#";

        ////private readonly FirebaseAuthProvider auth;
        ////private readonly FirebaseStorage client;

        ////public FirebaseCloudStorage()
        ////{
        ////    this.auth = new FirebaseAuthProvider(new FirebaseConfig(ApiKey));
        ////}

        public Task<string> UploadFile(Stream stream, string filename, string filetype, string path = "/")
        {
            UploadFileValidator.ValidateStream(stream);
            UploadFileValidator.ValidateFileName(filename);
            UploadFileValidator.ValidateFileType(filetype);

            // TODO: Implement UploadFile
            throw new NotImplementedException();
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

        public Task<bool> DeleteFile(string filename)
        {
            ////var meta = this.client.Delete(filename);

            ////return meta.Is_Deleted;

            throw new NotImplementedException();
        }

        ////private async Task RunFireBase(Stream stream, string filename, string filetype, string path = "/")
        ////{
        ////    var authTask = await this.auth.SignInWithEmailAndPasswordAsync(AuthEmail, AuthPassword);

        ////    // you can use CancellationTokenSource to cancel the upload midway
        ////    var cancellation = new CancellationTokenSource();

        ////    // when you cancel the upload, exception is thrown. By default no exception is thrown
        ////    var client = new FirebaseStorage(
        ////        Bucket,
        ////        new FirebaseStorageOptions { AuthTokenAsyncFactory = () => Task.FromResult(authTask.FirebaseToken), ThrowOnCancel = true });

        ////    var taskInOut = client
        ////        .Child("fileNameDir")
        ////        .Child("fileSizeDir")
        ////        .Child("file.png")
        ////        .PutAsync(stream, cancellation.Token);

        ////    // Track progress of the upload
        ////    taskInOut.Progress.ProgressChanged += (s, e) => Console.WriteLine($"Progress: {e.Percentage} %");

        ////    // cancel the upload
        ////    cancellation.Cancel();

        ////    // Await the task to wait until upload is completed and get the download url
        ////    var downloadUrl = await taskInOut;
        ////}
    }
}
