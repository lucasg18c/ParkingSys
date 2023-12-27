namespace ParkingSys.API.Model;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime DateCreate { get; set; } = DateTime.Now;
}
