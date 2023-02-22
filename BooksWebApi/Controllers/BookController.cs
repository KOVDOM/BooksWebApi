using BooksWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BooksWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly bookshopContext _bookContext;

        public BookController(bookshopContext bookContext)
        {
            _bookContext = bookContext;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            try
            {
                return Ok(_bookContext.Books.Include(cx=>cx.GenreId).ToList());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            if (_bookContext.Books == null)
            {
                return NotFound();
            }
            var konyv = await _bookContext.Books.FindAsync(id);
            if (konyv == null)
            {
                return NotFound();
            }
            return konyv;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostKonyv(Book book)
        {
            _bookContext.Books.Add(book);
            await _bookContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBook), book);
        }
    }
}
