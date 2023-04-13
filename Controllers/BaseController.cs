using BookHub.Models;
using BookHub.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookHub.API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController<TEntity> : ControllerBase where TEntity : IEntity
    {
        protected readonly IRepository<TEntity> _repository;

        public BaseController(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        //GET: api/controller
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> GetEntities()
        {
            return await _repository.GetEntities().ToListAsync();
        }

        //GET: api/controller/id
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> GetEntity(Guid id)
        {
            var entity = await _repository.GetEntityByID(id);
            if (entity == null)
            {
                return NotFound();
            }

            return entity;
        }

        //PUT: api/controller/id
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEntity(Guid id, TEntity entity)
        {
            var _entity = await _repository.GetEntityByID(id);
            if (_entity is null || id != entity.Id)
            {
                return BadRequest();
            }

            await _repository.UpdateEntity(entity);

            return NoContent();
        }

        //POST: api/controller
        [HttpPost]
        public async Task<ActionResult<TEntity>> PostEntity(TEntity entity)
        {
            var _entity = await _repository.InsertEntity(entity);
            return _entity;
        }

        //DELETE: api/controller/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            var _entity = await _repository.GetEntityByID(id);
            if (_entity == null)
            {
                return NotFound();
            }

            await _repository.DeleteEntity(id);
            return NoContent();
        }
    }
}
