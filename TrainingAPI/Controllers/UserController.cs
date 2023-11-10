using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainingAPI.Models;

namespace TrainingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly TrainingContext _context;

        public UserController(TrainingContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult GetAllUser ()
        {
            List<User> users = new List<User>();
            users = _context.Users.ToList();
            return Ok(users);
        }
    }
}
