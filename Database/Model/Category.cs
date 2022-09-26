namespace Airedale.Database.Model;

public partial class Category {
    public Category() {
        Services = new HashSet<Service>();
    }

    public long Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public virtual ICollection<Service> Services { get; set; }

    public static explicit operator Category(GraphQL.DataTypes.Category category) => new() {
        Id = category.Id,
        Name = category.Name,
        Description = category.Description,
        ImageUrl = category.ImageUrl
    };
}