public class Song
{
    internal const int MinArtistNameLength = 3;
    internal const int MaxArtistNameLength = 20;
    internal const int MinSongNameLength = 3;
    internal const int MaxSongNameLength = 30;
    internal const int MinSongLengthMinutes = 0;
    internal const int MaxSongLengthMinutes = 14;
    internal const int MinSongLengthSeconds = 0;
    internal const int MaxSongLengthSeconds = 59;

    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string artistName, string songName, int minutes, int seconds)
    {
        this.ArtistName = artistName;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public string ArtistName
    {
        get { return this.artistName; }
        set
        {
            if (value.Length < MinArtistNameLength || value.Length > MaxArtistNameLength)
            {
                throw new InvalidArtistNameException();
            }

            this.artistName = value;
        }
    }

    public string SongName
    {
        get { return this.songName; }
        set
        {
            if (value.Length < MinSongNameLength || value.Length > MaxSongNameLength)
            {
                throw new InvalidSongNameException();
            }

            this.songName = value;
        }
    }

    public int Minutes
    {
        get { return this.minutes; }
        set
        {
            if (value < MinSongLengthMinutes || value > MaxSongLengthMinutes)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    public int Seconds
    {
        get { return this.seconds; }
        set
        {
            if (value < MinSongLengthSeconds || value > MaxSongLengthSeconds)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }

    public int SongLengthInSeconds => 60 * this.Minutes + this.Seconds;
}