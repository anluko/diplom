using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MobileProjectServer.Models;

namespace MobileProjectServer.Controllers
{
    [Route("mobile/[controller]")]
    public class FriendsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public FriendsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult Get()
        {
            var friends = _context.Friends.ToArray();

            return new JsonResult(friends);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Friends friends = _context.Friends.Find(id);

            return new JsonResult(friends);
        }
        [HttpPost]
        public void Post([FromBody] Friends friends)
        {
            Friends newFriend = new Friends();
            newFriend.FirstUsersId = friends.FirstUsersId;
            newFriend.SecondUsersId = friends.SecondUsersId;
            newFriend.Friendship_Type = friends.Friendship_Type;

            _context.Friends.Add(newFriend); //Insert
            _context.SaveChanges();
        }
        [HttpPut("{id}")]
        public void Put(int id)
        {
            Friends putFriend = _context.Friends.Find(id);
            putFriend.Friendship_Type = "В друзьях";

            _context.SaveChanges();

            Friends newFriend = new Friends();
            newFriend.FirstUsersId = putFriend.SecondUsersId;
            newFriend.SecondUsersId = putFriend.FirstUsersId;
            newFriend.Friendship_Type = "В друзьях";

            _context.Friends.Add(newFriend); //Insert
            _context.SaveChanges();
        }
    }
}
