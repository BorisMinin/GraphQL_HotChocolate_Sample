using GraphQL_HotChocolate_Sample.Models;

namespace GraphQL_HotChocolate_Sample.Queries;

public class CategoryQuery
{
    #region Records
    readonly IReadOnlyList<Product> _products = new List<Product>
{
    new Product
    {
        Id = 1,
        Name = "Laptop",
        CategoryId = 1,
        Category = new Category
        {
            Id = 1,
            Name = "Electronics",
            Description = "Devices with electronic circuits.",
            Products = new List<Product>()
        }
    },
    new Product
    {
        Id = 2,
        Name = "Smartphone",
        CategoryId = 1,
        Category = new Category
        {
            Id = 1,
            Name = "Electronics",
            Description = "Devices with electronic circuits.",
            Products = new List<Product>()
        }
    },
    new Product
    {
        Id = 3,
        Name = "Table",
        CategoryId = 2,
        Category = new Category
        {
            Id = 2,
            Name = "Furniture",
            Description = "Items that furnish a space.",
            Products = new List<Product>()
        }
    },
    new Product
    {
        Id = 4,
        Name = "Chair",
        CategoryId = 2,
        Category = new Category
        {
            Id = 2,
            Name = "Furniture",
            Description = "Items that furnish a space.",
            Products = new List<Product>()
        }
    },
    new Product
    {
        Id = 5,
        Name = "Notebook",
        CategoryId = 3,
        Category = new Category
        {
            Id = 3,
            Name = "Stationery",
            Description = "Writing materials and accessories.",
            Products = new List<Product>()
        }
    },
    new Product
    {
        Id = 6,
        Name = "Pen",
        CategoryId = 3,
        Category = new Category
        {
            Id = 3,
            Name = "Stationery",
            Description = "Writing materials and accessories.",
            Products = new List<Product>()
        }
    },
};
    #endregion

    [GraphQLDescription("Get all products")]
    public List<Product> GetProducts() => _products.ToList();

    [GraphQLDescription("Get specific product")]
    public Product? GetProduct(string name) =>
        _products.FirstOrDefault(x => x.Name == name);
}
