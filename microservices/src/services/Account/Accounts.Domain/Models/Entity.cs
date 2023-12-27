namespace Accounts.Domain.Models;

public class Entity
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public DateTime DateCreated { get; set; } = DateTime.UtcNow;

    public DateTime DateUpdated { get; set; } = DateTime.UtcNow;
}
