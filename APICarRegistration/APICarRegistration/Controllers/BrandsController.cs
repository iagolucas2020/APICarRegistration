using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace APICarRegistration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Brand>>> Get()
        {
            try
            {
                var brands = await _brandRepository.GetAsync();
                if (brands is null)
                    return NotFound();
                return brands.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("{id:int}", Name = "GetBrand")]
        public async Task<ActionResult<Brand>> GetById(int id)
        {
            try
            {
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand is null)
                    return NotFound($"Id: {id} not found!");
                return brand;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Brand brand)
        {
            try
            {
                if (brand is null)
                    return BadRequest("Invalid data!");

                await _brandRepository.PostAsync(brand);

                return new CreatedAtRouteResult("GetBrand", new { id = brand.Id }, brand);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Brand brand)
        {
            try
            {
                if (id != brand.Id)
                    return BadRequest("Invalid data!");

                await _brandRepository.PutAsync(brand);

                return Ok(brand);
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
                var brand = await _brandRepository.GetByIdAsync(id);
                if (brand is null)
                    return NotFound($"Id: {id} not found!");

                await _brandRepository.Delete(brand);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}
