using SnipCodeAPI.Models;
using SnipCodeAPI.Repositories.Interfaces;
using System.Collections.Generic;


namespace SnipCodeAPI.Repositories
{
    public class SnippetRepository : ISnippetRepository
    {
        private readonly IDataGateway _dataGateway;
        public SnippetRepository(IDataGateway dataGateway) => _dataGateway = dataGateway;
        public void DeleteSnippet(int snippetId) => _dataGateway.RemoveSnippet(snippetId);
        public Snippet GetSnippetByHash(string hash) => _dataGateway.GetSnippetByHash(hash);
        public IEnumerable<Snippet> GetSnippets() => _dataGateway.GetAllSnippets() ?? new List<Snippet>();
        public void InsertSnippet(Snippet snippet) => _dataGateway.InsertSnippet(snippet);
        public bool UpdateSnippet(Snippet snippet) => _dataGateway.UpdateSnippet(snippet);
    }
}