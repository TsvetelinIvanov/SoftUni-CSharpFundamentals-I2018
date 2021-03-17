public class InvalidArtistNameException : InvalidSongException
{
    public override string Message => $"Artist name should be between {Song.MinArtistNameLength} " +
        $"and {Song.MaxArtistNameLength} symbols.";
}