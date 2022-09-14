using Airedale.Database.Context;
using Airedale.GraphQL.DataTypes;

namespace Airedale.GraphQL; 

public class Mutation {
    [GraphQLDescription("Creates a new category")]
    public Category AddCategory(string name, string? description, string? imageUrl) {
        var context = new AiredaleDbContext();
        
        var entity = context.Categories.Add(new Database.Model.Category() {
            Name = name,
            Description = description,
            ImageUrl = imageUrl
        });

        context.SaveChanges();

        return (Category) entity.Entity;
    }
    
    [GraphQLDescription("Updates an existing category")]
    public Category UpdateCategory(int id, string name, string? description, string? imageUrl) {
        var context = new AiredaleDbContext();
        
        var entity = context.Categories.Update(new Database.Model.Category() {
            Id = id,
            Name = name,
            Description = description,
            ImageUrl = imageUrl
        });

        context.SaveChanges();

        return (Category) entity.Entity;
    }
    
    [GraphQLDescription("Deletes an existing category")]
    public bool DeleteCategory(int id) {
        var context = new AiredaleDbContext();
        
        var entity = context.Categories.Find(id);
        context.Categories.Remove(entity);

        context.SaveChanges();

        return true;
    }
    
    [GraphQLDescription("Creates a new service and adds it to a category")]
    public Service AddService(string name, string? description, string? imageUrl, int categoryId) {
        var context = new AiredaleDbContext();
        
        var entity = context.Services.Add(new Database.Model.Service() {
            Name = name,
            Description = description,
            ImageUrl = imageUrl,
            CategoryId = categoryId
        });

        context.SaveChanges();

        return (Service) entity.Entity;
    }
    
    [GraphQLDescription("Updates an existing service")]
    public Service UpdateService(int id, string name, string? description, string? imageUrl, int categoryId) {
        var context = new AiredaleDbContext();
        
        var entity = context.Services.Update(new Database.Model.Service() {
            Id = id,
            Name = name,
            Description = description,
            ImageUrl = imageUrl,
            CategoryId = categoryId
        });

        context.SaveChanges();

        return (Service) entity.Entity;
    }
    
    [GraphQLDescription("Deletes an existing service")]
    public bool DeleteService(int id) {
        var context = new AiredaleDbContext();
        
        var entity = context.Services.Find(id);
        context.Services.Remove(entity);

        context.SaveChanges();

        return true;
    }
}