namespace CatchLoggerDemo.Web.Models;

public record CatchModel
{
    public required string Id { get; set; }
    public DateTime Created { get; set; }
    public required string Fish { get; set; }
    public double? Weight { get; set; }
    public double? Length { get; set; }
    public string? Note { get; set; }
    public List<PhotoModel> Photos { get; set; } = new();
}

