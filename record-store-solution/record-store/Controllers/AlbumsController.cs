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

        [HttpGet("{id}")]
        public IActionResult GetAlbumById(int id)
        {
            if (id <= 0)
            {
                return BadRequest($"Id: {id} is invalid.");
            }
            try
            {
                return Ok(_albumsService.GrabAlbumById(id));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

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
