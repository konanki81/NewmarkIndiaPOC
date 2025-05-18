using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewmarkIndia.BusinessLogic.Classes;
using NewmarkIndia.BusinessLogic.Interfaces;

namespace NewmarkIndiaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewmarkIndiaBlobController : ControllerBase
    {
        private readonly IBlobInfo _blobInfo;
        private readonly ILogger<NewmarkIndiaBlobController> _logger;
        public NewmarkIndiaBlobController(IBlobInfo blobInfo, ILogger<NewmarkIndiaBlobController> logger)
        {
            _blobInfo = blobInfo;
            _logger = logger;
        }
        [HttpGet("GetBlobResponse/v1")]
        [ProducesResponseType(typeof(IEnumerable<BlobReponse>), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBlobResponseAsync()
        {
            _logger.LogInformation("GetBlobResponseAsync started");


            try
            {
               return Ok( await _blobInfo.GetBlobInfoAsync());


            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }

    }
}
