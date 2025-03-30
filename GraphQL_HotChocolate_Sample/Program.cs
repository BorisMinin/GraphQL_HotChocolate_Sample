using GraphQL_HotChocolate_Sample.Mutations;
using GraphQL_HotChocolate_Sample.Queries;
using GraphQL_HotChocolate_Sample.Repositories;
using GraphQL_HotChocolate_Sample.Subscriptions;

namespace GraphQL_HotChocolate_Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            builder.Services.AddGraphQLServer()
                .AddQueryType<Query>()
                .AddMutationType<Mutation>()
                .AddSubscriptionType<Subscription>()
                .AddInMemorySubscriptions();

            builder.Services.AddScoped<ProductRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
                app.MapOpenApi();

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/graphql");
                    return;
                }
                await next();
            });

            app.MapControllers();

            app.MapGraphQL("/graphql");

            app.Run();
        }
    }
}