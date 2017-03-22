namespace PhotoArtSystem.Data.Common.EfDbContexts
{
    using System.Threading.Tasks;

    public interface IEfDbContextSaveChanges
    {
        void Save();

        Task<int> SaveAsync();
    }
}