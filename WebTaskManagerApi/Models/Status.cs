using System;
using System.Collections.Generic;

namespace WebTaskManagerApi.Models;

public partial class Status
{
    public int IdStatus { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }
}
