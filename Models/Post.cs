using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_test_api.Models
{
    public class Post
    {
        public int id {get; set;}
        [Required]
        public string title {get; set;}
        [Required]
        public string content {get; set;}
        public string tags {get; set;}
        public string status {get; set;}
        public string create_time {get; set;}
        public string update_time {get; set;}
        public int user_id {get; set;}
        [ForeignKey("post_id")]
        public ICollection<Comment> comments {get; set;}
    }
}
