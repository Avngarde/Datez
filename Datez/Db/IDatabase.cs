using System;
using SQLite;

namespace Datez.Db;

public interface IDatabase<T>
{
    Task Init();
    Task<IEnumerable<T>> GetAll();
    Task<T> Get(int id);
    Task<int> Add(T item);
    Task<int> Edit(T item);
    Task<int> Delete(T item);
}
