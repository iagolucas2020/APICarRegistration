using APICarRegistration.Models;
using APICarRegistration.Repositories;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarRegistration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ModelsController : ControllerBase
    {
        private readonly IModelRepository _modelCategory;

        public ModelsController(IModelRepository modelCategory)
        {
            _modelCategory = modelCategory;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Model>>> Get()
        {
            try
            {
                var model = await _modelCategory.GetAsync();
                if (model is null)
                    return NotFound();
                return model.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("models")]
        public async Task<ActionResult<IEnumerable<Model>>> GetModelWithCarsAsync()
        {
            try
            {
                var model = await _modelCategory.GetModelWithCarsAsync();
                if (model is null)
                    return NotFound();
                return model.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }

        [HttpGet("{id:int}", Name = "GetModel")]
        public async Task<ActionResult<Model>> GetById(int id)
        {
            try
            {
                var model = await _modelCategory.GetByIdAsync(id);
                if (model is null)
                    return NotFound($"Id: {id} not found!");
                return model;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Model model)
        {
            try
            {
                if (model is null)
                    return BadRequest("Invalid data!");

                await _modelCategory.PostAsync(model);

                return new CreatedAtRouteResult("GetModel", new { id = model.Id }, model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Model model)
        {
            try
            {
                if (id != model.Id)
                    return BadRequest("Invalid data!");

                await _modelCategory.PutAsync(model);

                return Ok(model);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var model = await _modelCategory.GetByIdAsync(id);
                if (model is null)
                    return NotFound($"Id: {id} not found!");

                await _modelCategory.Delete(model);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
