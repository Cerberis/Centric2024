using Centric2024.Contracts.Responses;

namespace Centric2024.Core
{
    public interface IMealRetrieverService
    {
        public Task<MealResponse>? GetMeal(string mealName);
    }
}