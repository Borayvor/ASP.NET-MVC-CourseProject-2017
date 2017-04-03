namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class BaseValidateFileAttribute : ValidationAttribute
    {
        private const int MbSizeAsBytes = 1024 * 1024; // 1 Mb

        protected void ValidateOrThrowException(object value, int allowedMaxSize, ICollection<string> allowedMimeTypes)
        {
            ICollection<HttpPostedFileBase> files = value as ICollection<HttpPostedFileBase>;
            HttpPostedFileBase singleFile = value as HttpPostedFileBase;

            // TODO: Extract constants
            if (files != null)
            {
                if (files.Count < 3)
                {
                    throw new ValidationException("Please upload at least 3 files !");
                }

                if (files.Count > 15)
                {
                    throw new ValidationException("Please upload at most 15 files !");
                }

                foreach (HttpPostedFileBase file in files)
                {
                    this.ValidateFile(file, allowedMaxSize, allowedMimeTypes);
                }

                return;
            }
            else if (singleFile != null)
            {
                this.ValidateFile(singleFile, allowedMaxSize, allowedMimeTypes);

                return;
            }

            throw new ValidationException("Please upload a file !");
        }

        private void ValidateFile(HttpPostedFileBase file, int allowedMaxSize, ICollection<string> allowedMimeTypes)
        {
            if (file == null)
            {
                throw new ValidationException("Please upload a file !");
            }

            if (file.ContentLength == 0)
            {
                throw new ValidationException("Please upload a non-empty file !");
            }

            if (file.ContentLength > allowedMaxSize)
            {
                throw new ValidationException(string.Format(
                    "File size can not exceed {0} mb !",
                    allowedMaxSize / MbSizeAsBytes));
            }

            if (!allowedMimeTypes.Contains(file.ContentType))
            {
                throw new ValidationException("File type not supported !");
            }
        }
    }
}
