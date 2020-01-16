using System.ComponentModel.DataAnnotations;
namespace core_test_api.Models
{
    public class Comment
    {
        public int id {get; set;}
        [Required]
        public string content {get; set;}
        public string status {get; set;}
        public string create_time {get; set;}
        [Required]
        public string author {get; set;}
        public string email {get; set;}
        public string url {get; set;}
        [Required]
        public int post_id {get; set;}
    }
}
