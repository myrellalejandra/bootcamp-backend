using Bootcamp.Queries.DocumentType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumentTypeQueries _documentTypesQueries;
        public DocumentTypeController(IDocumentTypeQueries documentTypeQueries)
        {
            _documentTypesQueries = documentTypeQueries;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var result = await _documentTypesQueries.GetAll();
            return Ok(result);
        }

    }
}
