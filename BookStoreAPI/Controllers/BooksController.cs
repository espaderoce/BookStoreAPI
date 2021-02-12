using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAPI.Context;
using BookStoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public readonly BookStoreDBContext _context;
        public BooksController(BookStoreDBContext context)
        {
            this._context = context;

        }


        //this endpoint will be to get all Books
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Author>>> GetBooks()
        {
            // return await _context.Books.ToListAsync();
            return await _context.Authors.Where(x => x.Id == 1).Include(x => x.Book).ToListAsync();
        }

        [HttpGet("{id}")]  //this endpoint will be to get one Book
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var data = await _context.Books.FindAsync(id);
            if (data == null)
            {
                return NotFound();
            }

            return data;
        }


        [HttpPost]
        public async Task<IActionResult> PostBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, Book book)
        {
          
            if (id!=book.Id)
            {
                return BadRequest();
            }

            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            
            return NoContent();


        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return NoContent();
        }











    }
}
