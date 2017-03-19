namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbRepositoryTests
{
    using System.Data.Entity;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.Repositories;

    [TestFixture]
    public class GetAllWithDeleted_Should
    {
        [Test]
        public void CallRepository_GetAll_MethodOnce()
        {
            // Arange
            var mockedDbContext = new Mock<DbContext>();
            var mockedIEfDbRepository = new Mock<EfDbRepository<DummyGuidClass>>(mockedDbContext.Object);

            // Act
            mockedIEfDbRepository.Object.GetAllWithDeleted();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAllWithDeleted(), Times.Once);
        }

        ////[Test]
        ////public void ReturnAllEntitiesOfType_T()
        ////{
        ////    // Arange
        ////    var dummyCollection = DummyGuidClass.GetDummyCollection();
        ////    var expected = dummyCollection.AsQueryable();
        ////    var mockedDbContext = new Mock<DbContext>();
        ////    mockedDbContext.Setup(x => x.Set<DummyGuidClass>()).Returns(expected);

        ////    var mockedIEfDbRepository = new EfDbRepository<DummyGuidClass>(mockedDbContext.Object);

        ////    // Act
        ////    var actual = mockedIEfDbRepository.GetAllWithDeleted();

        ////    // Assert
        ////    Assert.AreEqual(expected.Count(), actual.Count());
        ////}
    }
}
