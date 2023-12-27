namespace ParkingSys.API.Model;

public class Stay : Entity
{
    public required Vehicle Vehicle { get; set; }
    public required DateTime ArrivedAt { get; set; }
    public DateTime? LeftAt { get; set; }
    public double? Cost { get; set; }
    public string? Comment { get; set; }
}
