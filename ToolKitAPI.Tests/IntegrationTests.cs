using System.Net.Mime;
using System.Text;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using ToolKitAPI.Core.Commands.Notes;
using ToolKitAPI.Data.DTOs.Notes;

namespace ToolKitAPI.Tests;

public class IntegrationTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public IntegrationTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }
    
    #region Miscelaneous
    
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
    
    #endregion




    #region Notes

    [Theory]
    [InlineData("Hello, World!", "Ethan Rushbrook")]
    [InlineData("More Data...", "Joe Smith")]
    public async Task CreateNote_WithValidNote_ReturnsNoteWithValidId(string content, string creator)
    {
        // Arrange
        var client = _factory.CreateClient();
        var url = $"{client.BaseAddress}api/notes/create";

        var command = new CreateNoteCommand(creator, content); // Records are cool, loving the new feature

        // Act
        var response = await client.PostAsync(url, new StringContent(JsonConvert.SerializeObject(command), Encoding.Default, MediaTypeNames.Application.Json));

        response.EnsureSuccessStatusCode(); // I hate this being in the Act stage but it'll cause a harder to debug error in the Assert stage because of the deserialization
        
        var responseContent = await response.Content.ReadAsStringAsync();

        var responseDto = JsonConvert.DeserializeObject<NoteReadDto>(responseContent)!;

        // Assert
        
        // The content should be unchanged
        responseDto.Content.Should()
            .Be(content);

        // The creator should be unchanged
        responseDto.Creator.Should()
            .Be(creator);

        // The DTO should have a valid ID
        responseDto.Id.Should()
            .NotBeEmpty()
            .And
            .NotBe(Guid.Empty);
    }
    

    #endregion
    
}
