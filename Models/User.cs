using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace core_test_api.Models
{
    public class User
    {
        public int id {get; set;}
        [Required]
        public string username {get; set;}
        public string password {get; set;}
        public string salt {get; set;}
        public string email {get; set;}
        public string profile {get; set;}
        [ForeignKey("user_id")]
        public List<Post> posts {get; set;}
    }
}