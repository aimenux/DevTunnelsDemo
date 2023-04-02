using System.Net;
using FluentAssertions;

namespace Tests;

public class UnitTest1
{
    [Theory]
    [InlineData("api/welcome")]
    public async Task Should_Get_Success_Response(string route)
    {
        // arrange
        var fixture = new WebApiTestFixture();
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync(route);
        var responseBody = await response.Content.ReadAsStringAsync();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        responseBody.Should().NotBeNullOrWhiteSpace();
    }
}