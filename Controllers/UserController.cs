using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using core_test_api.Database;
using core_test_api.Models;
using Microsoft.EntityFrameworkCore;

namespace core_test_api.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {

        private CoreDbContext _context;

        public UserController(CoreDbContext context, ILogger<UserController> logger)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.Include("posts.comments").ToList();
        }

        [HttpGet("{id}")]

        public User GetUser(int id)
        {
            return _context.Users.Where(item => item.id == id).Include("posts.comments").Single<User>();
        }

        [HttpPost]
        public User AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        [HttpPut("{id}")]
        public User EditUser(int id, User item)
        {
            User user = _context.Users.Where(item => item.id == id).Single<User>();
            user.username = item.username;
            user.password = item.password;
            user.email = item.email;
            user.profile = item.profile;
            _context.SaveChanges();
            return user;
        }

        [HttpDelete("{id}")]
        public IEnumerable<User> DeleteUser(int id)
        {
            User user = _context.Users.Where(item => item.id == id).Single<User>();
            _context.Users.Remove(user);
            _context.SaveChanges();
            return _context.Users.Include("posts.comments").ToList();
        }
    }
}
