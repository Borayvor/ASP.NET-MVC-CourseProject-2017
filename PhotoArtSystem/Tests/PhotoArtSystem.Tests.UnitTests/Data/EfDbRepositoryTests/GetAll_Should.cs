namespace PhotoArtSystem.Tests.UnitTests.Data.EfDbRepositoryTests
{
    using System.Data.Entity;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Data.Common.Repositories;

    [TestFixture]
    public class GetAll_Should
    {
        [Test]
        public void CallRepository_GetAll_MethodOnce()
        {
            // Arange
            var mockedDbContext = new Mock<DbContext>();
            var mockedIEfDbRepository = new Mock<EfDbRepository<DummyGuidClass>>(mockedDbContext.Object);

            // Act
            mockedIEfDbRepository.Object.GetAll();

            // Assert
            mockedIEfDbRepository.Verify(x => x.GetAll(), Times.Once);
        }

        ////[Test]
        ////public void ReturnAllEntitiesOfType_T_WithProperty_IsDeleted_False()
        ////{
        ////    // Arange
        ////    var dummyCollection = DummyGuidClass.GetDummyCollection();
        ////    var expected = dummyCollection.AsQueryable().Where(x => x.IsDeleted);
        ////    var mockedDbContext = new Mock<DbContext>();
        ////    mockedDbContext.Setup(x => x.Set<DummyGuidClass>().AsQueryable().Where(m => !m.IsDeleted))
        ////        .Returns(expected);

        ////    var mockedIEfDbRepository = new EfDbRepository<DummyGuidClass>(mockedDbContext.Object);

        ////    // Act
        ////    var actual = mockedIEfDbRepository.GetAll();

        ////    // Assert
        ////    Assert.AreEqual(expected.Count(), actual.Count());
        ////}
    }
}
