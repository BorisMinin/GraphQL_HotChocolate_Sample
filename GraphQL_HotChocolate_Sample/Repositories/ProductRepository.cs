using GraphQL_HotChocolate_Sample.Models;

namespace GraphQL_HotChocolate_Sample.Repositories;

public class ProductRepository
{
    private List<Product> _products = new List<Product>
    {
        new Product(
            Id: 1,
            Name: "Laptop",
            Category: new Category(
                Id: 1,
                Name: "Electronics",
                Description: "Devices with electronic circuits.")),
        new Product(
            Id: 2,
            Name: "Smartphone",
            Category: new Category(
                Id: 1,
                Name: "Electronics",
                Description: "Devices with electronic circuits.")),
        new Product(
            Id: 3,
            Name: "Table",
            Category: new Category(
                Id: 2,
                Name: "Furniture",
                Description: "Items that furnish a space.")),
        new Product(
            Id: 4,
            Name: "Chair",
            Category: new Category(
                Id: 2,
                Name: "Furniture",
                Description: "Items that furnish a space.")),
        new Product(
            Id: 5,
            Name: "Notebook",
            Category: new Category(
                Id: 3,
                Name: "Stationery",
                Description: "Writing materials and accessories.")),
        new Product(
            Id: 6,
            Name: "Pen",
            Category: new Category(
                Id: 3,
                Name: "Stationery",
                Description: "Writing materials and accessories."))
    };

    public IReadOnlyList<Product> GetProducts() => _products;

    public Product GetProduct(string name) =>
        _products.FirstOrDefault(x => x.Name == name);

    public void AddProduct(Product product) => _products.Add(product);

    public void RemoveProduct(int id)
    {
        var productToDelete = _products.FirstOrDefault(x => x.Id == id);

        if (productToDelete != null)
            _products.Remove(productToDelete);

        return;
    }

    public int NewProductId() => _products.Max(x => x.Id.Value) + 1;

    public int NewCategoryId() => _products.Max(x => x.Category.Id.Value) + 1;
}