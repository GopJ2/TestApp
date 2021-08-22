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
    public class TestQuestionsController: ControllerBase
    {
        private readonly ITestQuestionService _testQuestionService;
        
        public TestQuestionsController(ITestQuestionService testQuestionService)
        {
            _testQuestionService = testQuestionService;
        }
        
        [HttpGet("questions/{testId}")]
        [Authorize]
        public async Task<IActionResult> GetQuestionsWithAnswersByTaskIdAsync(string testId, CancellationToken token)
        {
            try
            {
                var result = await _testQuestionService.GetQuestionsWithAnswersByTestIdAsync(testId, token);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}