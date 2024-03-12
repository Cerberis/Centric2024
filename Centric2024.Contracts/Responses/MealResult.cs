namespace Centric2024.TheMealDb.Models
{
    public class MealResult
    {
        public readonly string Name;
        public readonly string Category;
        public readonly string Area;

        public MealResult(string name, string category, string area)
        {
            Name = name;
            Category = category;
            Area = area;
        }
    }
}
