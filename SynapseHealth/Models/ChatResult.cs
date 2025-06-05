namespace SynapseHealth.Models
{
    public class ChatResult
    {
        public string? ResultText { get; init; }
        public int InputTokens { get; set; }
        public int OutputTokens { get; set; }
        public int TotalTokens { get; set; }

    }
}
