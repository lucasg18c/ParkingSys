namespace ParkingSys.API.Model;

public abstract class Entity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public DateTime DateCreate { get; set; } = DateTime.Now;
}
