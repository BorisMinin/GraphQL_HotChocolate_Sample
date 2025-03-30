using GraphQL_HotChocolate_Sample.Models;
using GraphQL_HotChocolate_Sample.Repositories;
using HotChocolate.Subscriptions;

namespace GraphQL_HotChocolate_Sample.Mutations;

public class Mutation
{
    private readonly ProductRepository _products;
    private readonly ITopicEventSender _eventSender;

    public Mutation(ProductRepository products, ITopicEventSender eventSender)
    {
        _products = products ?? throw new ArgumentNullException(nameof(products));
        _eventSender = eventSender ?? throw new ArgumentNullException(nameof(eventSender));
    }

    [GraphQLDescription("Adds a new product to the list")]
    public async Task<Product> AddProduct(
        string name,
        string categoryName,
        string? categoryDescription)
    {
        var newProduct = new Product(
            Id: _products.NewProductId(),
            Name: name,
            Category: new Category(
                Id: _products.NewCategoryId(),
                Name: categoryName,
                Description: categoryDescription));

        _products.AddProduct(newProduct);

        // Публикация события
        await _eventSender.SendAsync("OnProductAdded", newProduct);

        return newProduct;
    }
}