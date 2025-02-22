namespace GraphQL_HotChocolate_Sample.Models;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public List<Product>? Products { get; set; }
}