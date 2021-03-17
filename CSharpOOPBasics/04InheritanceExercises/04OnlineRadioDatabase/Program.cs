using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        List<Song> songs = new List<Song>();
        int songsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < songsCount; i++)
        {
            try
            {
                string[] songData = Console.ReadLine().Split(';', ':');
                //if (songData.Length != 4)
                //{
                //    throw new InvalidSongException();
                //}

                string artistName = songData[0];
                string songName = songData[1];
                if (int.TryParse(songData[2], out int minutes) && int.TryParse(songData[3], out int seconds))
                {
                    Song song = new Song(artistName, songName, minutes, seconds);
                    songs.Add(song);
                    Console.WriteLine("Song added.");
                }
                else
                {
                    throw new InvalidSongLengthException();
                }

            }
            catch (Exception ise)
            {
                Console.WriteLine(ise.Message);
            }
        }

        Console.WriteLine("Songs added: " + songs.Count);
        int totalLengthInSeconds = songs.Select(s => s.SongLengthInSeconds).Sum();
        int totalHours = totalLengthInSeconds / 3600;
        int totalMinutes = (totalLengthInSeconds % 3600) / 60;
        int totalSeconds = (totalLengthInSeconds % 3600) % 60;
        Console.WriteLine($"Playlist length: {totalHours}h {totalMinutes}m {totalSeconds}s");
    }
}