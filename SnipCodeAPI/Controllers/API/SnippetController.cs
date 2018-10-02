using Microsoft.AspNetCore.Mvc;
using SnipCodeAPI.Models;
using SnipCodeAPI.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace SnipCodeAPI.Controllers.API
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SnippetController : ControllerBase
    {
        private readonly ISnippetService _snippetService;

        public SnippetController(ISnippetService snippetService) => _snippetService = snippetService;

        /// <summary>
        /// Get all snippets 
        /// </summary>
        /// <response code="200">Return list of Snippets</response>
        /// <response code="204">If list is empty</response>
        [HttpGet(Name = "GetSnippets")]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        public ActionResult<List<Snippet>> GetAllSnippets()
        {
            var snippets = _snippetService.GetSnippets();
            if (snippets.Count == 0)
                return NoContent();
            return Ok(snippets);
        }

        /// <summary>
        /// Get a specified Snippet
        /// </summary>
        /// <param name="hash"></param>
        /// <response code="200">Return specified Snippet</response>
        /// <response code="404">If snippet doesn't exist with specified hash</response>
        [HttpGet("{hash}", Name = "GetSnippet")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public ActionResult<Snippet> GetSnippet(string hash)
        {
            if (_snippetService.GetSnippetByHash(hash, out var snippet) == null)
                return NotFound(hash);

            return snippet;
        }

        /// <summary>
        /// Create new snippet with provided snippetFiles content
        /// </summary>
        /// <param name="snippet"></param>
        /// <response code="201">Return the url to newly Snippet</response>
        /// <response code="400">If model doesn't contain required fields</response>
        [HttpPost(Name = "CreateSnippet")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult CreateSnippet(Snippet snippet)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            _snippetService.Create(snippet);
            return new JsonResult(new {status = HttpStatusCode.Created, url = GenerateUrl(Request, snippet.Hash)});
        }

        /// <summary>
        /// Update specific Snippet
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="snippet"></param>
        /// <response code="200">Return updated snippet</response>
        /// <response code="404">Snippet not found in collection with specified hash code</response>
        [HttpPut("{hash}", Name = "UpdateSnippet")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public ActionResult<Snippet> UpdateSnippet(string hash, Snippet snippet)
        {
            if (!_snippetService.UpdateSnippet(hash, snippet))
                return NotFound(hash);
            return Ok(snippet);
        }

        /// <summary>
        /// Delete a specific Snippet
        /// </summary>
        /// <param name="hash"></param>
        /// <response code="204">Snippet has been removed</response>
        /// <response code="404">Snippet not found in collection with specified hash code</response>
        [HttpDelete("{hash}", Name = "DeleteSnippet")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public IActionResult DeleteSnippet(string hash)
        {
            if (!_snippetService.DeleteSnippet(hash))
                return NotFound(hash);
            return NoContent();
        }


        private static string GenerateUrl(HttpRequest request, string hash)
        {
            return $"{request.Host}{request.Path.ToUriComponent()}/{hash}";
        }
    }
}
