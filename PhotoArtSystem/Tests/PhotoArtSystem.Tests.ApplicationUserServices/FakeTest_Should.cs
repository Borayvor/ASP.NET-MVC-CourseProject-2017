namespace PhotoArtSystem.Tests.ApplicationUserServices
{
    using NUnit.Framework;
    using Telerik.JustMock;

    [TestFixture]
    public class FakeTest_Should
    {
        [Test]
        public void Work()
        {
            // Arrange
            var number = 1;

            // Act // Assert
            Mock.Assert(number == 1);
        }
    }
}
