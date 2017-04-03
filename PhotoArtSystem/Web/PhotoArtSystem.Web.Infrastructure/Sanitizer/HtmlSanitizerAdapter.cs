namespace PhotoArtSystem.Web.Infrastructure.Sanitizer
{
    using Bytes2you.Validation;
    using Common.Constants;
    using Ganss.XSS;

    public class HtmlSanitizerAdapter : ISanitizer
    {
        public string Sanitize(string html)
        {
            Guard.WhenArgument(
                html,
                GlobalConstants.PhotocourseTransitionalRequiredExceptionMessage)
                .IsNullOrWhiteSpace()
                .Throw();

            var sanitizer = new HtmlSanitizer();
            var result = sanitizer.Sanitize(html);

            return result;
        }
    }
}
