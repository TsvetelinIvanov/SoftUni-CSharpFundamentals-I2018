public class InvalidSongMinutesException : InvalidSongLengthException
{
    public override string Message => $"Song minutes should be between {Song.MinSongLengthMinutes} " +
        $"and {Song.MaxSongLengthMinutes}.";
}