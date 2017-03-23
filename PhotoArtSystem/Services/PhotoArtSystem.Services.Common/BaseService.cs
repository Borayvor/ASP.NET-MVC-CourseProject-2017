namespace PhotoArtSystem.Services.Common
{
    using AutoMapper;
    using Web.Contracts;

    public abstract class BaseService
    {
        protected BaseService(IAutoMapperService mapper)
        {
            this.Mapper = mapper.GetAutoMapper;
        }

        protected IMapper Mapper { get; }
    }
}
