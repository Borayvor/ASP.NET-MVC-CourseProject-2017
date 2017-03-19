namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbRepositoryTests
{
    using System;
    using System.Data.Entity;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.Repositories;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class GetById_Should
    {
        [Test]
        public void CallDbContext_GetAll_MethodOnce()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedModel = new DummyGuidClass();
            var mockedDbContext = new Mock<DbContext>();
            mockedDbContext.Setup(x => x.Set<DummyGuidClass>().Find(id)).Returns(mockedModel);

            var mockedIEfDbRepository = new EfDbRepository<DummyGuidClass>(mockedDbContext.Object);

            // Act
            mockedIEfDbRepository.GetById(id);

            // Assert
            mockedDbContext.Verify(x => x.Set<DummyGuidClass>().Find(id), Times.Once);
        }

        [Test]
        public void ReturnEntityWithExpectedId()
        {
            // Arange
            Fixture fixture = new Fixture();
            var id = fixture.Create<Guid>();
            var mockedModel = new DummyGuidClass();
            var mockedDbContext = new Mock<DbContext>();
            mockedDbContext.Setup(x => x.Set<DummyGuidClass>().Find(id)).Returns(mockedModel);

            var mockedIEfDbRepository = new EfDbRepository<DummyGuidClass>(mockedDbContext.Object);

            // Act
            var result = mockedIEfDbRepository.GetById(id);

            // Assert
            Assert.AreSame(mockedModel, result);
        }
    }
}
