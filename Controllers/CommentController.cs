using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using core_test_api.Database;
using core_test_api.Models;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

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
        public Comment EditComment(int id, Comment item)
        // {
        //     Comment comment = _context.Comments.Where(item => item.id == id).Single<Comment>();
        //     var config = new MapperConfiguration(cfg => cfg.CreateMap<CommentUpdate, Comment>().ForAllMembers(d => d.MapFrom(x => comment)));
        //     var mapper = config.CreateMapper();
        //     mapper.Map<CommentUpdate, Comment>(item);
        //     _context.SaveChanges();
        //     return comment;
        // }
        {
            Comment comment = _context.Comments.Where(item => item.id == id).Single<Comment>();
            comment.content = item.content;
            comment.status = item.status;
            comment.author = item.author;
            _context.SaveChanges();
            return comment;
        }

        [HttpDelete("{id}")]
        public IEnumerable<Comment> DeleteComment(int id)
        {
            Comment comment = _context.Comments.Where(item => item.id == id).Single<Comment>();
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return _context.Comments.ToList();
        }
    }
}
