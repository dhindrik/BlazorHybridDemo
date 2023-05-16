using System;
using System.ComponentModel.DataAnnotations;

namespace CatchLoggerDemo.Core.Models;

public record AddFormModel
{
    [Required(ErrorMessage = "You have to enter type of fish")]
    public string? Fish { get; set; }
    public double? Weight { get; set; }
    public double? Length { get; set; }
    public string? Note { get; set; }
    public List<PhotoModel> Photos { get; } = new();
}

