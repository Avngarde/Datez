using System;
using SQLite;
using Datez.Models;

namespace Datez.Db;

public class EventDatabase : IDatabase<Event>
{
    SQLiteAsyncConnection database;

    public async Task<int> Add(Event item)
    {
        Init();
        return await database.InsertAsync(item);
    }

    public async Task<int> Delete(Event item)
    {
        Init();
        return await database.DeleteAsync(item);
    }

    public async Task<int> Edit(Event item)
    {
        Init();
        return await database.UpdateAsync(item);
    }

    public async Task<Event> Get(int id)
    {
        Init();
        return await database.Table<Event>().Where(e => e.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Event>> GetAll()
    {
        Init();
        return await database.Table<Event>().ToListAsync();
    }

    public void Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags);        
    }
}
