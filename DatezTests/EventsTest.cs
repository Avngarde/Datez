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

    [Fact]
    public async Task AddTest_EditTest_GetTest_ReturnsEditedName()
    {
        await connection.CreateTableAsync<Event>();
        EventDatabase eventDatabase = new(connection);
        Event ev = new Event() { Id = 1, Name = "Test", CreateDate = DateTime.Now, Description = "Test" };
        var addResult = await eventDatabase.Add(ev);

        ev.Name = "TestEdited";
        var editResult = await eventDatabase.Edit(ev);

        var updatedEv = await eventDatabase.Get(1);

        Assert.Equal(1, addResult);
        Assert.Equal(1, editResult);
        Assert.Equal("TestEdited", updatedEv.Name);
    }

    [Fact]
    public async Task CalculateCurrentAndEventFinishDateDifference()
    {
        DateTime finish = DateTime.Parse("2025-01-04 12:23");
        DateTime currentDate = DateTime.Parse("2024-01-02 10:30");
        Event ev = new Event() { Id = 1, Name = "Test", EventDate = finish };

        TimeSpan diff = ev.EventDate - currentDate;
        Assert.Equal(368, diff.Days);
        Assert.Equal(1, diff.Hours);
        Assert.Equal(53, diff.Minutes);
    }
}