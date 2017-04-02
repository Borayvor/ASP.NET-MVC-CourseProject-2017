namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        // File Mime types
        public const string ImageJpeg = "image/jpeg";
        public const string ImagePng = "image/png";

        // Image Size
        public const int ImageAvatarWidth = 100;
        public const int ImageWidth = 960;
        public const int ImageCoverWidth = 960;
        public const int ImageAvatarHeight = 100;
        public const int ImageHeight = 640;
        public const int ImageCoverHeight = 360;

        // TODO: Set Cache Duration !!!
        // Cache duration
        public const uint PhotoArtServicesPartialCacheDuration = 0; //// * 5 * 24; // sec * min * hours
        public const uint PhotocoursePartialCacheDuration = 0; //// * 5 * 24; // sec * min * hours
        public const uint PhotocoursesAllPartialCacheDuration = 0; //// * 5 * 24; // sec * min * hours
        public const uint CarouselDataPartialCacheDuration = 0; //// * 5 * 24; // sec * min * hours
        public const uint InformationAllPartialCacheDuration = 0; //// * 5 * 24; // sec * min * hours

        // Cache item names
        public const string PhotoArtServicesCacheName = "PhotoArtServices";
        public const string PhotocoursesAllCacheName = "PhotocoursesAll";
        public const string PhotocourseCacheName = "Photocourse_";
        public const string CarouselDataCacheName = "CarouselData";
        public const string InformationAllCacheName = "InformationAll";

        // Validation messages
        public const string EmailNotValidValidationMessages = "The Email field is not a valid e-mail address.";

        // Common Exception messages
        public const string DbContextRequiredExceptionMessage = "An instance of DbContext is required !";
        public const string EfDbContextRequiredExceptionMessage = "An instance of EfDbContext is required !";
        public const string AutoMapperServiceRequiredExceptionMessage = "An instance of AutoMapperService is required !";
        public const string MapperRequiredExceptionMessage = "An instance of Mapper is required !";
        public const string SourceObjectRequiredExceptionMessage = "An instance of Source object is required !";

        // HttpCacheService Exception messages
        public const string ItemNameRequiredExceptionMessage = "Item name is required !";
        public const string DurationInSecondsMustExceptionMessage = "Duration in seconds must be positive integer !";

        // ApplicationUserProfileService Exception messages
        public const string EfDbRepositoryApplicationUserRequiredExceptionMessage = "An instance of EfDbRepository of ApplicationUser is required !";
        public const string ApplicationUserTransitionalRequiredExceptionMessage = "An instance of ApplicationUserTransitional is required !";

        // PhotocourseService Exception messages
        public const string EfDbRepositoryPhotocourseRequiredExceptionMessage = "An instance of EfDbRepository of Photocourse is required !";
        public const string PhotocourseTransitionalRequiredExceptionMessage = "An instance of PhotocourseTransitional is required !";

        // StudentService Exception messages
        public const string EfDbRepositoryStudentRequiredExceptionMessage = "An instance of EfDbRepository of Student is required !";
        public const string StudentTransitionalRequiredExceptionMessage = "An instance of StudentTransitional is required !";

        // InformationService Exception messages
        public const string EfDbRepositoryInformationRequiredExceptionMessage = "An instance of EfDbRepository of Information is required !";
        public const string InformationTransitionalRequiredExceptionMessage = "An instance of InformationTransitional is required !";

        // ImageService Exception messages
        public const string EfDbRepositoryImageRequiredExceptionMessage = "An instance of EfDbRepository of Image is required !";
        public const string ImageTransitionalRequiredExceptionMessage = "An instance of ImageTransitional is required !";
        public const string UploadImageServiceRequiredExceptionMessage = "An instance of UploadImageService is required !";

        // UploadImageService Exception messages
        public const string CloudStorageRequiredExceptionMessage = "An instance of CloudStorage is required !";
        public const string FileStreamRequiredExceptionMessage = "File stream is required !";
        public const string FilenameRequiredExceptionMessage = "File name is required !";
        public const string MimeTypeRequiredExceptionMessage = "Mime type is required !";
    }
}
