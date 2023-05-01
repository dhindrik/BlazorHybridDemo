namespace CatchLoggerDemo.Web.Entities;

public record Catch
{
    public required string Id { get; set; }
    public required DateTime Created { get; set; }
    public required string Fish { get; set; }
    public double? Weight { get; set; }
    public double? Length { get; set; }
    public string? Note { get; set; }
    public List<string> Photos { get; set; } = new();
}

