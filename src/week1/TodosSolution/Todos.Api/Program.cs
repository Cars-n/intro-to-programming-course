using Marten; // Used for data storage and retrieval in PostgreSQL databases

using Todos.Api.Todos;

var builder = WebApplication.CreateBuilder(args); // Initializes a new instance of WebApplicationBuilder, which is used to configure the application, services, and middleware

builder.Services.AddAuthorization(); // Adds authorization services to the application

// Retrieves the connection string for the database from the configuration to use for connection
var connectionString = builder.Configuration.GetConnectionString("todos") ??
    throw new Exception("Can't start the api without a connection string");
builder.Services.AddMarten(builder =>
{
    builder.Connection(connectionString);
});

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); // Adds OpenAPI (Swagger) services to the application

// Above this line is configuration for the services inside our application
var app = builder.Build(); // Builds the application, preparing it to handle HTTP requests
// After this line is configuration for how HTTP requests and responses and handled

// Configure the HTTP request pipeline
// In development environments, maps the OpenAPI endpoints, for Swagger testing and documentation
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization(); // Adds authorization middleware to the request pipeline
app.MapTodos(); // Maps the routes for the "Todos" feature, allowing the application to handle requests related to todos

app.Run(); // Start application and begin listening for incoming HTTP requests, application is "Blocked" here