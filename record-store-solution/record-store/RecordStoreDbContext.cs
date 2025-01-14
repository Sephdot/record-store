using Microsoft.EntityFrameworkCore;
using record_store.Entities;

namespace record_store
{
    public class RecordStoreDbContext : DbContext
    {
        public DbSet<Album> Albums { get; set; }
        public RecordStoreDbContext(DbContextOptions<RecordStoreDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder mb)
        {
            base.OnModelCreating(mb);
            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") is "Development")
            {
                mb.Entity<Album>()
                    .HasKey(i => i.Id);
                mb.Entity<Album>()
                    .HasData(
                    new Album { Id = 1, Title = "Thriller", Artist = "Michael Jackson", Label = "Epic", ReleaseDate = new DateOnly(1982, 11, 30), Genres =  { Genre.POP, Genre.RHYTHM_AND_BLUES } },
                    new Album { Id = 2, Title = "Back in Black", Artist = "AC/DC", Label = "Atlantic", ReleaseDate = new DateOnly(1980, 7, 25), Genres =  { Genre.ROCK } },
                    new Album { Id = 3, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Label = "Harvest", ReleaseDate = new DateOnly(1973, 3, 1), Genres =  { Genre.ROCK, Genre.PROGRESSIVE_ROCK } },
                    new Album { Id = 4, Title = "21", Artist = "Adele", Label = "XL", ReleaseDate = new DateOnly(2011, 1, 24), Genres =  { Genre.POP, Genre.SOUL } },
                    new Album { Id = 5, Title = "The Eminem Show", Artist = "Eminem", Label = "Aftermath", ReleaseDate = new DateOnly(2002, 5, 26), Genres =  { Genre.RAP, Genre.HIP_HOP } },
                    new Album { Id = 6, Title = "Rumours", Artist = "Fleetwood Mac", Label = "Warner Bros.", ReleaseDate = new DateOnly(1977, 2, 4), Genres =  { Genre.ROCK, Genre.POP } },
                    new Album { Id = 7, Title = "Abbey Road", Artist = "The Beatles", Label = "Apple", ReleaseDate = new DateOnly(1969, 9, 26), Genres =  { Genre.ROCK } },
                    new Album { Id = 8, Title = "To Pimp a Butterfly", Artist = "Kendrick Lamar", Label = "Top Dawg", ReleaseDate = new DateOnly(2015, 3, 15), Genres =  { Genre.HIP_HOP, Genre.FUNK, Genre.JAZZ } },
                    new Album { Id = 9, Title = "Born to Run", Artist = "Bruce Springsteen", Label = "Columbia", ReleaseDate = new DateOnly(1975, 8, 25), Genres =  { Genre.ROCK } },
                    new Album { Id = 10, Title = "Hot Fuss", Artist = "The Killers", Label = "Island", ReleaseDate = new DateOnly(2004, 6, 7), Genres =  { Genre.INDIE, Genre.ROCK, Genre.POP } },
                    new Album { Id = 11, Title = "1989", Artist = "Taylor Swift", Label = "Big Machine", ReleaseDate = new DateOnly(2014, 10, 27), Genres =  { Genre.POP } },
                    new Album { Id = 12, Title = "Nevermind", Artist = "Nirvana", Label = "DGC", ReleaseDate = new DateOnly(1991, 9, 24), Genres =  { Genre.ROCK, Genre.GRUNGE } },
                    new Album { Id = 13, Title = "OK Computer", Artist = "Radiohead", Label = "Parlophone", ReleaseDate = new DateOnly(1997, 5, 21), Genres =  { Genre.INDIE, Genre.ROCK, Genre.ELECTRONIC } },
                    new Album { Id = 14, Title = "Hotel California", Artist = "Eagles", Label = "Asylum", ReleaseDate = new DateOnly(1976, 12, 8), Genres =  { Genre.ROCK } },
                    new Album { Id = 15, Title = "The Miseducation of Lauryn Hill", Artist = "Lauryn Hill", Label = "Ruffhouse", ReleaseDate = new DateOnly(1998, 8, 25), Genres =  { Genre.RAP, Genre.RHYTHM_AND_BLUES, Genre.SOUL } },
                    new Album { Id = 16, Title = "Fearless", Artist = "Taylor Swift", Label = "Big Machine", ReleaseDate = new DateOnly(2008, 11, 11), Genres =  { Genre.COUNTRY, Genre.POP } },
                    new Album { Id = 17, Title = "Led Zeppelin IV", Artist = "Led Zeppelin", Label = "Atlantic", ReleaseDate = new DateOnly(1971, 11, 8), Genres =  { Genre.ROCK, Genre.METAL } },
                    new Album { Id = 18, Title = "What's Going On", Artist = "Marvin Gaye", Label = "Tamla", ReleaseDate = new DateOnly(1971, 5, 21), Genres =  { Genre.SOUL, Genre.RHYTHM_AND_BLUES } },
                    new Album { Id = 19, Title = "Random Access Memories", Artist = "Daft Punk", Label = "Columbia", ReleaseDate = new DateOnly(2013, 5, 17), Genres =  { Genre.ELECTRONIC, Genre.FUNK } },
                    new Album { Id = 20, Title = "Blue", Artist = "Joni Mitchell", Label = "Reprise", ReleaseDate = new DateOnly(1971, 6, 22), Genres =  { Genre.FOLK, Genre.SINGER_SONGWRITER } }
                );
            }
        }
    }
}
