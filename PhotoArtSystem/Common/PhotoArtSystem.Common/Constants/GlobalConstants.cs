namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        // Validate YouTube
        public const string YouTubeRequiredExceptionMessage = "Only YouTube video is allowed !";

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
        public const uint PhotoArtServicesPartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const uint PhotocoursePartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const uint PhotocoursesAllPartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const uint CarouselDataPartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const uint InformationAllPartialCacheDuration = 60 * 60 * 24; // sec * min * hours
        public const uint MultimediaAllPartialCacheDuration = 60 * 60 * 24; // sec * min * hours

        // Cache item names
        public const string PhotoArtServicesCacheName = "PhotoArtServices";
        public const string PhotocoursesAllCacheName = "PhotocoursesAll";
        public const string PhotocourseCacheName = "Photocourse_";
        public const string CarouselDataCacheName = "CarouselData";
        public const string InformationAllCacheName = "InformationAll";
        public const string MultimediaAllCacheName = "MultimediaAll";

        // Validation messages
        public const string EmailNotValidValidationMessages = "The Email field is not a valid e-mail address.";

        // HtmlSanitizerAdapter
        public const string HtmlStringRequiredExceptionMessage = "Html string is required !";

        // Common Exception messages
        public const string DbContextRequiredExceptionMessage = "An instance of DbContext is required !";
        public const string EfDbContextRequiredExceptionMessage = "An instance of EfDbContext is required !";
        public const string AutoMapperServiceRequiredExceptionMessage = "An instance of AutoMapperService is required !";
        public const string MapperRequiredExceptionMessage = "An instance of Mapper is required !";
        public const string ModelDbFactoryRequiredExceptionMessage = "An instance of ModelDbFactory is required !";
        public const string SanitizerRequiredExceptionMessage = "An instance of Sanitizer is required !";
        public const string SourceObjectRequiredExceptionMessage = "An instance of Source object is required !";

        // CloudinaryCloudStorage Exception messages
        public const string StreamRequiredExceptionMessage = "Stream is required !";
        public const string FileNameRequiredExceptionMessage = "File name is required !";
        public const string FileTypeRequiredExceptionMessage = "File type is required !";
        public const string ImageWidthRequiredExceptionMessage = "Image width is required !";
        public const string ImageHeightRequiredExceptionMessage = "Image height is required !";

        // HttpCacheService Exception messages
        public const string ItemNameRequiredExceptionMessage = "Item name is required !";
        public const string DurationInSecondsMustExceptionMessage = "Duration in seconds must be positive integer !";

        // ApplicationUserProfileService Exception messages
        public const string ApplicationUserEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of ApplicationUser is required !";
        public const string ApplicationUserTransitionalRequiredExceptionMessage = "An instance of ApplicationUserTransitional is required !";

        // PhotocourseService Exception messages
        public const string PhotocourseEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of Photocourse is required !";
        public const string PhotocourseTransitionalRequiredExceptionMessage = "An instance of PhotocourseTransitional is required !";

        // StudentService Exception messages
        public const string StudentEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of Student is required !";
        public const string StudentTransitionalRequiredExceptionMessage = "An instance of StudentTransitional is required !";

        // InformationService Exception messages
        public const string InformationEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of Information is required !";
        public const string InformationTransitionalRequiredExceptionMessage = "An instance of InformationTransitional is required !";

        // ImageService Exception messages
        public const string ImageServiceRequiredExceptionMessage = "An instance of ImageService is required !";
        public const string ImageEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of Image is required !";
        public const string ImageTransitionalRequiredExceptionMessage = "An instance of ImageTransitional is required !";
        public const string ImageServiceRequiredExceptionMessage = "An instance of ImageService is required !";
        public const string ImageTransitionalCollectionRequiredExceptionMessage = "An instance of IEnumerable<ImageTransitional> is required !";
        public const string ImageRequiredExceptionMessage = "An instance of Image is required !";

        // UploadImageService Exception messages
        public const string CloudStorageRequiredExceptionMessage = "An instance of CloudStorage is required !";
        public const string FileStreamRequiredExceptionMessage = "File stream is required !";
        public const string FilenameRequiredExceptionMessage = "File name is required !";
        public const string MimeTypeRequiredExceptionMessage = "Mime type is required !";

        // MultimediaService Exception messages
        public const string MultimediaEfDbRepositoryRequiredExceptionMessage = "An instance of EfDbRepository of Multimedia is required !";
        public const string MultimediaTransitionalRequiredExceptionMessage = "An instance of MultimediaTransitional is required !";
    }
}
