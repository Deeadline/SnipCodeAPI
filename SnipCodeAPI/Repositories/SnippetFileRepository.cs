using SnipCodeAPI.Models;
using SnipCodeAPI.Repositories.Interfaces;
using System.Collections.Generic;


namespace SnipCodeAPI.Repositories
{
    public class SnippetFileRepository : ISnippetFileRepository
    {
        private readonly IDataGateway _dataGateway;
        public SnippetFileRepository(IDataGateway dataGateway) => _dataGateway = dataGateway;
        public void DeleteSnippetFile(int snippetFileId) => _dataGateway.RemoveSnippetFile(snippetFileId);
        public SnippetFile GetSnippetFileById(int snippetFileId) => _dataGateway.GetSnippetFileById(snippetFileId);
        public IEnumerable<SnippetFile> GetSnippetFiles() => _dataGateway.GetAllSnippetFiles() ?? new List<SnippetFile>();
        public void InsertSnippetFile(SnippetFile snippetFile) => _dataGateway.InsertSnippetFile(snippetFile);
        public bool UpdateSnippetFile(SnippetFile snippetFile) => _dataGateway.UpdateSnippetFile(snippetFile);
    }
}