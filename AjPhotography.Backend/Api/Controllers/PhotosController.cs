using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using Persistence.Entities;
using Common;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
        private readonly Context _db;

        public PhotosController(Context context)
        {
            _db = context;
        }

        // GET: api/photos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAll()
        {
            return await _db.Photo.ToListAsync();
        }

        // GET: api/photos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Photo>> Get(int id)
        {
            var homePagePhoto = await _db.Photo.FindAsync(id);

            return homePagePhoto == null ? NotFound() : Ok(homePagePhoto);
        }

        // PUT: api/photos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHomePagePhoto(int id, Photo homePagePhoto)
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

        // POST: api/photos
        [HttpPost]
        public async Task<ActionResult<Photo>> PostHomePagePhoto(Photo homePagePhoto)
        {
            _db.Photo.Add(homePagePhoto);
            await _db.SaveChangesAsync();

            return CreatedAtAction("GetHomePagePhoto", new { id = homePagePhoto.Id }, homePagePhoto);
        }

        // DELETE: api/photos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHomePagePhoto(int id)
        {
            var homePagePhoto = await _db.Photo.FindAsync(id);
            if (homePagePhoto == null)
            {
                return NotFound();
            }

            _db.Photo.Remove(homePagePhoto);
            await _db.SaveChangesAsync();

            return NoContent();
        }

        private bool HomePagePhotoExists(int id)
        {
            return _db.Photo.Any(e => e.Id == id);
        }

        // GET: api/photos/pagecategory/portrait/
        [HttpGet("pageCategory/{pageCategory}")]
        public async Task<ActionResult<IEnumerable<Photo>>> GetAllPhotosByPageCategory(string pageCategory)
        {
            if (!Enum.TryParse<PageCategory>(pageCategory, true, out var pageCategoryEnum))
                return BadRequest("Invalid page category");

            var photosByPageCategory = await _db.Photo
                .Where(photo => photo.PageCategory == pageCategoryEnum)
                .ToListAsync();

            return photosByPageCategory;    
        }
    }
}
