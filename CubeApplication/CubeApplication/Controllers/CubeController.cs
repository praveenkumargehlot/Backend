using CubeApplication.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CubeApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CubeController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CubeController(DatabaseContext context)
        {
            _context = context;
        }
        #region Get
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cube>>> GetCubes()
        {
            return await _context.Cube.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cube>> GetCube(int id)
        {
            var cube = await _context.Cube.FindAsync(id);
            if (cube == null)
            {
                return NotFound();
            }
            return cube;
        }
        #endregion Get

        #region Post
        [HttpPost]
        public async Task<ActionResult<Cube>> PostCube(Cube cube)
        {
            _context.Cube.Add(cube);
            await _context.SaveChangesAsync();
            return Ok(cube);
        }
        #endregion Post

        #region Put
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCube(int id, Cube cube)
        {
            if (id != cube.Id)
            {
                return BadRequest();
            }

            _context.Cube.Update(cube);
            await _context.SaveChangesAsync();

            return Ok(cube);
        }

        #endregion Put

        #region Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCube(int id)
        {
            var cube = await _context.Cube.FindAsync(id);
            if (cube == null)
            {
                return NotFound();
            }

            _context.Cube.Remove(cube);
            await _context.SaveChangesAsync();

            return Ok(cube);
        }
        #endregion Delete
    }
}
