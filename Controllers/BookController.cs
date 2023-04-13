using BookHub.Models;
using BookHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Controllers
{
    public class BookController : BaseController<Book>
    {
        public BookController(IRepository<Book> repository) : base(repository) { }

        // GET: api/Book/ByCategoryId/id
        [HttpGet("ByCategoryId/{categoryId}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksByCategoryId(Guid categoryId)
        {
            return await _repository.GetEntities().Where(b => b.CategoryId == categoryId).ToListAsync();
        }
    }
}
