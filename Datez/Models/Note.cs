using System;
using SQLite;

namespace Datez.Models;

public class Note
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int EventId { get; set; }
}
