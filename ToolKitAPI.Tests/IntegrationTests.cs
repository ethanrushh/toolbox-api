using Microsoft.AspNetCore.Mvc.Testing;

namespace ToolKitAPI.Tests;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    [Fact]
    public async Task GetWhatsMyIp_Locally_IsSuccessful()
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = $"{client.BaseAddress}api/whats-my-ip";

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode();
    }
}
