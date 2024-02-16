using System.ComponentModel.DataAnnotations;

namespace client.Models;

public class Event
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public string? Details { get; set; }
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? UpdateDate { get; set; }
}