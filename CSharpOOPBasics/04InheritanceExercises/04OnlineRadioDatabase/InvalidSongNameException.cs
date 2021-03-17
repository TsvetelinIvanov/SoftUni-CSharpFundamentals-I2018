public class InvalidSongNameException : InvalidSongException
{
    public override string Message => $"Song name should be between {Song.MinSongNameLength} " +
        $"and {Song.MaxSongNameLength} symbols.";
}