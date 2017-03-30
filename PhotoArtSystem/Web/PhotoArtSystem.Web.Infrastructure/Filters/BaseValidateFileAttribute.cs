namespace PhotoArtSystem.Web.Infrastructure.Filters
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web;

    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class BaseValidateFileAttribute : ValidationAttribute
    {
        private const int MbSizeAsBytes = 1024 * 1024;

        protected void ValidateOrThrowException(object value, int allowedMaxSize, IList<string> allowedMimeTypes)
        {
            ICollection<HttpPostedFileBase> files = value as ICollection<HttpPostedFileBase>;

            if (files == null)
            {
                throw new ValidationException("Please upload a file !");
            }

            if (files.Count < 3)
            {
                throw new ValidationException("Please upload at least 3 files !");
            }

            foreach (HttpPostedFileBase file in files)
            {
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
}
