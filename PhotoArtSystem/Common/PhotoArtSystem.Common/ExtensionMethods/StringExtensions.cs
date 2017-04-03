namespace EntertainmentSystem.Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string GetFileName(this string fileFullname)
        {
            if (string.IsNullOrWhiteSpace(fileFullname))
            {
                return string.Empty;
            }

            var extensionIndex = fileFullname.LastIndexOf(".");

            if (extensionIndex == 0)
            {
                return string.Empty;
            }

            if (extensionIndex > 0)
            {
                return fileFullname.Remove(extensionIndex);
            }

            return fileFullname;
        }

        public static string GetFileExtension(this string fileFullname)
        {
            if (string.IsNullOrWhiteSpace(fileFullname))
            {
                return string.Empty;
            }

            var extensionIndex = fileFullname.LastIndexOf(".");

            if (extensionIndex < 0 || extensionIndex == fileFullname.Length - 1)
            {
                return string.Empty;
            }

            var extension = fileFullname.Substring(extensionIndex);

            return extension;
        }

        public static string GetFileContentType(this string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
            {
                return string.Empty;
            }

            var extensionIndex = filename.LastIndexOf(".");

            if (extensionIndex < 0 || extensionIndex == filename.Length - 1)
            {
                return string.Empty;
            }

            var extension = filename.Substring(extensionIndex + 1);

            switch (extension)
            {
                case "jpg": return "image/jpeg";
                case "jpeg": return "image/jpeg";
                case "png": return "image/png";
                case "gif": return "image/gif";
                case "webm": return "video/webm";
                case "mp4": return "video/mp4";
                case "wav": return "audio/wav";
                case "mp3": return "audio/mp3";
                case "mpeg": return "audio/mpeg";
                default: return string.Empty;
            }
        }

        public static string GetFileExtensionFromContentType(this string contentType)
        {
            if (string.IsNullOrEmpty(contentType))
            {
                return string.Empty;
            }

            switch (contentType)
            {
                case "image/jpeg": return ".jpg";
                case "image/png": return ".png";
                case "image/gif": return ".gif";
                case "video/webm": return ".webm";
                case "video/mp4": return ".mp4";
                case "audio/wav": return ".wav";
                case "audio/mp3": return ".mp3";
                case "audio/mpeg": return ".mpeg";
                default: return string.Empty;
            }
        }
    }
}
