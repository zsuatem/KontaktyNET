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
    public class ContactCategoriesController : ControllerBase
    {
        private readonly ContactsDbContext _context;
        private readonly IMapper _mapper;

        public ContactCategoriesController(ContactsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ContactCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactCategoryGetDto>>> GetContactCategories()
        {
            if (_context.ContactCategories == null)
            {
                return NotFound();
            }

            var result = await _context.ContactCategories.ToListAsync();
            var contactCategoriesGetDto = _mapper.Map<List<ContactCategoryGetDto>>(result);

            return contactCategoriesGetDto;
        }

        // GET: api/ContactCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactCategoryGetDto>> GetContactCategory(uint id)
        {
            if (_context.ContactCategories == null)
            {
                return NotFound();
            }
            var contactCategory = await _context.ContactCategories.FindAsync(id);

            if (contactCategory == null)
            {
                return NotFound();
            }

            var contactCategoryGetDto = _mapper.Map<ContactCategoryGetDto>(contactCategory);

            return contactCategoryGetDto;
        }

        // PUT: api/ContactCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactCategory(uint id, ContactCategoryCreateDto contactCategoryCreateDto)
        {
            var contactCategory = _mapper.Map<ContactCategory>(contactCategoryCreateDto);
            contactCategory.Id = id;

            _context.Entry(contactCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactCategoryExists(id))
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

        // POST: api/ContactCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactCategoryGetDto>> PostContactCategory(ContactCategoryCreateDto contactCategoryCreateDto)
        {
            if (_context.ContactCategories == null)
            {
                return Problem("Entity set 'ContactsDbContext.ContactCategories'  is null.");
            }

            var contactCategory = _mapper.Map<ContactCategory>(contactCategoryCreateDto);

            _context.ContactCategories.Add(contactCategory);
            await _context.SaveChangesAsync();

            var contactCategoryGetDto = _mapper.Map<ContactCategoryGetDto>(contactCategory);

            return CreatedAtAction("GetContactCategory", new { id = contactCategoryGetDto.Id }, contactCategoryGetDto);
        }

        // DELETE: api/ContactCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactCategory(uint id)
        {
            if (_context.ContactCategories == null)
            {
                return NotFound();
            }
            var contactCategory = await _context.ContactCategories.FindAsync(id);
            if (contactCategory == null)
            {
                return NotFound();
            }

            _context.ContactCategories.Remove(contactCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactCategoryExists(uint id)
        {
            return (_context.ContactCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
