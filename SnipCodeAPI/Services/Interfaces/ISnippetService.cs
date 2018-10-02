using SnipCodeAPI.Models;
using System.Collections.Generic;

namespace SnipCodeAPI.Services.Interfaces
{
    public interface ISnippetService
    {
        void Create(Snippet snippet);
        List<Snippet> GetSnippets();
        Snippet GetSnippetByHash(string hash, out Snippet snippet);
        bool DeleteSnippet(string hash);
        bool UpdateSnippet(string hash, Snippet snippet);
    }
}
