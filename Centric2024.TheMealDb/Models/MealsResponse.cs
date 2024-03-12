using Newtonsoft.Json;

namespace Centric2024.TheMealDb.Models
{
    public sealed class MealsResponse
    {
        [JsonProperty("meals")]
        public List<Meal> Meals { get; set; }
    }
}
