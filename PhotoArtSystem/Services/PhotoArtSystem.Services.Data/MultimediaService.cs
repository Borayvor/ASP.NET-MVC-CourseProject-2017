namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using PhotoArtSystem.Common.Constants;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.Factories;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using PhotoArtSystem.Services.Data.Contracts;
    using PhotoArtSystem.Services.Web.Contracts;
    using PhotoArtSystem.Web.Infrastructure.Sanitizer;

    public class MultimediaService : IMultimediaService
    {
        private readonly IModelDbFactory modelDbFactory;
        private readonly ISanitizer sanitizer;
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Multimedia> multimedia;

        public MultimediaService(
            IModelDbFactory modelDbFactory,
            ISanitizer sanitizer,
            IAutoMapperService mapper,
            IEfDbContextSaveChanges context,
            IPhotoArtSystemEfDbRepository<Multimedia> multimedia)
        {
            Guard.WhenArgument(
                modelDbFactory,
                GlobalConstants.ModelDbFactoryRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
               sanitizer,
               GlobalConstants.SanitizerRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                multimedia,
                GlobalConstants.MultimediaEfDbRepositoryRequiredExceptionMessage).IsNull().Throw();

            this.modelDbFactory = modelDbFactory;
            this.sanitizer = sanitizer;
            this.mapper = mapper;
            this.context = context;
            this.multimedia = multimedia;
        }

        public IEnumerable<MultimediaTransitional> GetAll()
        {
            var entityDbList = this.multimedia.GetAll().OrderBy(x => x.CreatedOn).ToList();
            var result = this.mapper.Map<IEnumerable<MultimediaTransitional>>(entityDbList);

            return result;
        }

        public MultimediaTransitional GetById(Guid id)
        {
            var entityDb = this.multimedia.GetById(id);
            var result = this.mapper.Map<MultimediaTransitional>(entityDb);

            return result;
        }

        public void Create(MultimediaTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MultimediaTransitionalRequiredExceptionMessage)
              .IsNull()
              .Throw();

            if (!entity.UrlPath.StartsWith("https://youtu.be/"))
            {
                throw new ArgumentException(GlobalConstants.YouTubeRequiredExceptionMessage);
            }

            entity.Description = this.sanitizer.Sanitize(entity.Description);

            var imageId = entity.UrlPath
                .Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            entity.ImageUrlPath = "https://i.ytimg.com/vi/" + imageId + "/0.jpg";

            Multimedia entityDb = this.modelDbFactory.CreateMultimedia(
                  entity.Title,
                  entity.Description,
                  entity.UrlPath,
                  entity.ImageUrlPath);

            this.multimedia.Create(entityDb);
            this.context.Save();
        }

        public void Update(MultimediaTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MultimediaTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            var entityDb = this.mapper.Map<Multimedia>(entity);

            this.multimedia.Update(entityDb);
            this.context.Save();
        }

        public void Delete(MultimediaTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MultimediaTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            var entityDb = this.mapper.Map<Multimedia>(entity);

            this.multimedia.Delete(entityDb);
            this.context.Save();
        }
    }
}
