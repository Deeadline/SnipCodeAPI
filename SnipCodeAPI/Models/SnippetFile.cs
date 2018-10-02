using System.ComponentModel.DataAnnotations;
using LiteDB;

namespace SnipCodeAPI.Models
{
    public class SnippetFile
    {
        [BsonId]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Extension { get; set; }
        [Required]
        public string Code { get; set; }
    }
}