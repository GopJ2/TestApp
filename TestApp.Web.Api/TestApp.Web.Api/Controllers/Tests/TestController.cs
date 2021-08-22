using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services.Tests;
using TestApp.Web.Api.Helpers;

namespace TestApp.Web.Api.Controllers.Tests
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private ITestService _testsService;

        public TestController(ITestService testService)
        {
            _testsService = testService;
        }
        
        [HttpGet("tests")]
        [Authorize]
        public async Task<IActionResult> GetTasksByUserId(CancellationToken token)
        {
            try
            {
                var userId = HttpContext.GetUserId();
                var tests = await _testsService.GetTestsByUserIdAsync(userId, token);
                
                return Ok(tests);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}