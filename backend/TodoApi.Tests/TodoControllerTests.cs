using Microsoft.EntityFrameworkCore;
using TodoApi.Controllers;
using TodoApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Tests
{
    public class TodoControllerTests
    {
        private DbContextOptions<ApiDbContext> _dbOptions;

        public TodoControllerTests()
        {
            _dbOptions = new DbContextOptionsBuilder<ApiDbContext>()
                .UseInMemoryDatabase(databaseName: System.Guid.NewGuid().ToString())
                .Options;
        }

        [Fact]
        public async Task GetTasks_ShouldReturn_AllTasks()
        {
            using (var context = new ApiDbContext(_dbOptions))
            {
                context.TodoItems.Add(new ToDoItem { Tytul = "Test 1", Opis = "Opis 1" });
                context.TodoItems.Add(new ToDoItem { Tytul = "Test 2", Opis = "Opis 2" });
                await context.SaveChangesAsync();
            }

            using (var context = new ApiDbContext(_dbOptions))
            {
                var controller = new TodoController(context);
                var actionResult = await controller.GetAllTasks();

                Assert.NotNull(actionResult);

                var okResult = Assert.IsType<OkObjectResult>(actionResult.Result);
                var taskList = Assert.IsAssignableFrom<IEnumerable<ToDoItem>>(okResult.Value);

                Assert.Equal(2, taskList.Count());
            }
        }

        [Fact]
        public async Task ChangeStatus_ShouldReturn_StatusTrue()
        {
            using (var context = new ApiDbContext(_dbOptions))
            {
                context.TodoItems.Add(new ToDoItem { Tytul = "Test 1", CzyZrobione = false});
                await context.SaveChangesAsync();
            }

            using (var context = new ApiDbContext(_dbOptions))
            {
                var controller = new TodoController(context);
                var actionResult = await controller.EditTaskStatus(1);
                Assert.NotNull(actionResult);
                var task = await context.TodoItems.FindAsync(1);

                Assert.True(task.CzyZrobione);
            }
        }
    }
}