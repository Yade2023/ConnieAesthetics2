using Microsoft.AspNetCore.Mvc;

namespace ConnieLactationAesthetics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TeachersController : ControllerBase
    {
        [HttpGet]
        public IActionResult TeachersGET()
        {
            var teachers = new[]
            {
                new { Id = 1, Name = "康妮老師", Title = "泌乳顧問", Description = "擁有多年臨床經驗，專業親切。" },
                new { Id = 2, Name = "小美護理師", Title = "護理師", Description = "細心照護，協助媽媽身心健康。" }
            };
            return Ok(teachers);
        }
    }
} 