namespace Centric2024.Contracts.Responses
{
    public class MealResponse
    {
        public readonly string Name;
        public readonly string Category;
        public readonly string Area;
        public readonly List<string>? MealsWithSameCategory;
        public readonly List<string>? MealsWithSameArea;

        public MealResponse(string name, string category, string area,
            List<string>? mealsWithSameCategory, List<string>? mealsWithSameArea)
        {
            Name = name;
            Category = category;
            Area = area;
            MealsWithSameCategory = mealsWithSameCategory;
            MealsWithSameArea = mealsWithSameArea;
        }
    }
}
