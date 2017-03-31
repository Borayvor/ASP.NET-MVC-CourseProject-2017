namespace PhotoArtSystem.Data.Models.TransitionalModels
{
    using System.Collections.Generic;
    using System.Web;

    public class PhotocourseExtendedTransitional : PhotocourseTransitional
    {
        public IEnumerable<HttpPostedFileBase> Files { get; set; }
    }
}
