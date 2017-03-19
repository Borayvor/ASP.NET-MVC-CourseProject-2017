namespace PhotoArtSystem.Tests.UnitTests.Data.DbModels
{
    using System;
    using Mocks;
    using NUnit.Framework;
    using Ploeh.AutoFixture;

    [TestFixture]
    public class BaseModelIntClassTests
    {
        [Test]
        public void Setters_ShouldSetPropertiesCorrectly()
        {
            // Arrange
            Fixture fixture = new Fixture();
            var expectedId = fixture.Create<int>();
            var expectedCreatedOn = fixture.Create<DateTime>();
            var expectedModifiedOn = fixture.Create<DateTime?>();
            var expectedIsDeleted = fixture.Create<bool>();
            var expectedDeletedOn = fixture.Create<DateTime?>();

            var dummyClass = new DummyIntClass
            {
                Id = expectedId,
                CreatedOn = expectedCreatedOn,
                ModifiedOn = expectedModifiedOn,
                IsDeleted = expectedIsDeleted,
                DeletedOn = expectedDeletedOn
            };

            // Act & Assert
            Assert.AreEqual(expectedId, dummyClass.Id);
            Assert.AreEqual(expectedCreatedOn, dummyClass.CreatedOn);
            Assert.AreEqual(expectedModifiedOn, dummyClass.ModifiedOn);
            Assert.AreEqual(expectedIsDeleted, dummyClass.IsDeleted);
            Assert.AreEqual(expectedDeletedOn, dummyClass.DeletedOn);
        }
    }
}
