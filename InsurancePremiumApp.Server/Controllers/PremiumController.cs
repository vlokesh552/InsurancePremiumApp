using InsuranceApp.Models;
using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PremiumController : ControllerBase
    {
        private readonly PremiumService _service;

        public PremiumController(PremiumService service)
        {
            _service = service;
        }

        [HttpPost("calculate")]
        public async Task<IActionResult> Calculate(PremiumRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var premium = await _service.CalculatePremiumAsync(request);
                return Ok(new PremiumResponse
                {
                    MonthlyPremium = premium,
                    OccupationId = request.OccupationId
                });
            }
            catch (Exception ex)
            {
                //We can Inject the logger service to log the exception
                Console.WriteLine(ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
