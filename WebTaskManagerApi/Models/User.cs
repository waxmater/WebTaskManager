using System;
using System.Collections.Generic;

namespace WebTaskManagerApi.Models;

public partial class User
{
    public int IdUser { get; set; }

    public string Login { get; set; } = null!;

    public byte[] Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public ulong IsActive { get; set; }
}
