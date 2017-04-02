namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Bytes2you.Validation;
    using CloudStorages.Contracts;
    using Common.Constants;
    using Contracts;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.EnumTypes;
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

        public async Task<Image> Create(ImageTransitional entity, ImageFormatType format)
        {
            Guard.WhenArgument(entity, nameof(entity))
                .IsNull()
                .Throw();

            entity.Format = format;
            var entityDb = await this.CreateImage(entity, null, null);
            this.images.Create(entityDb);

            this.context.Save();
            return entityDb;
        }

        public async Task<IEnumerable<Image>> Create(
            IEnumerable<ImageTransitional> entities,
            ImageFormatType format)
        {
            Guard.WhenArgument(entities, nameof(entities))
                .IsNull()
                .Throw();

            ICollection<Image> imageList = new List<Image>();
            Image entityDb;

            foreach (var entity in entities)
            {
                Guard.WhenArgument(entity, nameof(entity))
                .IsNull()
                .Throw();

                entity.Format = format;
                entityDb = await this.CreateImage(entity, null, null);
                this.images.Create(entityDb);
                imageList.Add(entityDb);
            }

            this.context.Save();

            return imageList;
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

        private async Task<Image> CreateImage(
            ImageTransitional entity,
            string cropMode,
            string outputFormat)
        {
            int width, height;

            switch (entity.Format)
            {
                case ImageFormatType.Ordinary:
                    {
                        width = GlobalConstants.ImageWidth;
                        height = GlobalConstants.ImageHeight;
                        break;
                    }

                case ImageFormatType.Cover:
                    {
                        width = GlobalConstants.ImageCoverWidth;
                        height = GlobalConstants.ImageCoverHeight;
                        break;
                    }

                default:
                    {
                        width = GlobalConstants.ImageAvatarWidth;
                        height = GlobalConstants.ImageAvatarHeight;
                        break;
                    }
            }

            var uniqueName = Guid.NewGuid().ToString();

            string url = await this.storage.UploadFile(
                    entity.FileStream,
                    entity.FileName + "_" + uniqueName,
                    entity.FileExtension,
                    width,
                    height,
                    cropMode,
                    outputFormat);

            var newImage = new Image
            {
                FileName = entity.FileName,
                FileExtension = entity.FileExtension,
                Format = entity.Format,
                UrlPath = url
            };

            return newImage;
        }
    }
}
