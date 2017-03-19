namespace PhotoArtSystem.Tests.UnitTests.Mocks
{
    using PhotoArtSystem.Data.Common.Models;

    public class DummyIntClass : BaseModel<int>, IBaseModel<int>, IAuditInfo, IDeletableEntity
    {
    }
}
