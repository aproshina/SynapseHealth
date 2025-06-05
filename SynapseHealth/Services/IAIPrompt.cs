using SynapseHealth.Models;

namespace SynapseHealth.Services;

public interface IAIPromptService
{
    public Task<Models.ChatResult> RunPromptWithInput(Request request, CancellationToken token);

}
