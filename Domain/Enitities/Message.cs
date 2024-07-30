namespace Domain.Enitities;

public class Message
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public string Sentiment { get; set; } = null!;
    public DateTime Timestamp { get; set; }
}