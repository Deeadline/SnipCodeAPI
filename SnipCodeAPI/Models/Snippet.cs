using LiteDB;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SnipCodeAPI.Models
{
    public class Snippet
    {
        [BsonId]
        public int Id { get; set; }
        public string Hash { get; set; }
        public string Name { get; set; }
        public User Creator {get;set;}
        public string CreationTime { get; set; }
        public string ExpirationTime { get; set; }
        public List<SnippetFile> Files { get; set; } = new List<SnippetFile>();
    }
}