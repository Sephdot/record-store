using Moq;
using record_store.Repositories;
using record_store.Services;
using record_store.Entities;

namespace record_store.tests.AlbumsTests
{
    public class Service
    {

        private Mock<IAlbumsRepo> _albumsRepoMock;
        private AlbumsService _albumsService;
        private List<Album> _albums;
        [SetUp]
        public void Setup()
        {
            _albumsRepoMock = new();
            _albumsService = new(_albumsRepoMock.Object);
            _albums = new()
            {
                new Album { Id = 1, Title = "Thriller", Artist = "Michael Jackson", Label = "Epic", ReleaseDate = new DateOnly(1982, 11, 30), Genres =  { Genre.POP, Genre.RHYTHM_AND_BLUES } },
                new Album { Id = 2, Title = "Back in Black", Artist = "AC/DC", Label = "Atlantic", ReleaseDate = new DateOnly(1980, 7, 25), Genres =  { Genre.ROCK } },
                new Album { Id = 3, Title = "The Dark Side of the Moon", Artist = "Pink Floyd", Label = "Harvest", ReleaseDate = new DateOnly(1973, 3, 1), Genres =  { Genre.ROCK, Genre.PROGRESSIVE_ROCK } },
                new Album { Id = 4, Title = "21", Artist = "Adele", Label = "XL", ReleaseDate = new DateOnly(2011, 1, 24), Genres =  { Genre.POP, Genre.SOUL } },
                new Album { Id = 5, Title = "The Eminem Show", Artist = "Eminem", Label = "Aftermath", ReleaseDate = new DateOnly(2002, 5, 26), Genres =  { Genre.RAP, Genre.HIP_HOP } },
                new Album { Id = 6, Title = "Rumours", Artist = "Fleetwood Mac", Label = "Warner Bros.", ReleaseDate = new DateOnly(1977, 2, 4), Genres =  { Genre.ROCK, Genre.POP } },
                new Album { Id = 7, Title = "Abbey Road", Artist = "The Beatles", Label = "Apple", ReleaseDate = new DateOnly(1969, 9, 26), Genres =  { Genre.ROCK } }
            };
        }

        [Test]
        public void GrabAllAlbums_InvokesCorrectMethodOnce()
        {
            _albumsService.GrabAllAlbums();

            _albumsRepoMock.Verify(r => r.GrabAllAlbums(), Times.Once);
        }

        [Test]
        public void GrabAllAlbums_ReturnsExpected_WhenRepoReturnsPopulatedList()
        {
            // arrange
            var expected = _albums;
            _albumsRepoMock.Setup(r => r.GrabAllAlbums()).Returns(_albums);

            // act
            var result = _albumsService.GrabAllAlbums();

            // assert

            Assert.That(result, Is.EquivalentTo(expected));
        }

        [Test]
        public void GrabAllAlbums_ReturnsExpected_WhenRepoReturnsEmptyList()
        {
            // arrange
            var expected = new List<Album>();
            _albumsRepoMock.Setup(r => r.GrabAllAlbums()).Returns(new List<Album>());

            // act
            var result = _albumsService.GrabAllAlbums();

            // assert

            Assert.That(result, Is.EquivalentTo(expected));
        }
    }
}