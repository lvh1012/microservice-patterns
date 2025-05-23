﻿namespace EventSourcing.Infrastructure.Models;
public class Event
{
    public Guid Id { get; set; }
    public string Type { get; set; } = default!;
    public string Data { get; set; } = default!;
    public string Metadata { get; set; } = string.Empty;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
    public Guid StreamId { get; set; }
    public EventStream Stream { get; set; } = default!;
    public long Version { get; set; }

}
