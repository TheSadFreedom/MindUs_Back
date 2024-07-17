using System;
using System.Collections.Generic;

namespace WebApplication1.Models;

public partial class User
{
    public string UserLogin { get; set; } = null!;

    public string? UserPassword { get; set; }

    public string? UserEmail { get; set; }

    public bool? UserRole { get; set; }
}
