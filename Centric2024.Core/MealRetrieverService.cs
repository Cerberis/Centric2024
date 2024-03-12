using Centric2024.Contracts.Responses;
using Centric2024.Core.Validators;
using Centric2024.TheMealDb;
using Centric2024.TheMealDb.Models;

namespace Centric2024.Core
{
    public class MealRetrieverService : IMealRetrieverService
    {
        const int MealsInSameCategoryToReturn = 5;
        const int MealsInSameAreaToReturn = 3;

        readonly ITheMealDbService _theMealDbService;
        readonly IMealRetrieverServiceValidator _mealRetrieverServiceValidator;

        public MealRetrieverService(
            ITheMealDbService theMealDbService,
            IMealRetrieverServiceValidator mealRetrieverServiceValidator)
        {
            _theMealDbService = theMealDbService;
            _mealRetrieverServiceValidator = mealRetrieverServiceValidator;
        }

        public async Task<MealResponse>? GetMeal(string mealName)
        {
            _mealRetrieverServiceValidator.ValidateInput(ref mealName);
            Meal? foundMeal = await GetMealByName(mealName);

            if (foundMeal == null)
                return null;

            var mealsInSameCategory = await GetMealsByCategoryName(foundMeal.Category, foundMeal.Id);
            var mealsInSameArea = await GetMealsByAreaName(foundMeal.Area, foundMeal.Id);
            var result = new MealResponse(foundMeal.Name, foundMeal.Category, foundMeal.Area,
                 mealsInSameCategory, mealsInSameArea);
            return result;
        }

        async Task<Meal?> GetMealByName(string mealName)
        {
            return await _theMealDbService.GetMealByName(mealName);
        }

        async Task<List<string>?> GetMealsByCategoryName(string category, int id)
        {
            var mealsInSameCategory = await _theMealDbService.GetMealsByCategory(category);
            var filteredMeals = mealsInSameCategory?.Where(m => m.Id != id).Take(MealsInSameCategoryToReturn).Select(m => m.Name).ToList();
            return filteredMeals;
        }

        async Task<List<string>?> GetMealsByAreaName(string area, int id)
        {
            var mealsInSameArea = await _theMealDbService.GetMealsByArea(area);
            var filteredMeals = mealsInSameArea?.Where(m => m.Id != id).Take(MealsInSameAreaToReturn).Select(m => m.Name).ToList();
            return filteredMeals;
        }
    }
}
