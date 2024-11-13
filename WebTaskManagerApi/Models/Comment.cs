using System;
using System.Collections.Generic;

namespace WebTaskManagerApi.Models;

public partial class Comment
{
    public int IdComments { get; set; }

    public string? Text { get; set; }

    public DateTime? Datetime { get; set; }

    public int TasksIdTask { get; set; }

    public int UsersIdUser { get; set; }

    public virtual Task TasksIdTaskNavigation { get; set; } = null!;

    public virtual User UsersIdUserNavigation { get; set; } = null!;
}
