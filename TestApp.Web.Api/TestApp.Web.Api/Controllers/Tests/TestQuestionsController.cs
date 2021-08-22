using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestApp.Services.Tests;

namespace TestApp.Web.Api.Controllers.Tests
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestQuestionsController: ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;
        
        public TestQuestionsController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }
        
        [HttpGet("questions/{testId}")]
        public async Task<IActionResult> GetQuestionsWithAnswersByTaskIdAsync(Guid testId, CancellationToken token)
        {
            try
            {
                return Ok(await _testQuestionService.GetQuestionsWithAnswersByTestIdAsync(testId, token));
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}