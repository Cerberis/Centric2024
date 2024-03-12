using Centric2024.TheMealDb.Models;

namespace Centric2024.TheMealDb
{
    public interface ITheMealDbService
    {
        public Task<Meal?> GetMealByName(string mealName);
        public Task<List<Meal>?> GetMealsByCategory(string category);
        public Task<List<Meal>?> GetMealsByArea(string area);
        public Task<MealsResponse?> RequestMeals(string endpoint);
    }
}