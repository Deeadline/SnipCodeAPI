using System;
using System.Collections.Generic;

namespace SnipCodeAPI.Models
{
  public class User
  {
    public string Email {get;set;}
    public string Password {get;set;}
    public DateTime CreationTime {get;set;}
    public List<Snippet> Snippets {get;set;}
  }
}