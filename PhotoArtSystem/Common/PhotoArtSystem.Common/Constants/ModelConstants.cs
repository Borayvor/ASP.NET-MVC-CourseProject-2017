namespace PhotoArtSystem.Common.Constants
{
    public class ModelConstants
    {
        // ApplicationUser
        public const int ApplicationUserUsernameMaxLength = 256;
        public const int ApplicationUserUsernameMinLength = 2;
        public const int ApplicationUserEmailMaxLength = 256;
        public const int ApplicationUserNamesMaxLength = 100;
        public const int ApplicationUserNamesMinLength = 2;

        // Information
        public const int InformationTitleMaxLength = 200;
        public const int InformationTitleMinLength = 2;
        public const int InformationDescriptionMaxLength = 1000;
        public const int InformationDescriptionMinLength = 2;

        // Photocourse
        public const int PhotocourseNameMaxLength = 100;
        public const int PhotocourseNameMinLength = 2;
        public const int PhotocourseDescriptionShortMaxLength = 700;
        public const int PhotocourseDescriptionShortMinLength = 10;
        public const int PhotocourseDescriptionMaxLength = 3500;
        public const int PhotocourseDescriptionMinLength = 10;
        public const int PhotocourseOtherInfoMaxLength = 2000;
        public const int PhotocourseTeacherMaxLength = 201;

        // FileInfo
        public const int FileInfoUrlPathMaxLength = 1000;
        public const int FileInfoFileNameMaxLength = 50;
        public const int FileInfoFileNameMinLength = 2;
        public const int FileInfoFileExtensionMaxLength = 5;
        public const int FileInfoFileExtensionMinLength = 2;
    }
}
