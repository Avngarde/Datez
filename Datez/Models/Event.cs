using System;
using SQLite;

namespace Datez.Models;

public class Event
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime CreateDate { get; set; }
}
