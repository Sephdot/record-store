using Microsoft.AspNetCore.Mvc;
using record_store.Entities;
using record_store.Services;

namespace record_store.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AlbumsController : ControllerBase
    {
        private IAlbumsService _albumsService;
        public AlbumsController(IAlbumsService albumsService)
        {
            _albumsService = albumsService;
        }

        [HttpGet]
        public IActionResult GetAllAlbums()
        {
            return Ok(_albumsService.GrabAllAlbums());
        }
        //public IActionResult GetAlbumById(int id)
        //{
        //    return StatusCode(501);
        //}
        //public IActionResult AddAlbums(IEnumerable<AlbumDTO> albumsToAdd)
        //{
        //    return StatusCode(501);
        //}
        //public IActionResult UpdateAlbumById(int id)
        //{
        //    return StatusCode(501);
        //}
        //public IActionResult DeleteAlbumById(int id)
        //{
        //    return StatusCode(501);
        //}
    }
}
