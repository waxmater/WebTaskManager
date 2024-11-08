using System;
using System.Collections.Generic;

namespace WebTaskManagerApi.Models;

public partial class Task
{
    public int IdTask { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Priority { get; set; } = null!;

    public ulong Status { get; set; }

    public DateOnly? Deadline { get; set; }

    public DateOnly? CreationDate { get; set; }
}
