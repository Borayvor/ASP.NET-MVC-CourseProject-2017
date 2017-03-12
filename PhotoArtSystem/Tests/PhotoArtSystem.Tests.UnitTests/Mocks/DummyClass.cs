namespace PhotoArtSystem.Tests.UnitTests.Mocks
{
    using System;
    using PhotoArtSystem.Data.Common.Models;

    public class DummyClass : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
    }
}
