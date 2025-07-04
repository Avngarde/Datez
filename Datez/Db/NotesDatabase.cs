using System;
using Datez.Models;
using SQLite;

namespace Datez.Db;

public class NotesDatabase : IDatabase<Note>
{
    SQLiteAsyncConnection database;

    public async Task<int> Add(Note item)
    {
        await Init();
        return await database.InsertAsync(item);
    }

    public async Task<int> Delete(Note item)
    {
        await Init();
        return await database.DeleteAsync(item);
    }

    public async Task<int> Edit(Note item)
    {
        await Init();
        return await database.UpdateAsync(item);
    }

    public async Task<Note> Get(int id)
    {
        await Init();
        return await database.Table<Note>().Where(n => n.Id == id).FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Note>> GetAll()
    {
        await Init();
        return await database.Table<Note>().ToListAsync();
    }

    public async Task Init()
    {
        if (database is not null)
            return;

        database = new SQLiteAsyncConnection(DbConstants.DatabasePath, DbConstants.Flags); 
        await database.CreateTableAsync<Note>();  
    }
}
