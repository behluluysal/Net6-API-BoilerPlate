using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Net6_API_BoilerPlate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestApiController : ControllerBase
    {
        [HttpGet]
        [Route("test")]
        public ActionResult<string> TestApi()
        {
            return Ok("Api Runnnig...");
        }
    }
}
