using _06Twitter.Contracts;

namespace _06Twitter
{
    public class Tweet : ITweet
    {
        private IClient client;

        public Tweet(IClient client)
        {
            this.client = client;
        }

        public void ReceiveMessage(string message)
        {
            this.client.WriteTweet(message);
            this.client.SendTweetToServer(message);
        }
    }
}