using SnipCodeAPI.Models;
using System.Collections.Generic;

namespace SnipCodeAPI.Repositories.Interfaces
{
    public interface ISnippetRepository
    {
        IEnumerable<Snippet> GetSnippets();
        Snippet GetSnippetByHash(string hash);
        void InsertSnippet(Snippet snippet);
        void DeleteSnippet(int snippetId);
        bool UpdateSnippet(Snippet snippet);
    }
}
