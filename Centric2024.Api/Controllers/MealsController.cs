using Centric2024.Core;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MealsController : ControllerBase
    {
        readonly IMealRetrieverService _mealRetrieverService;

        public MealsController(IMealRetrieverService mealRetrieverService)
        {
            _mealRetrieverService = mealRetrieverService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMealByName(string name)
        {
            var foundMeal = await _mealRetrieverService.GetMeal(name);
            if (foundMeal == null)
                return NotFound($"Meal with name '{name}' was not found");

            var result = JsonConvert.SerializeObject(foundMeal);
            return Ok(result);
        }
    }
}
