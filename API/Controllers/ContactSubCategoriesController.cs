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
    public class ContactSubCategoriesController : ControllerBase
    {
        private readonly ContactsDbContext _context;
        private readonly IMapper _mapper;

        public ContactSubCategoriesController(ContactsDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/ContactSubCategories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ContactSubCategoryGetDto>>> GetContactSubCategories()
        {
            if (_context.ContactSubCategories == null)
            {
                return NotFound();
            }

            var result = await _context.ContactSubCategories.ToListAsync();
            var contactSubCategories = _mapper.Map<List<ContactSubCategoryGetDto>>(result);

            return contactSubCategories;
        }

        // GET: api/ContactSubCategories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ContactSubCategoryGetDto>> GetContactSubCategory(uint id)
        {
            if (_context.ContactSubCategories == null)
            {
                return NotFound();
            }
            var contactSubCategory = await _context.ContactSubCategories.FindAsync(id);

            if (contactSubCategory == null)
            {
                return NotFound();
            }

            var contactSubCategoryGetDto = _mapper.Map<ContactSubCategoryGetDto>(contactSubCategory);

            return contactSubCategoryGetDto;
        }

        // PUT: api/ContactSubCategories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutContactSubCategory(uint id, ContactSubCategoryCreateDto contactSubCategoryCreateDto)
        {
            var contactSubCategory = _mapper.Map<ContactSubCategory>(contactSubCategoryCreateDto);
            contactSubCategory.Id = id;

            _context.Entry(contactSubCategory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactSubCategoryExists(id))
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

        // POST: api/ContactSubCategories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ContactSubCategoryGetDto>> PostContactSubCategory(ContactSubCategoryCreateDto contactSubCategoryCreateDto)
        {
            if (_context.ContactSubCategories == null)
            {
                return Problem("Entity set 'ContactsDbContext.ContactSubCategories'  is null.");
            }

            var contactSubCategory = _mapper.Map<ContactSubCategory>(contactSubCategoryCreateDto);

            _context.ContactSubCategories.Add(contactSubCategory);
            await _context.SaveChangesAsync();

            var contactSubCategoryGetDto = _mapper.Map<ContactSubCategoryGetDto>(contactSubCategory);

            return CreatedAtAction("GetContactSubCategory", new { id = contactSubCategoryGetDto.Id }, contactSubCategoryGetDto);
        }

        // DELETE: api/ContactSubCategories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContactSubCategory(uint id)
        {
            if (_context.ContactSubCategories == null)
            {
                return NotFound();
            }
            var contactSubCategory = await _context.ContactSubCategories.FindAsync(id);
            if (contactSubCategory == null)
            {
                return NotFound();
            }

            _context.ContactSubCategories.Remove(contactSubCategory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ContactSubCategoryExists(uint id)
        {
            return (_context.ContactSubCategories?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
