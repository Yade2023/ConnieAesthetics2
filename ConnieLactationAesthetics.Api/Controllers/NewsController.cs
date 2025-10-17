using Microsoft.AspNetCore.Mvc;

namespace ConnieLactationAesthetics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NewsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetNews()
        {
            // 由於現在使用Facebook Page Plugin，這個API不再需要
            // 但保留以維持向後兼容性
            return Ok(new { 
                message = "新聞現在直接從Facebook Page Plugin顯示",
                note = "請確保已正確配置Facebook頁面URL"
            });
        }
    }
} 