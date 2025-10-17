using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ConnieLactationAesthetics.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly ILogger<ServicesController> _logger;

        public ServicesController(ILogger<ServicesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetServices()
        {
            try
            {
                _logger.LogInformation("取得服務列表請求");
                
                var services = new[]
                {
                    new ServiceDto 
                    { 
                        Id = 1, 
                        Name = "泌乳諮詢與護理", 
                        Description = "專業泌乳顧問協助媽媽順利哺乳，解決哺乳過程中的各種問題。",
                        Price = "諮詢費：$1,500/小時",
                        Duration = "60-90分鐘",
                        Icon = "🤱"
                    },
                    new ServiceDto 
                    { 
                        Id = 2, 
                        Name = "產後身體護理", 
                        Description = "產後媽媽專屬身體調理與放鬆，幫助恢復身心健康。",
                        Price = "護理費：$2,000/次",
                        Duration = "90-120分鐘",
                        Icon = "💆‍♀️"
                    },
                    new ServiceDto 
                    { 
                        Id = 3, 
                        Name = "美學舒壓按摩", 
                        Description = "舒緩壓力，提升美感與健康，讓媽媽們重拾自信美麗。",
                        Price = "按摩費：$1,800/次",
                        Duration = "60-90分鐘",
                        Icon = "✨"
                    }
                };

                _logger.LogInformation("成功返回 {Count} 項服務", services.Length);
                return Ok(new { success = true, data = services, message = "服務列表載入成功" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "取得服務列表時發生錯誤");
                return StatusCode(500, new { success = false, message = "伺服器內部錯誤，請稍後再試" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetService(int id)
        {
            try
            {
                _logger.LogInformation("取得服務詳情請求，ID: {ServiceId}", id);

                var services = new[]
                {
                    new ServiceDto 
                    { 
                        Id = 1, 
                        Name = "泌乳諮詢與護理", 
                        Description = "專業泌乳顧問協助媽媽順利哺乳，解決哺乳過程中的各種問題。",
                        Price = "諮詢費：$1,500/小時",
                        Duration = "60-90分鐘",
                        Icon = "🤱"
                    },
                    new ServiceDto 
                    { 
                        Id = 2, 
                        Name = "產後身體護理", 
                        Description = "產後媽媽專屬身體調理與放鬆，幫助恢復身心健康。",
                        Price = "護理費：$2,000/次",
                        Duration = "90-120分鐘",
                        Icon = "💆‍♀️"
                    },
                    new ServiceDto 
                    { 
                        Id = 3, 
                        Name = "美學舒壓按摩", 
                        Description = "舒緩壓力，提升美感與健康，讓媽媽們重拾自信美麗。",
                        Price = "按摩費：$1,800/次",
                        Duration = "60-90分鐘",
                        Icon = "✨"
                    }
                };

                var service = services.FirstOrDefault(s => s.Id == id);
                if (service == null)
                {
                    _logger.LogWarning("找不到 ID 為 {ServiceId} 的服務", id);
                    return NotFound(new { success = false, message = "找不到指定的服務" });
                }

                _logger.LogInformation("成功返回服務詳情，ID: {ServiceId}", id);
                return Ok(new { success = true, data = service, message = "服務詳情載入成功" });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "取得服務詳情時發生錯誤，ID: {ServiceId}", id);
                return StatusCode(500, new { success = false, message = "伺服器內部錯誤，請稍後再試" });
            }
        }
    }

    public class ServiceDto
    {
        [Required]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        
        [StringLength(100)]
        public string Price { get; set; } = string.Empty;
        
        [StringLength(50)]
        public string Duration { get; set; } = string.Empty;
        
        [StringLength(10)]
        public string Icon { get; set; } = string.Empty;
    }
} 