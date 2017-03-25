namespace PhotoArtSystem.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Bytes2you.Validation;
    using Common.Constants;
    using Contracts;
    using PhotoArtSystem.Data.Common.EfDbContexts;
    using PhotoArtSystem.Data.Common.Repositories;
    using PhotoArtSystem.Data.Models;
    using PhotoArtSystem.Data.Models.TransitionalModels;
    using Web.Contracts;

    public class MainInfoService : IMainInfoService
    {
        private readonly IAutoMapperService mapper;
        private readonly IPhotoArtSystemEfDbRepository<MainInfo> mainInfo;
        private readonly IEfDbContextSaveChanges context;

        public MainInfoService(IAutoMapperService mapper, IEfDbContextSaveChanges context, IPhotoArtSystemEfDbRepository<MainInfo> mainInfo)
        {
            Guard.WhenArgument(
                mapper,
                GlobalConstants.MapperRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                mainInfo,
                GlobalConstants.EfDbRepositoryMainInfoRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.context = context;
            this.mainInfo = mainInfo;
        }

        public IEnumerable<MainInfoTransitional> GetAll()
        {
            var entityDbList = this.mainInfo.GetAll().ToList();
            var result = this.mapper.Map<IEnumerable<MainInfoTransitional>>(entityDbList);

            return result;
        }

        public MainInfoTransitional GetById(Guid id)
        {
            var entityDb = this.mainInfo.GetById(id);
            var result = this.mapper.Map<MainInfoTransitional>(entityDb);

            return result;
        }

        public void Create(MainInfoTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MainInfoTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<MainInfo>(entity);

            this.mainInfo.Create(entityDb);
            this.context.Save();
        }

        public void Update(MainInfoTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MainInfoTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<MainInfo>(entity);

            this.mainInfo.Update(entityDb);
            this.context.Save();
        }

        public void Delete(MainInfoTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.MainInfoTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<MainInfo>(entity);

            this.mainInfo.Delete(entityDb);
            this.context.Save();
        }
    }
}
