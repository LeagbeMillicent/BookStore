using Books.Domain;
using Books.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            return await _context.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBookById(ActionResult<IEnumerable<Book>> book)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            var Book = await _context.Books.FindAsync();
            if (Book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpPost]

        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBooks), new { id = book.bookId }, book);
        }

        [HttpPut]

        public async Task<IActionResult> PutBook(int id, Book book)
        {
            if (id != book.bookId)
            {
                return BadRequest();
            }
            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool BookAvailable(int id)
        {
            return (_context.Books?.Any(x => x.bookId == id)).GetValueOrDefault();
        }

        [HttpDelete]

        public async Task<IActionResult> DeleteBook(int id)
        {
            if (_context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
