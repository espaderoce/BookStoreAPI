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
    public class SearchController : ControllerBase
    {

        public readonly BookStoreDBContext _context;

        public SearchController(BookStoreDBContext context)
        {
            this._context = context;
        }


        [HttpGet("{data}")]
        public async Task<ActionResult<IEnumerable<Book>>> SearchBooks(string data)
        {
            //    return await _context.Books.Where 
            var query = from e in _context.Books
                        where EF.Functions.Like(e.Title, "%"+data+"%") || EF.Functions.Like(e.Title, "%" + data + "%")
                        select e;

            var query2 = from b in _context.Books
                         join a in _context.Authors on b.AuthorId equals a.Id
                         where  EF.Functions.Like(b.Title, "%" + data + "%") || EF.Functions.Like(a.Name+' '+a.LastName, "%" + data + "%")
                         orderby a.LastName
                         select b;


            return await query2.ToListAsync();
        }




    }
}
