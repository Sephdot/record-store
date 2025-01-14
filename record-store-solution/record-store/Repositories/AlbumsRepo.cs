﻿using record_store.Entities;

namespace record_store.Repositories
{
    public interface IAlbumsRepo
    {
        IEnumerable<Album> GrabAllAlbums();
        Album GrabAlbumById(int id);
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

        public Album GrabAlbumById(int id)
        {
            throw new NotImplementedException();
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
