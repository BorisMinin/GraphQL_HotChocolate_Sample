using GraphQL_HotChocolate_Sample.Models;

namespace GraphQL_HotChocolate_Sample.Subscriptions;

public class Subscription
{
    [Subscribe]
    [Topic]
    public Product OnProductAdded([EventMessage] Product product) => product;
}