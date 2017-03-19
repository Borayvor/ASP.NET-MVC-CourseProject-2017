namespace PhotoArtSystem.Tests.UnitTests.Mocks
{
    using System;
    using System.Collections.Generic;
    using PhotoArtSystem.Data.Common.Models;
    using Ploeh.AutoFixture;

    public class DummyGuidClass : BaseModelGuid, IBaseModel<Guid>, IAuditInfo, IDeletableEntity
    {
        public static IList<DummyGuidClass> GetDummyCollection()
        {
            Fixture fixture = new Fixture();

            return new List<DummyGuidClass>()
            {
                new DummyGuidClass
                {
                    Id = fixture.Create<Guid>(),
                    CreatedOn = fixture.Create<DateTime>(),
                    IsDeleted = false
                },
                new DummyGuidClass
                {
                    Id = fixture.Create<Guid>(),
                    CreatedOn = fixture.Create<DateTime>(),
                    IsDeleted = true
                },
                new DummyGuidClass
                {
                    Id = fixture.Create<Guid>(),
                    CreatedOn = fixture.Create<DateTime>(),
                    IsDeleted = false
                }
            };
        }
    }
}
