using Microsoft.AspNetCore.Mvc;
using SynapseHealth.Models;
using SynapseHealth.Services;

namespace SynapseHealth;

[ApiController]
[Route("/")]
public class PromptController : ControllerBase
{
    private readonly IAIPromptService _aiPromptService;

    public PromptController(IAIPromptService aiPromptService)
    {
        _aiPromptService = aiPromptService;
    }

    [HttpPost("promptWrangler")]
    public async Task<IActionResult> PromptWrangler([FromBody] Request request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await _aiPromptService.RunPromptWithInput(request, cancellationToken);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return Problem($"Something went wrong: {ex.Message}");
        }
    }
}