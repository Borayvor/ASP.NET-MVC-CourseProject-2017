namespace PhotoArtSystem.Common.Constants
{
    public class ModelConstants
    {
        // ApplicationUser
        public const int ApplicationUserUsernameMaxLength = 256;
        public const int ApplicationUserUsernameMinLength = 2;
        public const int ApplicationUserEmailMaxLength = 256;
        public const int ApplicationUserFirstNameMaxLength = 100;
        public const int ApplicationUserFirstNameMinLength = 2;
        public const int ApplicationUserLastNameMaxLength = 100;
        public const int ApplicationUserLastNameMinLength = 2;

        // Photocourse
        public const int PhotocourseNameMaxLength = 100;
        public const int PhotocourseNameMinLength = 2;
        public const int PhotocourseDescriptionMaxLength = 500;
        public const int PhotocourseDescriptionMinLength = 2;
        public const int PhotocourseOtherInfoMaxLength = 2000;

        // Photography
        public const int PhotographyNameMaxLength = 100;
        public const int PhotographyNameMinLength = 2;

        // Photopleinair
        public const int PhotopleinairNameMaxLength = 100;
        public const int PhotopleinairNameMinLength = 2;

        // Phototeambuilding
        public const int PhototeambuildingNameMaxLength = 100;
        public const int PhototeambuildingNameMinLength = 2;

        // Lesson
        public const int LessonNameMaxLength = 1000;
        public const int LessonNameMinLength = 2;

        // PhotocourseGroup
        public const int PhotocourseGroupOtherInfoMaxLength = 2000;

        // PhotoLink
        public const int PhotoLinkContentMaxLength = 1000;
        public const int PhotoLinkFileNameMaxLength = 100;

        // ImageOriginal
        public const int ImageOriginalFileNameMaxLength = 255;
        public const int ImageOriginalContentTypeMaxLength = 100;
    }
}
