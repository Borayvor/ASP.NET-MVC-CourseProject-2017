namespace PhotoArtSystem.Services.Web
{
    using AutoMapper;
    using Contracts;
    using PhotoArtSystem.Web.Infrastructure.Mapping;

    public class AutoMapperService : IAutoMapperService
    {
        public IMapper GetAutoMapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}
