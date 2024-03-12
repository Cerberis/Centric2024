using Centric2024.TheMealDb.Models;
using Newtonsoft.Json;

namespace Centric2024.TheMealDb
{
    public class TheMealDbService : ITheMealDbService
    {
        private const string ApiBaseUrl = "https://www.themealdb.com/api/json/v1/1/";
        private readonly IHttpClientWrapper _httpClientWrapper;

        public TheMealDbService(IHttpClientWrapper httpClientWrapper)
        {
            _httpClientWrapper = httpClientWrapper;
        }

        public async Task<Meal?> GetMealByName(string mealName)
        {
            string endpoint = $"search.php?s={mealName}";
            var foundMeals = await RequestMeals(endpoint);
            return foundMeals?.Meals.FirstOrDefault();
        }

        public async Task<List<Meal>?> GetMealsByCategory(string categoryId)
        {
            string endpoint = $"filter.php?c={categoryId}";
            var foundMeals = await RequestMeals(endpoint);
            return foundMeals?.Meals;
        }

        public async Task<List<Meal>?> GetMealsByArea(string areaId)
        {
            string endpoint = $"filter.php?a={areaId}";
            var foundMeals = await RequestMeals(endpoint);
            return foundMeals?.Meals;
        }

        public async Task<MealsResponse?> RequestMeals(string endpoint)
        {
            var response = await SendRequest(endpoint);
            if (string.IsNullOrWhiteSpace(response))
                return null;

            var deserializedMeal = JsonConvert.DeserializeObject<MealsResponse>(response);
            return deserializedMeal;
        }

        async Task<string> SendRequest(string endpoint)
        {
            string url = $"{ApiBaseUrl}{endpoint}";

            HttpResponseMessage response = await _httpClientWrapper.GetAsync(url);

            if (!response.IsSuccessStatusCode)
                throw new Exception("Service not reachable");

            string content = await response.Content.ReadAsStringAsync();
            return content;
        }
    }
}