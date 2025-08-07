using EvidencePojisteni.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace EvidencePojisteni.API.Controllers
{
    [Route("Policy")]
    [ApiController]
    public class PolicyController(PolicyService service) : ControllerBase
    {




    }
}
