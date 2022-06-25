using API.Data;
using API.Dtos;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ContactsDbContext _context;
        private readonly IMapper _mapper;

        public UsersController(ContactsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserGetDto>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var result = await _context.Users.ToListAsync();

            foreach (var user in result)
            {
                await _context.Entry(user).Collection(u => u.Contacts).LoadAsync();
            }

            var usersGetDto = _mapper.Map<List<UserGetDto>>(result);

            return usersGetDto;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserGetDto>> GetUser(uint id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            await _context.Entry(user).Collection(u => u.Contacts).LoadAsync();

            if (user == null)
            {
                return NotFound();
            }

            var userGetDto = _mapper.Map<UserGetDto>(user);

            return userGetDto;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(uint id, UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            user.Id = id;

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UserGetDto>> PostUser(UserCreateDto userCreateDto)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'ContactsDbContext.Users'  is null.");
            }

            var user = _mapper.Map<User>(userCreateDto);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var userGetDto = _mapper.Map<UserGetDto>(user);

            return CreatedAtAction("GetUser", new { id = userGetDto.Id }, userGetDto);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(uint id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(uint id)
        {
            return (_context.Users?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
