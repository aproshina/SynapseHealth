using OpenAI;
using OpenAI.Chat;
using SynapseHealth.Models;
using System.Reflection;

namespace SynapseHealth.Services;

public class OpenAIPromptService : IAIPromptService
{
    private readonly IOpenAIClientWrapper _openAIClientWrapper;

    public OpenAIPromptService(IOpenAIClientWrapper openAIClientWrapper)
    {
        _openAIClientWrapper = openAIClientWrapper;
    }

    /// <summary>
    /// Executes a prompt using the OpenAI chat client and returns the result.
    /// </summary>
    /// <param name="request">Prompt parameters.</param>
    /// <param name="token">Cancellation token.</param>
    /// <returns>Structured result from the LLM.</returns>
    public async Task<ChatResult> RunPromptWithInput(Request request, CancellationToken token)
    {
        ArgumentNullException.ThrowIfNull(request);

        List<ChatMessage> messages =
        [
            new SystemChatMessage(request.Prompt),
            new UserChatMessage(request.InputText)
        ];

        var chatClient = _openAIClientWrapper.GetChatClient(request.Model);

        var chatOptions = new ChatCompletionOptions
        {
            Temperature = request.Temperature
        };

        //Model Max total tokens(input +output)
        //gpt - 3.5 - turbo   4,096
        //gpt - 4(8k)  8,192
        //gpt - 4(32k) 32,768
        chatOptions.MaxOutputTokenCount = request.MaxTokens > 0 && request.MaxTokens < 32768
            ? request.MaxTokens
            : 512;

        var result = await chatClient.CompleteChatAsync(messages, chatOptions, token);

        return result;
    }
}
