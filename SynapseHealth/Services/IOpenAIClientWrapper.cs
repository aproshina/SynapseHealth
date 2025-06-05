using OpenAI.Chat;

namespace SynapseHealth.Services;

public interface IOpenAIClientWrapper
{
    IChatClientWrapper GetChatClient(string model);
}