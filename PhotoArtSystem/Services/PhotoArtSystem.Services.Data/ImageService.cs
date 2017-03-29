namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using CloudStorages.Contracts;
    using Common.Constants;
    using Contracts;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using Web.Contracts;

    public class ImageService : IImageService
    {
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Image> images;
        private readonly IImageCloudStorage storage;

        public ImageService(
            IAutoMapperService mapper,
            IEfDbContextSaveChanges context,
            IPhotoArtSystemEfDbRepository<Image> images,
            IImageCloudStorage storage)
        {
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                images,
                GlobalConstants.EfDbRepositoryImageRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                storage,
                GlobalConstants.CloudStorageRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.context = context;
            this.images = images;
            this.storage = storage;
        }

        public IEnumerable<ImageTransitional> GetAll()
        {
            var entityDbList = this.images.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<ImageTransitional>>(entityDbList);

            return result;
        }

        public ImageTransitional GetById(Guid id)
        {
            var entityDb = this.images.GetById(id);
            var result = this.mapper.Map<ImageTransitional>(entityDb);

            return result;
        }

        public void Create(ImageTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.ImageTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            var entityDb = this.mapper.Map<Image>(entity);

            ////var url = this.storage.UploadFile(entity.Stream, entity.FileName, entity.FileExtension, (uint)entity.FileSize, 4);

            this.images.Create(entityDb);
            this.context.Save();
        }

        public void Update(ImageTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.ImageTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            var entityDb = this.mapper.Map<Image>(entity);

            this.images.Update(entityDb);
            this.context.Save();
        }

        public void Delete(ImageTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.ImageTransitionalRequiredExceptionMessage)
                .IsNull()
                .Throw();

            var entityDb = this.mapper.Map<Image>(entity);

            this.images.Delete(entityDb);
            this.context.Save();
        }
    }
}
