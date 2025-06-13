using Moq;
using Datez.Db;
using Datez.Models;
using Datez;
using SQLite;
using System.Data.Common;

namespace DatezTests;

public class EventsTests
{ 
    SQLiteAsyncConnection connection = new SQLiteAsyncConnection(":memory:", true);

    [Fact]
    public async Task AddTest_DeleteTest_BothReturnOne()
    {
        await connection.CreateTableAsync<Event>();
        EventDatabase eventDatabase = new(connection);
        Event ev = new Event() { Id = 1, Name = "Test", CreateDate = DateTime.Now, Description = "Test" };
        var addResult = await eventDatabase.Add(ev);
        var deleteResult = await eventDatabase.Delete(ev);

        Assert.Equal(1, addResult);
        Assert.Equal(1, deleteResult);
    }
}