using Centric2024.TheMealDb.Models;

namespace Centric2024.Tests.Common.Builders
{
    public static class MealsResponseBuilder
    {
        public static MealsResponse Build()
        {
            return new MealsResponse
            {
                Meals = new List<Meal>
                {
                    new() {
                        Area = "Test1",
                        Category = "Test1",
                        Name = "Test1",
                        Id = 1
                    },
                    new() {
                        Area = "Test2",
                        Category = "Test2",
                        Name = "Test2",
                        Id = 2
                    },
                    new() {
                        Area = "Test3",
                        Category = "Test3",
                        Name = "Test3",
                        Id = 3
                    },
                    new() {
                        Area = "Test4",
                        Category = "Test4",
                        Name = "Test4",
                        Id = 4
                    },
                    new() {
                        Area = "Test5",
                        Category = "Test5",
                        Name = "Test5",
                        Id = 5
                    },
                    new() {
                        Area = "Test6",
                        Category = "Test6",
                        Name = "Test6",
                        Id = 6
                    },
                    new() {
                        Area = "Test7",
                        Category = "Test7",
                        Name = "Test7",
                        Id = 7
                    }

                }
            };
        }

        public static MealsResponse BuildEmpty()
        {
            return new MealsResponse
            {
                Meals = new List<Meal>()
            };
        }
    }
}
