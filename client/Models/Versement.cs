using System.ComponentModel.DataAnnotations;

namespace client.Models;

public class Versement
{
    public int Id { get; set; }
    public decimal Price { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    [DataType(DataType.Date)]
    public DateTime? UpdateDate { get; set; }

    public bool? IsChecked { get; set; }

    public ICollection<Event> Events { get; } = new List<Event>(); // Collection navigation containing dependents
}