using System.ComponentModel.DataAnnotations;

namespace Jasleen.Models;

public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }

    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public decimal Price { get; set; }
    public decimal Rating { get; set; }

    public string Director { get; set; }

    public bool Hide { get; set; } = false;
}
