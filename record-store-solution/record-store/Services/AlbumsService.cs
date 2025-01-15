using record_store.Entities;
using record_store.Repositories;

namespace record_store.Services
{
    public interface IAlbumsService
    {
        IEnumerable<Album> GrabAllAlbums();
        Album GrabAlbumById(int id);
        IEnumerable<Album> AddAlbums(IEnumerable<Album> albumsToAdd);
        Album UpdateAlbumById(int id, Album updatedAlbum);
        void DeleteAlbumById(int id);
    }
    public class AlbumsService : IAlbumsService
    {
        private IAlbumsRepo _albumsRepo;
        public AlbumsService(IAlbumsRepo albumsRepo)
        {
            _albumsRepo = albumsRepo;
        }

        public IEnumerable<Album> AddAlbums(IEnumerable<Album> albumsToAdd)
        {
            return _albumsRepo.AddAlbums(albumsToAdd);
        }

        public void DeleteAlbumById(int id)
        {
            _albumsRepo.DeleteAlbumById(id);
        }

        public Album GrabAlbumById(int id)
        {
            return _albumsRepo.GrabAlbumById(id);
        }

        public IEnumerable<Album> GrabAllAlbums()
        {
            return _albumsRepo.GrabAllAlbums();
        }

        public Album UpdateAlbumById(int id, Album updatedAlbum)
        {
            return _albumsRepo.UpdateAlbumById(id, updatedAlbum);
        }
    }
}
