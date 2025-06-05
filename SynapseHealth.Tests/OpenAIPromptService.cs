namespace SynapseHealth.Tests;

using NSubstitute;
using OpenAI.Chat;
using SynapseHealth.Models;
using SynapseHealth.Services;
using System.ClientModel;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

public class OpenAIPromptServiceTests
{
    [Fact]
    public async Task RunPromptWithInput_ReturnsExpectedResponse()
    {
        // Arrange
        var mockChatClient = Substitute.For<IChatClientWrapper>();

        mockChatClient.CompleteChatAsync(
         Arg.Any<List<ChatMessage>>(),
         Arg.Any<ChatCompletionOptions>(),
         Arg.Any<CancellationToken>())
            .Returns(Task.FromResult(new ChatResult
            {
                ResultText = "Test result",
                InputTokens = 5,
                OutputTokens = 10,
                TotalTokens = 15
            }));

        var mockClientWrapper = Substitute.For<IOpenAIClientWrapper>();
        mockClientWrapper.GetChatClient("gpt-4").Returns(mockChatClient);

        var service = new OpenAIPromptService(mockClientWrapper);

        var request = new Request
        {
            Prompt = "System prompt",
            InputText = "User input",
            Model = "gpt-4",
            Temperature = 0.5F,
            MaxTokens = 100
        };

        // Act
        var result = await service.RunPromptWithInput(request, CancellationToken.None);

        // Assert
        Assert.Equal("Test result", result.ResultText);
        Assert.Equal(5, result.InputTokens);
        Assert.Equal(10, result.OutputTokens);
        Assert.Equal(15, result.TotalTokens);


    }

}
