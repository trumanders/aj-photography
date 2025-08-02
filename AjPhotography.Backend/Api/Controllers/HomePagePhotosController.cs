using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Common;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomePagePhotosController : ControllerBase
    {
        private readonly Context _db;

        public HomePagePhotosController(Context context)
        {
            _db = context;
        }

        // GET: api/homepagephotos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HomePagePhoto>>> GetAll()
        {
            return await _db.HomePagesPhoto.ToListAsync();
        }

        // GET: api/homepagephotos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HomePagePhoto>> Get(int id)
        {
            var homePagePhoto = await _db.HomePagesPhoto.FindAsync(id);

            return homePagePhoto == null ? NotFound() : Ok(homePagePhoto);
        }

        // PUT: api/homepagephotos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomePagePhoto(int id, HomePagePhoto homePagePhoto)
        {
            if (id != homePagePhoto.Id)
            {
                return BadRequest();
            }

            _db.Entry(homePagePhoto).State = EntityState.Modified;

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomePagePhotoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/homepagephotos
        [HttpPost]
        public async Task<ActionResult<HomePagePhoto>> PostHomePagePhoto(HomePagePhoto homePagePhoto)
        {
            _db.HomePagesPhoto.Add(homePagePhoto);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetHomePagePhoto", new { id = homePagePhoto.Id }, homePagePhoto);
        }

        // DELETE: api/homepagephotos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomePagePhoto(int id)
        {
            var homePagePhoto = await _db.HomePagesPhoto.FindAsync(id);
            if (homePagePhoto == null)
            {
                return NotFound();
            }

            _db.HomePagesPhoto.Remove(homePagePhoto);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool HomePagePhotoExists(int id)
        {
            return _db.HomePagesPhoto.Any(e => e.Id == id);
        }

        // GET: api/homepagephotos/category/portrait/
        [HttpGet("category/{category}")]
        public async Task<ActionResult<IEnumerable<HomePagePhoto>>> GetAllPhotosByCategory(string category)
        {
            if (!Enum.TryParse<HomePagePhotoCategory>(category, true, out var categoryEnum))
                return BadRequest("Invalid category");

            var photosByCategory = await _db.HomePagesPhoto
                .Where(photo => photo.Category == categoryEnum)
                .ToListAsync();

            return photosByCategory;
        }
    }
}
