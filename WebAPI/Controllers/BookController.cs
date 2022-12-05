using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly APIContext context;

        public BookController(APIContext _context)
        {
            context = _context;
            
        }
        
        //This block for checking of the correct working

        //[HttpPost]
        //public JsonResult CreateBooks()
        //{
        //    context.Books.Add(new Book() { Id = 1, Title = "War and piece", Author = "Tolstoy" });
        //    context.Books.Add(new Book() { Id = 2, Title = "Crime and punishment", Author = "Dostoevskiy" });
        //    context.Books.Add(new Book() { Id = 3, Title = "Dead souls", Author = "Gogol" });
        //    context.Books.Add(new Book() { Id = 4, Title = "Quit Don", Author = "Sholohov" });
        //    context.SaveChanges();
        //    return new JsonResult(Ok(context.Books.ToArray()));
        //}

        //Return table entries as if the table indexes started with 1

        [HttpGet]
        public JsonResult GetBooks(int begin, int end)
        {
            var books = context.Books.ToArray();
            if (begin < 0 | end > books.Length)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok(books[(begin-1)..end]));
        }
    }
}
