using Centric2024.Tests.Common.Builders;
using Centric2024.TheMealDb;
using Centric2024.TheMealDb.Models;
using NSubstitute;

namespace Centric2024.Tests.Common.Stubs
{
    public static class ITheMealDbServiceStubs
    {
        public static ITheMealDbService MealNotFoundStub()
        {
            Meal? meal = null;
            var mealDbServiceStub = Substitute.For<ITheMealDbService>();
            mealDbServiceStub.GetMealByName(Arg.Any<string>()).Returns(meal);
            return mealDbServiceStub;
        }

        public static ITheMealDbService SuccessfullStub()
        {
            var result = new List<Meal>() {
               new() {
               Id = 1,
               Name = "Test1",
               Area = "Test1",
               Category = "Test1"
           },
            new() {
               Id = 2,
               Name = "Test2",
               Area = "Test2",
               Category = "Test2"
           },
             new() {
               Id = 3,
               Name = "Test3",
               Area = "Test3",
               Category = "Test3"
           },
              new() {
               Id = 4,
               Name = "Test4",
               Area = "Test4",
               Category = "Test4"
           },
               new() {
               Id = 5,
               Name = "Test5",
               Area = "Test5",
               Category = "Test5"
           },
                new() {
               Id = 6,
               Name = "Test6",
               Area = "Test6",
               Category = "Test6"
           },
                 new() {
               Id = 7,
               Name = "Test7",
               Area = "Test7",
               Category = "Test7"
           }
           };
            var mealDbServiceStub = Substitute.For<ITheMealDbService>();
            mealDbServiceStub.GetMealByName(Arg.Any<string>()).Returns(new MealBuilder().Build());
            mealDbServiceStub.GetMealsByCategory(Arg.Any<string>()).Returns(result);
            mealDbServiceStub.GetMealsByArea(Arg.Any<string>()).Returns(result);
            return mealDbServiceStub;
        }

        public static ITheMealDbService CategoriesAndAreasNotFoundStub()
        {
            List<Meal>? result = null;
            var mealDbServiceStub = Substitute.For<ITheMealDbService>();
            mealDbServiceStub.GetMealByName(Arg.Any<string>()).Returns(new MealBuilder().Build());
            mealDbServiceStub.GetMealsByCategory(Arg.Any<string>()).Returns(result);
            mealDbServiceStub.GetMealsByArea(Arg.Any<string>()).Returns(result);
            return mealDbServiceStub;
        }
    }
}
