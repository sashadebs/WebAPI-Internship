using EFApplication.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;
        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }


        [HttpPost("Login")]
        public ActionResult<Users> Login(Users user)
        {
            var uDB = _userRepo.GetUser(user);
            if (uDB == null)
            {
                ModelState.AddModelError("error", "User not found");
                return NotFound(ModelState);
            }
               
            if (user.password.Equals(uDB.password))
            {
                return Ok(uDB);
            }

            ModelState.AddModelError("error", "Wrong Password");
            return BadRequest(ModelState);
        }
    }
}
