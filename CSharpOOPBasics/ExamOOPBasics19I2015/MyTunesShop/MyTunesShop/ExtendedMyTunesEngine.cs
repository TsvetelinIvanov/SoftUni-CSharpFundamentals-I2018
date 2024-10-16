using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyTunesShop
{
    public class ExtendedMyTunesEngine : MyTunesEngine
    {
        protected override void ExecuteInsertCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song_to_album":
                    IAlbum album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]) as IAlbum;
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        
                        return;
                    }

                    ISong song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[3]) as ISong;
                    if (song == null)
                    {
                        this.Printer.PrintLine("The song does not exist in the database.");
                        
                        return;
                    }

                    album.AddSong(song);
                    Printer.PrintLine("The song {0} has been added to the album {1}.", song.Title, album.Title);
                    break;
                case "member_to_band":
                    IBand band = this.performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[2]) as Band;
                    if (band == null)
                    {
                        this.Printer.PrintLine("The band does not exist in the database.");
                        
                        return;
                    }

                    band.AddMember(commandWords[3]);
                    this.Printer.PrintLine("The member {0} has been added to the band {1}.", commandWords[3], band.Name);
                    break;
                default:
                    base.ExecuteInsertCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteRateCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "song":
                    ISong song = this.media.FirstOrDefault(s => s is ISong && s.Title == commandWords[2]) as ISong;
                    if (song == null)
                    {
                        Printer.PrintLine("The song does not exist in the database.");
                        
                        return;
                    }

                    song.PlaceRating(int.Parse(commandWords[3]));
                    this.Printer.PrintLine("The rating has been placed successfully.");
                    break;
                default:
                    base.ExecuteRateCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteInsertMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    IPerformer performer = this.performers.FirstOrDefault(p => p.Name == commandWords[5]);
                    if (performer == null)
                    {
                        this.Printer.PrintLine("The performer does not exist in the database.");
                        
                        return;
                    }

                    Album album = new Album(commandWords[3], decimal.Parse(commandWords[4]), performer, commandWords[6], int.Parse(commandWords[7]));
                    this.InsertAlbum(album, performer);
                    break;
                default:
                    base.ExecuteInsertMediaCommand(commandWords);
                    break;
            }
        }

        private void InsertAlbum(Album album, IPerformer performer)
        {
            this.media.Add(album);
            this.mediaSupplies.Add(album, new SalesInfo());
            this.Printer.PrintLine("Album {0} by {1} added successfully", album.Title, performer.Name);
        }

        protected override void ExecuteReportMediaCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "album":
                    IAlbum album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[3]) as IAlbum;
                    if (album == null)
                    {
                        Printer.PrintLine("The album does not exist in the database.");
                        
                        return;
                    }

                    this.Printer.PrintLine(this.GetAlbumReport(album));
                    break;
                default:
                    base.ExecuteReportMediaCommand(commandWords);
                    break;
            }
        }

        private string GetAlbumReport(IAlbum album)
        {
            SalesInfo albumSalesInfo = this.mediaSupplies[album];
            StringBuilder albumInfoBuilder = new StringBuilder();
            albumInfoBuilder.AppendFormat("{0} ({1}) by {2}", album.Title, album.Year, album.Performer.Name)
                .AppendLine()
                .AppendFormat("Genre: {0}, Price: ${1:F2}", album.Genre, album.Price)
                .AppendLine()
                //.AppendFormat("Rating: {0}", album.Songs.Select(s => s.Ratings.Sum()).Sum())
                //.AppendLine()
                .AppendFormat("Supplies: {0}, Sold: {1}", albumSalesInfo.Supplies, albumSalesInfo.QuantitySold)
                .AppendLine();

            if (album.Songs.Any())
            {
                IEnumerable<string> songs = album.Songs.Select(s => s.Title + " (" + s.Duration + ")");
                albumInfoBuilder.AppendLine("Songs:")
                    .Append(string.Join(Environment.NewLine, songs));
            }
            else
            {
                albumInfoBuilder.Append("No songs");
            }

            return albumInfoBuilder.ToString();
        }

        protected override void ExecuteReportPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    IBand band = performers.FirstOrDefault(b => b is IBand && b.Name == commandWords[3]) as IBand;
                    if (band == null)
                    {
                        Printer.PrintLine("The band does not exist in the database.");
                        
                        return;
                    }

                    this.Printer.PrintLine(this.GetBandReport(band));
                    break;
                default:
                    base.ExecuteReportPerformerCommand(commandWords);
                    break;
            }
        }

        private string GetBandReport(IBand band)
        {
            StringBuilder bandInfoBuilder = new StringBuilder();
            bandInfoBuilder.Append(band.Name + ": ");
            if (band.Members.Any())
            {
                bandInfoBuilder.Append(string.Join(", ", band.Members));
            }

            bandInfoBuilder.AppendLine();
            if (band.Songs.Any())
            {
                IOrderedEnumerable<string> songs = band.Songs.Select(s => s.Title).OrderBy(t => t);
                bandInfoBuilder.Append(string.Join("; ", songs));
            }
            else
            {
                bandInfoBuilder.Append("no songs");
            }

            return bandInfoBuilder.ToString();
        }

        protected override void ExecuteInsertPerformerCommand(string[] commandWords)
        {
            switch (commandWords[2])
            {
                case "band":
                    IBand band = new Band(commandWords[3]);
                    this.InsertPerformer(band);
                    break;
                default:
                    base.ExecuteInsertPerformerCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSupplyCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    IAlbum album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]) as IAlbum;
                    if (album == null)
                    {
                        Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Supply(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully supplied.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSupplyCommand(commandWords);
                    break;
            }
        }

        protected override void ExecuteSellCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "album":
                    IMedia album = this.media.FirstOrDefault(a => a is IAlbum && a.Title == commandWords[2]);
                    if (album == null)
                    {
                        this.Printer.PrintLine("The album does not exist in the database.");
                        return;
                    }

                    int quantity = int.Parse(commandWords[3]);
                    this.mediaSupplies[album].Sell(quantity);
                    this.Printer.PrintLine("{0} items of album {1} successfully sold.", quantity, album.Title);
                    break;
                default:
                    base.ExecuteSellCommand(commandWords);
                    break;
            }
        }
    }
}
