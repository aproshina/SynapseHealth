namespace SynapseHealth.Models
{
    public class Request
    {
        public string Prompt { get; init; } = string.Empty;
        public string InputText { get; init; } = string.Empty;
        public string Model { get; init; } = "gpt-4";
        public float Temperature { get; init; }
        public int? MaxTokens { get; init; }
    }
}
