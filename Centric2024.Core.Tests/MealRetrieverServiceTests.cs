using Centric2024.Core.Validators;

namespace Centric2024.Core.Tests
{
    public class MealRetrieverServiceTests
    {
        [Test]
        public async Task GetMeal_WhenMealIsNotFound_ReturnNull()
        {
            var mealDbServiceMock = ITheMealDbServiceStubs.MealNotFoundStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();
            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");
            result.ShouldBeNull();
        }

        [Test]
        public async Task GetMeal_MealsInSameCategoryAreReturned_TheyShouldBeInResponse()
        {
            var foundMeal = new MealBuilder().Build();
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.ShouldSatisfyAllConditions(
                () => result.MealsWithSameCategory.ShouldNotBeNull(),
                () => result.MealsWithSameCategory!.Count.ShouldBe(5),
                () => result.Name.ShouldNotBeNull(),
                () => result.Category.ShouldNotBeNull(),
                () => result.Area.ShouldNotBeNull()
                );
        }

        [Test]
        public async Task GetMeal_TooManyMealsInSameCategoryAreReturned_ShouldNotExceedLimit()
        {
            var foundMeal = new MealBuilder().Build();
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.MealsWithSameCategory!.Count.ShouldBe(5);
        }

        [Test]
        public async Task GetMeal_MealsInSameCategoryAreReturned_ShouldNotHaveSameMealAsInput()
        {
            var mealBuilder = new MealBuilder();
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");
            result!.MealsWithSameCategory!.FirstOrDefault(m => m == mealBuilder.Name).ShouldBeNull();
        }

        [Test]
        public async Task GetMeal_NoMealsInSameCategoryAreReturned_TheyShouldNotBeInResponse()
        {
            var mealDbServiceMock = ITheMealDbServiceStubs.CategoriesAndAreasNotFoundStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.ShouldSatisfyAllConditions(
               () => result.MealsWithSameCategory.ShouldBeNull(),
               () => result.Name.ShouldNotBeNull(),
               () => result.Category.ShouldNotBeNull(),
               () => result.Area.ShouldNotBeNull()
               );
        }

        [Test]
        public async Task GetMeal_MealsInSameAreaAreReturned_TheyShouldBeInResponse()
        {
            var foundMeal = new MealBuilder().Build();
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.ShouldSatisfyAllConditions(
                () => result.MealsWithSameArea.ShouldNotBeNull(),
                () => result.MealsWithSameArea!.Count.ShouldBe(3),
                () => result.Name.ShouldNotBeNull(),
                () => result.Category.ShouldNotBeNull(),
                () => result.Area.ShouldNotBeNull()
                );
        }

        [Test]
        public async Task GetMeal_TooManyMealsInSameAreaAreReturned_ShouldNotExceedLimit()
        {
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.MealsWithSameArea!.Count.ShouldBe(3);
        }

        [Test]
        public async Task GetMeal_MealsInSameAreaAreReturned_ShouldNotHaveSameMealAsInput()
        {
            var mealBuilder = new MealBuilder();
            var mealDbServiceMock = ITheMealDbServiceStubs.SuccessfullStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");
            result!.MealsWithSameArea!.FirstOrDefault(m => m == mealBuilder.Name).ShouldBeNull();
        }

        [Test]
        public async Task GetMeal_NoMealsInSameAreaAreReturned_TheyShouldNotBeInResponse()
        {
            var mealDbServiceMock = ITheMealDbServiceStubs.CategoriesAndAreasNotFoundStub();
            var mealRetrieverServiceValidatorMock = Substitute.For<IMealRetrieverServiceValidator>();

            IMealRetrieverService sut = new MealRetrieverService(mealDbServiceMock, mealRetrieverServiceValidatorMock);
            var result = await sut.GetMeal("");

            result.ShouldSatisfyAllConditions(
               () => result.MealsWithSameArea.ShouldBeNull(),
               () => result.Name.ShouldNotBeNull(),
               () => result.Category.ShouldNotBeNull(),
               () => result.Area.ShouldNotBeNull()
               );
        }
    }
}
