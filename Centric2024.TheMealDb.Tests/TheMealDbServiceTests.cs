using Centric2024.Tests.Common.Builders;
using Centric2024.Tests.Common.Stubs;
using Centric2024.TheMealDb.Models;

namespace Centric2024.TheMealDb.Tests
{
    public class TheMealDbServiceTests
    {

        [Test]
        public async Task RequestMeals_WhenResponseIsSuccessfull_ShouldReturnDeserializedContent()
        {
            var expectedResponse = MealsResponseBuilder.Build();
            var foundMeal = JsonConvert.SerializeObject(expectedResponse);
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMeal);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            MealsResponse? result = await sut.RequestMeals("test");

            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result!.Meals.Count.ShouldBe(7)
            );
        }

        [Test]
        public async Task RequestMeals_WhenResponseIsSuccessfullAndNoMealsFound_ShouldReturnEmptyObject()
        {
            var expectedResponse = MealsResponseBuilder.BuildEmpty();
            var foundMeal = JsonConvert.SerializeObject(expectedResponse);
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMeal);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            MealsResponse? result = await sut.RequestMeals("test");

            result.ShouldSatisfyAllConditions(
                () => result.ShouldNotBeNull(),
                () => result!.Meals.ShouldBeEmpty()
            );
        }

        [Test]
        public async Task RequestMeals_WhenResponseIsNotSuccessfull_ShouldThrowException()
        {
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetErrorResponse(HttpStatusCode.InternalServerError);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            Should.Throw<Exception>(async () => await sut.RequestMeals("test")).Message.ShouldBe("Service not reachable");
        }

        [TestCase("")]
        [TestCase(null)]
        public async Task RequestMeals_WhenResponseEmpty_ShouldReturnNull(string requestResponse)
        {
            var foundMeal = JsonConvert.SerializeObject(requestResponse);
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMeal);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            var result = await sut.RequestMeals("test");

            result.ShouldBeNull();
        }

        [Test]
        public async Task GetMealByName_WhenMealsFound_ShouldReturnMeal()
        {
            var foundMeals = MealsResponseBuilder.Build();
            var foundMealsJson = JsonConvert.SerializeObject(foundMeals);
            var expectedResponse = foundMeals.Meals.First();
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMealsJson);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            var result = await sut.GetMealByName("test");

            result.ShouldSatisfyAllConditions(
                () => result!.Name.ShouldBe(expectedResponse.Name),
                () => result!.Area.ShouldBe(expectedResponse.Area),
                () => result!.Category.ShouldBe(expectedResponse.Category),
                () => result!.Id.ShouldBe(expectedResponse.Id)
            );
        }

        [Test]
        public async Task GetMealByName_WhenNoMealsFound_ShouldReturnNull()
        {
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(string.Empty);
            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            var result = await sut.GetMealByName("test");

            result.ShouldBeNull();
        }

        [Test]
        public async Task GetMealsByArea_WhenMealsFound_ShouldReturnMeal()
        {
            var foundMeals = MealsResponseBuilder.Build();
            var foundMealsJson = JsonConvert.SerializeObject(foundMeals);
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMealsJson);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            var result = await sut.GetMealsByArea("test");

            result.Count.ShouldBe(7);
        }

        [Test]
        public async Task GetMealsByArea_WhenNoMealsFound_ShouldReturnNull()
        {
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(string.Empty);
            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);
            var result = await sut.GetMealsByArea("test");

            result.ShouldBeNull();
        }

        [Test]
        public async Task GetMealsByCategory_WhenMealsFound_ShouldReturnMeal()
        {
            var foundMeals = MealsResponseBuilder.Build();
            var foundMealsJson = JsonConvert.SerializeObject(foundMeals);
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(foundMealsJson);

            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);

            var result = await sut.GetMealsByCategory("test");

            result.Count.ShouldBe(7);
        }

        [Test]
        public async Task GetMealsByCategory_WhenNoMealsFound_ShouldReturnNull()
        {
            var httpClientWrapperMock = IHttpClientWrapperStubs.GetSuccessResponse(string.Empty);
            ITheMealDbService sut = new TheMealDbService(httpClientWrapperMock);
            var result = await sut.GetMealsByCategory("test");

            result.ShouldBeNull();
        }
    }
}