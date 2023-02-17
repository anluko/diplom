using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MobileProjectServer.Models;
using System.Data;

namespace MobileProjectServer.Controllers
{
    [Route("mobile/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;
        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var users = _context.Users.ToArray();
            return new JsonResult(users);
        }
        // GET api/values/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Users user = _context.Users.Find(id);
            return new JsonResult(user);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Users user)
        {
            Users newuser = new Users();
            newuser.Login = user.Login;
            newuser.Nickname = user.Nickname;
            newuser.Password = user.Password;
            newuser.Phone_Number = user.Phone_Number;
            newuser.Birthdate = user.Birthdate;

            _context.Users.Add(newuser); //Insert
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users user)
        {
            Users putUser = _context.Users.Find(id);
            putUser.Nickname = user.Nickname;
            putUser.Login = user.Login;

            _context.SaveChanges();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Users user = _context.Users.Find(id);
            _context.Users.Remove(user);

            _context.SaveChanges();
        }
    }
}