using OpenAI.Chat;
using SynapseHealth.Models;

namespace SynapseHealth.Services;

public class ChatClientWrapper : IChatClientWrapper
{
    private readonly ChatClient _chatClient;

    public ChatClientWrapper(ChatClient chatClient)
    {
        _chatClient = chatClient;
    }

    public async Task<ChatResult>
        CompleteChatAsync(List<ChatMessage> messages, ChatCompletionOptions options, CancellationToken token)
    {
        ChatCompletion completion = await _chatClient.CompleteChatAsync(messages, options, token);

        string responseMessage = completion.Content?.FirstOrDefault()?.Text ?? "[No response]";

        return new ChatResult
        {
            ResultText = responseMessage,
            InputTokens = completion.Usage.InputTokenCount,
            OutputTokens = completion.Usage.OutputTokenCount,
            TotalTokens = completion.Usage.TotalTokenCount
        };

    }
}
