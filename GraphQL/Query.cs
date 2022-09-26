using Airedale.Database.Context;
using Airedale.GraphQL.DataTypes;

namespace Airedale.GraphQL;

public class Query {
    public IEnumerable<Category> GetCategories(int? id, string? name, string? description, string? imageUrl) {
        var context = new AiredaleDbContext();

        var query = context.Categories.AsQueryable();

        if (id != null) query = query.Where(x => x.Id == id);

        if (name != null) query = query.Where(x => x.Name == name);

        if (description != null) query = query.Where(x => x.Description == description);

        if (imageUrl != null) query = query.Where(x => x.ImageUrl == imageUrl);

        return query.Select(x => (Category)x);
    }

    public Category? GetCategory(int? id, string? name, string? description, string? imageUrl) =>
        GetCategories(id, name, description, imageUrl).FirstOrDefault();

    public IEnumerable<Service> GetServices(int? id, string? name, string? description, string? imageUrl) {
        var context = new AiredaleDbContext();

        var query = context.Services.AsQueryable();

        if (id != null) query = query.Where(x => x.Id == id);

        if (name != null) query = query.Where(x => x.Name == name);

        if (description != null) query = query.Where(x => x.Description == description);

        if (imageUrl != null) query = query.Where(x => x.ImageUrl == imageUrl);

        return query.Select(x => (Service)x);
    }

    public Service? GetService(int? id, string? name, string? description, string? imageUrl) =>
        GetServices(id, name, description, imageUrl).FirstOrDefault();
}