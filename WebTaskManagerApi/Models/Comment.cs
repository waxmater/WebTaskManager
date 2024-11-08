using System;
using System.Collections.Generic;

namespace WebTaskManagerApi.Models;

public partial class Comment
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Comment1 { get; set; } = null!;
}
