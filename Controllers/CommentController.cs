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
    [Route("comment")]
    public class CommentController : ControllerBase
    {
        private CoreDbContext _context;

        public CommentController(CoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Comment> GetAll()
        {
            return _context.Comments.ToList();
        }

        [HttpGet("{id}")]

        public Comment GetComment(int id)
        {
            return _context.Comments.Where(item => item.id == id).Single<Comment>();
        }

        [HttpPost]
        public Comment AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return comment;
        }

        [HttpPut("{id}")]
        public Comment EditPost(int id, Comment item)
        {
            Comment comment = _context.Comments.Where(item => item.id == id).Single<Comment>();
            comment.content = item.content;
            comment.status = item.status;
            comment.create_time = item.create_time;
            comment.author = item.author;
            comment.email = item.email;
            comment.url = item.url;
            comment.post_id = item.post_id;
            _context.SaveChanges();
            return comment;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Comment> Deletepost(int id)
        {
            Comment comment = _context.Comments.Where(item => item.id == id).Single<Comment>();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return _context.Comments.ToList();
        }
    }
}
