namespace PhotoArtSystem.Tests.UnitTests.Services.AutoMapperServiceTests
{
    using AutoMapper;
    using Common.Constants;
    using Moq;
    using NUnit.Framework;
    using PhotoArtSystem.Services.Web;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void Throw_ArgumentNullException_WithProperMessage_When_Mapper_IsNull()
        {
            // Arange, Act & Assert
            Assert.That(
                () => new AutoMapperService(null),
                            Throws.ArgumentNullException.With.Message.Contains(
                                GlobalConstants.MapperRequiredExceptionMessage));
        }

        [Test]
        public void NotThrow_WhenArguments_AreValid()
        {
            // Arange
            var mockedMapper = new Mock<IMapper>();

            // Act & Assert
            Assert.DoesNotThrow(() => new AutoMapperService(mockedMapper.Object));
        }
    }
}
