namespace Airedale.GraphQL.DataTypes;

public class Service {
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public long? CategoryId { get; set; }

    public static explicit operator Service(Database.Model.Service service) => new() {
        Id = service.Id,
        Name = service.Name,
        Description = service.Description,
        ImageUrl = service.ImageUrl,
        CategoryId = service.CategoryId
    };
}