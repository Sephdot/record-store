using record_store.Entities;

namespace record_store.Models
{
    public interface IAlbumsRepo
    {
        IEnumerable<Album> GetAllAlbums();
        Album GetAlbumById(int id);
        IEnumerable<Album> AddAlbums(IEnumerable<AlbumDTO> albumsToAdd);
        Album UpdateAlbumById(int id);
        void DeleteAlbumById(int id);
        
    }
    public class AlbumsRepo : IAlbumsRepo
    {
        private RecordStoreDbContext _context = new();
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
