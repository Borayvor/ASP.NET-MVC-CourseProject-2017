namespace PhotoArtSystem.Services.Web
{
    using AutoMapper;
    using Contracts;

    public class AutoMapperService : IAutoMapperService
    {
        private readonly IMapper mapper;

        public AutoMapperService(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return this.mapper.Map<TDestination>(source);
        }
    }
}
