using record_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace record_store.Repositories
{
    public interface IAlbumsRepo
    {
        IEnumerable<Album> GrabAllAlbums();
        Album GrabAlbumById(int id);
        IEnumerable<Album> AddAlbums(IEnumerable<Album> albumsToAdd);
        Album UpdateAlbumById(int id);
        void DeleteAlbumById(int id);
        
    }
    public class AlbumsRepo : IAlbumsRepo
    {
        private RecordStoreDbContext _context;
        public AlbumsRepo(RecordStoreDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Album> AddAlbums(IEnumerable<Album> albumsToAdd)
        {
            _context.AddRange(albumsToAdd);
            _context.SaveChanges();
            return _context.Albums
                .TakeLast(albumsToAdd.ToList().Count)
                .ToList();
        }

        public void DeleteAlbumById(int id)
        {
            throw new NotImplementedException();
        }

        public Album GrabAlbumById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id.Equals(id)) ?? throw new Exception($"No album with id {id} found.");
        }

        public IEnumerable<Album> GrabAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album UpdateAlbumById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
