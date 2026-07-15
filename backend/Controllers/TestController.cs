using System.Collections.Generic;
using System.Threading.Tasks;
using Homelab.Models;
using Homelab.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Homelab.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;
    private readonly ITestRepository _testRepository;

    public TestController(ILogger<TestController> logger, ITestRepository testRepository)
    {
        _logger = logger;
        _testRepository = testRepository;
    }

    [HttpGet(Name = "Test")]
    public async Task<IActionResult> Get()
    {
        var models = await _testRepository.GetAllAsync();

        return Ok(models);
    }
}
