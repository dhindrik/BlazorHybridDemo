namespace CatchLoggerDemo.Web.Models;

public record PhotoModel
{
    public required string Id { get; set; }
    public required string Filename { get; set; }
    public required byte[] Bytes { get; set; }
}

