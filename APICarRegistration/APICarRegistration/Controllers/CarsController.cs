using APICarRegistration.Models;
using APICarRegistration.Repositories;
using APICarRegistration.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APICarRegistration.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarRepository _carRepository;

        public CarsController(ICarRepository carRepository)
        {
            _carRepository = carRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> Get()
        {
            try
            {
                var cars = await _carRepository.GetAsync();
                if (cars is null)
                    return NotFound();
                return cars.ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpGet("{id:int}", Name = "GetCar")]
        public async Task<ActionResult<Car>> GetById(int id)
        {
            try
            {
                var car = await _carRepository.GetByIdAsync(id);
                if (car is null)
                    return NotFound($"Id: {id} not found!");
                return car;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPost]
        public async Task<ActionResult> Post(Car car)
        {
            try
            {
                if (car is null)
                    return BadRequest("Invalid data!");

                await _carRepository.PostAsync(car);

                return new CreatedAtRouteResult("GetCar", new { id = car.Id }, car);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, Car car)
        {
            try
            {
                if (id != car.Id)
                    return BadRequest("Invalid data!");

                await _carRepository.PutAsync(car);

                return Ok(car);
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
                var car = await _carRepository.GetByIdAsync(id);
                if (car is null)
                    return NotFound($"Id: {id} not found!");

                await _carRepository.Delete(car);

                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "There was a problem handling the request. Contact support!");
            }
        }
    }
}

