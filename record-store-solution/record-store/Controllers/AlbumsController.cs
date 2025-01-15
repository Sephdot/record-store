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

        [HttpPost]
        public IActionResult PostAlbums(IEnumerable<Album> albumsToAdd)
        {
            if (albumsToAdd.ToList().Count == 0)
            {
                return BadRequest("Post request to this endpoint must contain at least one Album.");
            }
            try
            {
                return Ok(_albumsService.AddAlbums(albumsToAdd));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult PutAlbum([FromRoute] int id, [FromBody] Album updatedAlbum)
        {
            if (id <= 0)
            {
                return BadRequest($"Id: {id} is invalid.");
            }
            try
            {
                return Ok(_albumsService.UpdateAlbumById(id, updatedAlbum));
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
        }

        //public IActionResult DeleteAlbumById(int id)
        //{
        //    return StatusCode(501);
        //}
    }
}
