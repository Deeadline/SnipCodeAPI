using System;
using System.Collections.Generic;

namespace SnipCodeAPI.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Email {get;set;}
        public string Password {get;set;}
        public string Token {get;set;}
        public DateTime CreationTime { get; set; }
        public List<Snippet> Snippets { get; set; } = new List<Snippet>();
    }
}