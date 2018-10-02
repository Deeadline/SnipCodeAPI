using SnipCodeAPI.Models;
using System.Collections.Generic;

namespace SnipCodeAPI.Repositories.Interfaces
{
    public interface ISnippetFileRepository
    {
        IEnumerable<SnippetFile> GetSnippetFiles();
        SnippetFile GetSnippetFileById(int snippetFileId);
        void InsertSnippetFile(SnippetFile snippetFile);
        void DeleteSnippetFile(int snippetFileId);
        bool UpdateSnippetFile(SnippetFile snippetFile);
    }
}
