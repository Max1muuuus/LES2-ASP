using Microsoft.AspNetCore.Mvc;
using Les3.Models;

namespace Les3.Controllers
{
    public class UserController : Controller
    {
        readonly Data.AppDbContext context;

        public UserController(Data.AppDbContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.User>> GetUsers()
        {
            var users = context.Users.ToList();
            return Ok(users);
        }

        [HttpGet]
        public IActionResult CreateUser(User obj)
        {
            if (obj == null)
            {
                return BadRequest("User object is null.");
            }
            context.Users.Add(obj);
            context.SaveChanges();
            return Ok(obj);
        }
    }
}
