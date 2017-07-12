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

    public class InformationService : IInformationService
    {
        private readonly IAutoMapperService mapper;
        private readonly IEfDbContextSaveChanges context;
        private readonly IPhotoArtSystemEfDbRepository<Information> information;

        public InformationService(
            IAutoMapperService mapper,
            IEfDbContextSaveChanges context,
            IPhotoArtSystemEfDbRepository<Information> information)
        {
            Guard.WhenArgument(
                mapper,
                GlobalConstants.AutoMapperServiceRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                context,
                GlobalConstants.EfDbContextRequiredExceptionMessage).IsNull().Throw();
            Guard.WhenArgument(
                information,
                GlobalConstants.InformationEfDbRepositoryRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
            this.context = context;
            this.information = information;
        }

        public IEnumerable<InformationTransitional> GetAll()
        {
            var entityDbList = this.information.GetAll().OrderBy(x => x.CreatedOn).ToList();
            var result = this.mapper.Map<IEnumerable<InformationTransitional>>(entityDbList);

            return result;
        }

        public InformationTransitional GetById(Guid id)
        {
            var entityDb = this.information.GetById(id);
            var result = this.mapper.Map<InformationTransitional>(entityDb);

            return result;
        }

        public void Create(InformationTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.InformationTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Information>(entity);

            this.information.Create(entityDb);
            this.context.Save();
        }

        public void Update(InformationTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.InformationTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Information>(entity);

            this.information.Update(entityDb);
            this.context.Save();
        }

        public void Delete(InformationTransitional entity)
        {
            Guard.WhenArgument(entity, GlobalConstants.InformationTransitionalRequiredExceptionMessage).IsNull().Throw();

            var entityDb = this.mapper.Map<Information>(entity);

            this.information.Delete(entityDb);
            this.context.Save();
        }
    }
}
