using _06Twitter.Contracts;

namespace _06Twitter
{
    public class MicrowaveOven : IClient
    {
        private IWriter writer;
        ITweetRepository tweetRepository;

        public MicrowaveOven(IWriter writer, ITweetRepository tweetRepository)
        {
            this.writer = writer;
            this.tweetRepository = tweetRepository;
        }

        public void SendTweetToServer(string message)
        {
            this.tweetRepository.SaveTweet(message);
        }

        public void WriteTweet(string message) => this.writer.WriteLine(message);
    }
}