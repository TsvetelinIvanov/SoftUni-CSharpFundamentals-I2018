public class InvalidSongSecondsException : InvalidSongLengthException
{
    public override string Message => $"Song seconds should be between {Song.MinSongLengthSeconds} " +
        $"and {Song.MaxSongLengthSeconds}.";
}