using GraphQL_HotChocolate_Sample.Models;

namespace GraphQL_HotChocolate_Sample.Queries;

public class Query
{
    #region Records
    readonly IReadOnlyList<Product> _products = new List<Product>
    {
        new Product(
            Name: "Laptop",
            Category: new Category(
                Name: "Electronics",
                Description: "Devices with electronic circuits.")),
        new Product(
            Name: "Smartphone",
            Category: new Category(
                Name: "Electronics",
                Description: "Devices with electronic circuits.")),
        new Product(
            Name: "Table",
            Category: new Category(
                Name: "Furniture",
                Description: "Items that furnish a space.")),
        new Product(
            Name: "Chair",
            Category: new Category(
                Name: "Furniture",
                Description: "Items that furnish a space.")),
        new Product(
            Name: "Notebook",
            Category: new Category(
                Name: "Stationery",
                Description: "Writing materials and accessories.")),
        new Product(
            Name: "Pen",
            Category: new Category(
                Name: "Stationery",
                Description: "Writing materials and accessories."))
    };
    #endregion

    [GraphQLDescription("Returns all products")]
    public IEnumerable<Product> GetProducts() => _products;

    [GraphQLDescription("Returns the specified Product")]
    public Product GetProduct([GraphQLDescription("Product Name")] string name) =>
        _products.First(x => x.Name == name);
}