namespace Airedale.Database.Model;

public partial class Service {
    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    public long? CategoryId { get; set; }

    public virtual Category? Category { get; set; }

    public static explicit operator Service(GraphQL.DataTypes.Service service) => new() {
        Id = service.Id,
        Name = service.Name,
        Description = service.Description,
        ImageUrl = service.ImageUrl,
        CategoryId = service.CategoryId
    };
}