using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
namespace WebAPI
{
    public class APIContext:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public APIContext(DbContextOptions<APIContext> options) : base(options)
        {

        }
    }
}
