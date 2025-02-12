using Alba; // Used for ASP.NET Core applications integration testing
using Todos.Api.Todos;

namespace Todos.Tests.Todos;
public class GettingTodos
{
    [Fact]
    public async Task GetAOKStatusCode()
    {
        var host = await AlbaHost.For<Program>(); // Initializes AlbaHost test server for Program class

        await host.Scenario(api => // Scenario typically involves setting up a request, sending it to the application, and then asserting the expected outcomes
        {
            api.Get.Url("/todos");
            api.StatusCodeShouldBeOk();
        });
    }

    [Fact]
    public async Task CanAddAnItemToTheTodoList()
    {
        var host = await AlbaHost.For<Program>();

        var itemToAdd = new TodoListCreateItem
        {
            Description = "Make Tacos " + Guid.NewGuid(),
        };

        // Add item to todo list
        await host.Scenario(api =>
        {
            api.Post.Json(itemToAdd).ToUrl("/todos");
            api.StatusCodeShouldBeOk();
        });

        // Retrieve todo list
        var getResponse = await host.Scenario(api =>
        {
            api.Get.Url("/todos");
        });

        var listOfTodos = getResponse.ReadAsJson<List<TodoListItem>>();
        Assert.NotNull(listOfTodos);

        var hasMyItem = listOfTodos.Any(item => item.Description == itemToAdd.Description);
        Assert.True(hasMyItem);
    }
}
