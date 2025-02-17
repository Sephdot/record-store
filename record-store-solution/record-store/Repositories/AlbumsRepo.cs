﻿using record_store.Entities;
using Microsoft.EntityFrameworkCore;

namespace record_store.Repositories
{
    public interface IAlbumsRepo
    {
        IEnumerable<Album> GrabAllAlbums();
        Album GrabAlbumById(int id);
        IEnumerable<Album> AddAlbums(IEnumerable<Album> albumsToAdd);
        Album UpdateAlbumById(int id, Album updatedAlbum);
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

            var x = _context.Albums
                .ToList()
                .TakeLast(albumsToAdd.ToList().Count);
            return x;
        }

        public void DeleteAlbumById(int id)
        {
            Album albumToDelete = _context.Albums.FirstOrDefault(a => a.Id.Equals(id)) 
                ?? throw new Exception($"No album with id {id} found.");

            _context.Remove(albumToDelete);
            _context.SaveChanges();
        }

        public Album GrabAlbumById(int id)
        {
            return _context.Albums.FirstOrDefault(a => a.Id.Equals(id)) 
                ?? throw new Exception($"No album with id {id} found.");
        }

        public IEnumerable<Album> GrabAllAlbums()
        {
            return _context.Albums.ToList();
        }

        public Album UpdateAlbumById(int id, Album updatedAlbum)
        {
            Album albumToChange = _context.Albums.FirstOrDefault(a => a.Id.Equals(id)) 
                ?? throw new Exception($"No album with id {id} found.");
            updatedAlbum.Id = id;
            albumToChange = updatedAlbum;
            _context.SaveChanges();
            return albumToChange;
        }
    }
}
