using _06Twitter;
using _06Twitter.Contracts;
using Moq;
using NUnit.Framework;

namespace _06TweeterTests
{
    [TestFixture]
    public class TweetTests
    {
        [Test]
        public void ReceiveMessageInvokesClientToWriteTheMessage()
        {
            Mock<IClient> mockClient = new Mock<IClient>();
            mockClient.Setup(mc => mc.SendTweetToServer(It.IsAny<string>()));
            Tweet tweet = new Tweet(mockClient.Object);

            tweet.ReceiveMessage("Test");

            // Assert - (Mock.Verify) Verifies that the method is Invoked during the Test exactly 1 time
            mockClient.Verify(c => c.WriteTweet(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to write the message!");
        }

        [Test]
        public void ReceiveMessageInvokesClientToSendMessage()
        {
            Mock<IClient> mockClient = new Mock<IClient>();
            mockClient.Setup(mc => mc.SendTweetToServer(It.IsAny<string>()));
            Tweet tweet = new Tweet(mockClient.Object);

            tweet.ReceiveMessage("Test");

            //Assert
            mockClient.Verify(c => c.SendTweetToServer(It.IsAny<string>()), Times.Once, "Tweet doesn't invoke its client to send the message to the server!");
        }
    }
}