using GraphQL_HotChocolate_Sample.Models;
using GraphQL_HotChocolate_Sample.Repositories;

namespace GraphQL_HotChocolate_Sample.Queries;

public class Query
{
    private readonly ProductRepository _products;

    public Query(ProductRepository products) =>
        _products = products ?? throw new ArgumentNullException(nameof(products));

    [GraphQLDescription("Returns all products")]
    public IEnumerable<Product> GetProducts() => _products.GetProducts();

    [GraphQLDescription("Returns the specified Product")]
    public Product GetProduct([GraphQLDescription("Product Name")] string name) =>
        _products.GetProduct(name);
}