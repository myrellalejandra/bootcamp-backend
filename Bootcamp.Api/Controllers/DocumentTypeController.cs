﻿using Bootcamp.Queries.DocumentType;
using Microsoft.AspNetCore.Mvc;

namespace Bootcamp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]   
    public class DocumentTypeController : ControllerBase
    {
        private readonly IDocumenTypeQueries _documentTypesQueries;
        public DocumentTypeController(DocumenTypeQueries documentTypeQueries)
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
