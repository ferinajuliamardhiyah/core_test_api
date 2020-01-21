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
    [Route("post")]

    public class PostController : ControllerBase
    {
        private CoreDbContext _context;

        public PostController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Post> GetAll()
        {
            return _context.Posts.Include("comments").ToList();
        }

        [HttpGet("{id}")]

        public Post GetPost(int id)
        {
            return _context.Posts.Where(item => item.id == id).Include("comments").Single<Post>();
        }

        [HttpPost]
        public Post AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
            return post;
        }

        [HttpPut("{id}")]
        public Post EditPost(int id, Post item)
        {
            Post post = _context.Posts.Where(item => item.id == id).Single<Post>();
            post.title = item.title;
            post.content = item.content;
            post.tags = item.tags;
            post.status = item.status;
            _context.SaveChanges();
            return post;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Post> Deletepost(int id)
        {
            Post post = _context.Posts.Where(item => item.id == id).Single<Post>();
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return _context.Posts.Include("comments").ToList();
        }
    }
}
