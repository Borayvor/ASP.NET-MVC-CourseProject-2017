namespace PhotoArtSystem.Common.Constants
{
    public class GlobalConstants
    {
        public const string StringEmpty = "";

        // TODO: Set Cache Duration !!!
        // Cache duration
        public const int PhotoArtServicesPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int PhotocoursePartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int PhotocoursesAllPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int CarouselDataPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours
        public const int MainInfoAllPartialCacheDuration = 0; //// * 60 * 24; // sec * min * hours

        // Cache item names
        public const string PhotoArtServicesCacheName = "PhotoArtServices";
        public const string PhotocoursesAllCacheName = "PhotocoursesAll";
        public const string PhotocourseCacheName = "Photocourse_";
        public const string CarouselDataCacheName = "CarouselData";
        public const string MainInfoAllCacheName = "MainInfoAll";

        // Validation messages
        public const string EmailNotValidValidationMessages = "The Email field is not a valid e-mail address.";

        // Common Exception messages
        public const string DbContextRequiredExceptionMessage = "An instance of DbContext is required !";
        public const string EfDbContextRequiredExceptionMessage = "An instance of EfDbContext is required !";
        public const string MapperRequiredExceptionMessage = "An instance of Mapper is required !";

        // ApplicationUserProfileService Exception messages
        public const string EfDbRepositoryApplicationUserRequiredExceptionMessage = "An instance of EfDbRepository of ApplicationUser is required !";
        public const string ApplicationUserTransitionalRequiredExceptionMessage = "An instance of ApplicationUserTransitional is required !";

        // PhotocourseService Exception messages
        public const string EfDbRepositoryPhotocourseRequiredExceptionMessage = "An instance of EfDbRepository of Photocourse is required !";
        public const string PhotocourseTransitionalRequiredExceptionMessage = "An instance of PhotocourseTransitional is required !";

        // StudentService Exception messages
        public const string EfDbRepositoryStudentRequiredExceptionMessage = "An instance of EfDbRepository of Student is required !";
        public const string StudentTransitionalRequiredExceptionMessage = "An instance of StudentTransitional is required !";

        // MainInfoService Exception messages
        public const string EfDbRepositoryMainInfoRequiredExceptionMessage = "An instance of EfDbRepository of MainInfo is required !";
        public const string MainInfoTransitionalRequiredExceptionMessage = "An instance of MainInfoTransitional is required !";
    }
}
