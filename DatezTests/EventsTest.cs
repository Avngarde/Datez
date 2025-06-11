using Moq;
using Datez.Db;
using Datez.Models;
using Datez;
using SQLite;
using System.Data.Common;

namespace DatezTests;

public class EventsTests
{
    [Fact]
    public async Task InitTest()
    {
        Assert.Equal(1, 1);
    }
}