using BookHub.API.Controllers;
using BookHub.Models;
using BookHub.Repositories;

namespace BookHub.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        public CategoryController(IRepository<Category> repository) : base(repository) { }
    }
}
