namespace GoalPtApp.Models.DTO
{
    public class CompletionParams
    {
        public int Quantity { get; set; }
        public string Model { get; set; } = "text-davinci-003";
        public string? UserPrompt { get; set; }
        public float Randomness { get; set; }
    }
}
