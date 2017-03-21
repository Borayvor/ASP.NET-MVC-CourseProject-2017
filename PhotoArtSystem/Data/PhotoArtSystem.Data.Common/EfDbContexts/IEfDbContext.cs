namespace PhotoArtSystem.Data.Common.EfDbContexts
{
    using System.Threading.Tasks;

    public interface IEfDbContext
    {
        void Save();

        Task<int> SaveAsync();
    }
}