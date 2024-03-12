using Centric2024.TheMealDb.Models;

namespace Centric2024.Tests.Common.Builders
{
    public class MealBuilder
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Test1";
        public string Area { get; set; } = "Test2";
        public string Category { get; set; } = "Test3";

        public Meal Build()
        {
            return new Meal
            {
                Id = Id,
                Area = Area,
                Category = Category,
                Name = Name
            };
        }
    }
}
