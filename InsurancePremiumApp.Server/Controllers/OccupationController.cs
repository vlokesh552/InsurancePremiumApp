using InsuranceApp.Repository;
using Microsoft.AspNetCore.Mvc;
using System;

namespace InsuranceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OccupationController : ControllerBase
    {
        private readonly PremiumService _service;

        public OccupationController(PremiumService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetOccupations()
        {
            try
            {
                var occupations = await _service.GetOccupationsAsync();
                return Ok(occupations.Select(o => new
                {
                    Id = o.Id,
                    Name = o.Name
                    //Rating = o.Rating.RatingName,
                    //Factor = o.Rating.Factor
                }));
            }
            catch (Exception ex)
            {
                // We can Inject the logger service to log the exception
                Console.WriteLine(ex);
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
