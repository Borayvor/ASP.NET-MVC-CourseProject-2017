namespace PhotoArtSystem.Services.Web
{
    using AutoMapper;
    using Bytes2you.Validation;
    using Common.Constants;
    using Contracts;

    public class AutoMapperService : IAutoMapperService
    {
        private readonly IMapper mapper;

        public AutoMapperService(IMapper mapper)
        {
            Guard.WhenArgument(
                mapper,
                GlobalConstants.MapperRequiredExceptionMessage).IsNull().Throw();

            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            Guard.WhenArgument(
                source,
                GlobalConstants.SourceObjectRequiredExceptionMessage).IsNull().Throw();

            return this.mapper.Map<TDestination>(source);
        }
    }
}
