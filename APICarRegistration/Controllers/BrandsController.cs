using APICarRegistration.Context;
using APICarRegistration.Models;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public ActionResult<IEnumerable<Brand>> Get()
        {
            var brands = _brandRepository.Get().ToList();
            if (brands is null)
                return NotFound();
            return brands;
        }

        [HttpGet("{id:int}", Name="GetBrand")]
        public ActionResult<Brand> Get(int id)
        {
            var brand = _brandRepository.GetById(id) ;
            if (brand is null)
                return NotFound();
            return brand;
        }

        [HttpPost]
        public ActionResult Post(Brand brand)
        {
            if (brand is null)
                return BadRequest();

            _brandRepository.Post(brand);

            return new CreatedAtRouteResult("GetBrand", new { id = brand.Id }, brand);
        }

        [HttpPut("{id:int}")]
        public ActionResult Put(int id, Brand brand)
        {
            if (id != brand.Id)
                return BadRequest();

            _brandRepository.Put(brand);

            return Ok(brand);
            
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var brand = _brandRepository.GetById(id);
            if (brand is null)
                return NotFound();

            _brandRepository.Delete(brand);

            return Ok();

        }
    }
}
