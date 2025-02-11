using Marten;// Used for data storage and retrieval in PostgreSQL databases

namespace Todos.Api.Todos;

public static class Endpoints
{

    // An "Extension Method"
    // This will add a method to the Endpoint Route Builder called "MapTodos"
    public static IEndpointRouteBuilder MapTodos(this IEndpointRouteBuilder builder)
    {
        // GET /todos, retrieves all todo items
        builder.MapGet("/todos", async (IDocumentSession session) =>
        {
            var response = await session.Query<TodoListItem>().ToListAsync();
            return Results.Ok(response);
        });

        // POST /todos, creates a new todo item
        builder.MapPost("/todos", async (TodoListCreateItem request, IDocumentSession session) =>
        {
            var response = new TodoListItem
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                Completed = false,
                CreatedOn = DateTimeOffset.UtcNow
            };

            session.Store(response); // Store the new todo item in the database
            await session.SaveChangesAsync(); // Save changes to the database
            return Results.Ok(response);
        });
        return builder; // Return the modified builder for further configuration
    }
}

public record TodoListItem
{
    public Guid Id { get; set; }
    public string Description { get; set; } = string.Empty;

    public bool Completed { get; set; }

    public DateTimeOffset CreatedOn { get; set; }
    public DateTimeOffset? CompletedOn { get; set; }
}

public record TodoListCreateItem
{
    public string Description { get; set; } = string.Empty;
}