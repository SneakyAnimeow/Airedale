using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Airedale.Controllers; 

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase {
    [HttpGet]
    [Authorize]
    public string Get() {
        return "This endpoint is secured.";
    }
}