using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileProjectServer.Models;

namespace MobileProjectServer.Controllers
{
    [Route("mobile/[controller]")]
    public class CoordinatesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CoordinatesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var coordinates = _context.Coordinates.ToArray();
            return new JsonResult(coordinates);
        }
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Coordinates coordinates = _context.Coordinates.Find(id);
            return new JsonResult(coordinates);
        }
    }
}
