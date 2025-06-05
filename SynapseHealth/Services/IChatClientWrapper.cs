using OpenAI.Chat;
using SynapseHealth.Models;

namespace SynapseHealth.Services;


public interface IChatClientWrapper
{
    Task<ChatResult> CompleteChatAsync(
        List<ChatMessage> messages,
        ChatCompletionOptions options,
        CancellationToken token);
}

