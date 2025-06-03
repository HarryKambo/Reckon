using Microsoft.AspNetCore.Mvc;
using Reckon.Core.Interfaces;
using Reckon.Core.ModelDto;
using Reckon.Infrastructure.ResponseModel;

namespace Reckon.Api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ResultsController : Controller
    {
        private readonly IResultsService _resultsService;
        public ResultsController(IResultsService resultsService)
        {
            _resultsService = resultsService;

        }
        
        [HttpGet()]
        public async Task<ActionResult<ResultsDTO>> GetTextToSearch()
        {
            var result = await _resultsService.GetResultsAsync();
            return Ok(result);
        }
    }
}
