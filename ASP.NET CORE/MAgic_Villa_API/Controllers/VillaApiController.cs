using System.Reflection.Metadata.Ecma335;
using MAgic_Villa_API.Models;
using Microsoft.AspNetCore.Mvc;

namespace MAgic_Villa_API.Controllers
{
    //[Route("api/VillaApi")]
    //another way to declare controller route
    [Route("api/[controller]")]
    [ApiController]
    public class VillaApiController : Controller
    {
        [HttpGet]
        public IEnumerable<Villa> GetVillas()
        {
            return new List<Villa>
            {
                new Villa { Id = 1, Name = "Sea View" },
                new Villa { Id = 2, Name = "Sunset Point" }
            };
        }
    }
}
