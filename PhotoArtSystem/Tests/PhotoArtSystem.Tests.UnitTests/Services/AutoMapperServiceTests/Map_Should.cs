namespace PhotoArtSystem.Tests.UnitTests.Services.AutoMapperServiceTests
{
    using AutoMapper;
    using Common.Constants;
    using Mocks;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web;

    [TestFixture]
    public class Map_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_SourceObject_IsNull()
        {
            // Arange
            var mockedMapper = new Mock<IMapper>();
            var service = new AutoMapperService(mockedMapper.Object);

            // Act & Assert
            Assert.That(
                () => service.Map<DummyGuidClass>(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.SourceObjectRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedMapper = new Mock<IMapper>();
            var service = new AutoMapperService(mockedMapper.Object);

            // Act & Assert
            Assert.DoesNotThrow(() => service.Map<DummyGuidClass>(mockedMapper.Object));
        }
    }
}
