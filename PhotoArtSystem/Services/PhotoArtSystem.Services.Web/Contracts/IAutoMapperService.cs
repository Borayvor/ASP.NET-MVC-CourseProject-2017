namespace PhotoArtSystem.Services.Web.Contracts
{
    using AutoMapper;

    public interface IAutoMapperService
    {
        IMapper GetAutoMapper { get; }
    }
}
