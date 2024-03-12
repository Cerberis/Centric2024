using Centric2024.TheMealDb;
using NSubstitute;
using System.Net;

namespace Centric2024.Tests.Common.Stubs
{
    public static class IHttpClientWrapperStubs
    {
        public static IHttpClientWrapper GetSuccessResponse(string responseContent)
        {
            var httpClientWrapperMock = Substitute.For<IHttpClientWrapper>();
            var responseMessage = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent(responseContent)
            };

            httpClientWrapperMock
                .GetAsync(Arg.Any<string>())
                    .Returns(Task.FromResult(responseMessage));
            return httpClientWrapperMock;
        }

        public static IHttpClientWrapper GetErrorResponse(HttpStatusCode httpStatusCode)
        {
            var httpClientWrapperMock = Substitute.For<IHttpClientWrapper>();
            var responseMessage = new HttpResponseMessage(httpStatusCode);

            httpClientWrapperMock
                .GetAsync(Arg.Any<string>())
                    .Returns(Task.FromResult(responseMessage));
            return httpClientWrapperMock;
        }
    }
}
