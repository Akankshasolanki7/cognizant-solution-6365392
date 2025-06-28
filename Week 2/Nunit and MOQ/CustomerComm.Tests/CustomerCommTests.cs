using NUnit.Framework;
using Moq;
using CustomerCommLib;

namespace CustomerComm.Tests
{
    [TestFixture]
    public class CustomerCommTests
    {
        private Mock<IMailSender> _mockMailSender;
        private CustomerCommLib.CustomerComm _customerComm;

        [SetUp]
        public void Setup()
        {
            _mockMailSender = new Mock<IMailSender>();
            _customerComm = new CustomerCommLib.CustomerComm(_mockMailSender.Object);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldReturnTrue_WhenMailSenderReturnsTrue()
        {
            // Arrange
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            // Act
            bool result = _customerComm.SendMailToCustomer();

            // Assert
            Assert.IsTrue(result);
            _mockMailSender.Verify(x => x.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }

        [TestCase]
        public void SendMailToCustomer_ShouldCallMailSender_WithCorrectParameters()
        {
            // Arrange
            _mockMailSender.Setup(x => x.SendMail(It.IsAny<string>(), It.IsAny<string>()))
                          .Returns(true);

            // Act
            _customerComm.SendMailToCustomer();

            // Assert
            _mockMailSender.Verify(x => x.SendMail("cust123@abc.com", "Some Message"), Times.Once);
        }
    }
}
