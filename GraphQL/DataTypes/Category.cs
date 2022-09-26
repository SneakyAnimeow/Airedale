namespace Airedale.GraphQL.DataTypes;

public class Category {
    public long Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public static explicit operator Category(Database.Model.Category category) => new() {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description,
        ImageUrl = category.ImageUrl
    };
}