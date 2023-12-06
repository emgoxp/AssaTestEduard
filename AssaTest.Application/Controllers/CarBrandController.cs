
using AssaTest.Domain; 
using AssaTest.Infrastruture.Contexts; 
using Microsoft.AspNetCore.Mvc; 

namespace AssaTest.Application.Controllers
{
    // Controller attributes
    [ApiController] // Indicates that this controller is an API controller
    [Route("[controller]")] // Defines the base route for actions in this controller
    public class CarBrandController : ControllerBase // Defines the controller class inheriting from ControllerBase
    {
        private readonly AppAssaContext _assaContext; // Private variable for the database context

        // Constructor for the controller receiving the database context
        public CarBrandController(AppAssaContext context)
        {
            _assaContext = context; 
        }

        // Action method handling HTTP GET requests at the controller's base route
        [HttpGet(Name = "GetCarBrand")]
        public IEnumerable<CarBrand> Get()
        {
            return _assaContext.CarBrands.ToList(); // Returns a list of car brands from the database
        }
    }
}
