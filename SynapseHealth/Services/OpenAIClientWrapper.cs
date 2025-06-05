using OpenAI;
using Microsoft.Extensions.Options;

namespace SynapseHealth.Services;

public class OpenAIClientWrapper : IOpenAIClientWrapper
{
    private readonly OpenAIClient _client;
    public OpenAIClientWrapper(IOptions<OpenAISettings> settings)
    {
        if (string.IsNullOrWhiteSpace(settings.Value.ApiKey))
            throw new ArgumentException("OpenAI API key is missing in configuration.");

        _client = new OpenAIClient(settings.Value.ApiKey);
    }

    public IChatClientWrapper GetChatClient(string model) => 
        new ChatClientWrapper(_client.GetChatClient(model));
}