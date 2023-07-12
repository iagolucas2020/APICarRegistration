using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarRegistration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Category>> Get()
        {
            var category = _categoryRepository.Get().ToList();
            if (category is null)
                return NotFound();
            return category;
        }

        [HttpGet("{id:int}", Name = "GetCategory")]
        public ActionResult<Category> Get(int id)
        {
            var category = _categoryRepository.GetById(id);
            if (category is null)
                return NotFound();
            return category;
        }

        [HttpPost]
        public ActionResult Post(Category category)
        {
            if (category is null)
                return BadRequest();

            _categoryRepository.Post(category);

            return new CreatedAtRouteResult("GetCategory", new { id = category.Id }, category);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Category category)
        {
            if (id != category.Id)
                return BadRequest();

            _categoryRepository.Put(category);

            return Ok(category);

        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var brand = _categoryRepository.GetById(id);
            if (brand is null)
                return NotFound();

            _categoryRepository.Delete(brand);

            return Ok();

        }
    }
}
