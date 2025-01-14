using record_store.Entities;
using record_store.Models;

namespace record_store.Services
{
    public interface IAlbumsService
    {
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        IEnumerable<Album> AddAlbums(IEnumerable<AlbumDTO> albumsToAdd);
        Album UpdateAlbumById(int id);
        void DeleteAlbumById(int id);
    }
    public class AlbumsService : IAlbumsService
    {
        private IAlbumsRepo _albumsRepo;
        public AlbumsService(IAlbumsRepo albumsRepo)
        {
            _albumsRepo = albumsRepo;
        }

        public IEnumerable<Album> AddAlbums(IEnumerable<AlbumDTO> albumsToAdd)
        {
            throw new NotImplementedException();
        }

        public void DeleteAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public Album GetAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Album> GetAllAlbums()
        {
            throw new NotImplementedException();
        }

        public Album UpdateAlbumById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
