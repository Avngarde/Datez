using System;

namespace Datez.Models;

public class Note
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int EventId { get; set; }
}
