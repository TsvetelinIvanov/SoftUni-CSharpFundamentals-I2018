using Moq;
using NUnit.Framework;
﻿using _06Twitter;
using _06Twitter.Contracts;

namespace _06TweeterTests
{
    [TestFixture]
    public class MicrowaveOvenTests
    {
        private const string Message = "Test";

        [Test]
        public void SendTweetToServerWorks()
        {
            //Arrange
            Mock<IWriter> mockWriter = new Mock<IWriter>();
            Mock<ITweetRepository> mockTweetRepository = new Mock<ITweetRepository>();
            mockTweetRepository.Setup(mtr => mtr.SaveTweet(It.IsAny<string>()));
            MicrowaveOven microwaveOven = new MicrowaveOven(mockWriter.Object, mockTweetRepository.Object);
            
            //Act
            microwaveOven.SendTweetToServer(Message);

            //Assert
            mockTweetRepository.Verify(mtr => mtr.SaveTweet(It.Is<string>(s => s == Message)), Times.Once, "Message is not sent to the server!");
        }

        [Test]
        public void WriteTweetWorks()
        {
            //Arrange
            Mock<IWriter> mockWriter = new Mock<IWriter>();
            mockWriter.Setup(mw => mw.WriteLine(It.IsAny<string>()));
            Mock<ITweetRepository> mockTweetRepository = new Mock<ITweetRepository>();
            MicrowaveOven microwaveOven = new MicrowaveOven(mockWriter.Object, mockTweetRepository.Object);
            
            //Act
            microwaveOven.WriteTweet(Message);

            //Assert
            mockWriter.Verify(mw => mw.WriteLine(It.Is<string>(s => s == Message)), $"Tweet in not given to the {typeof(MicrowaveOven)}'s writer!");
        }
    }
}
