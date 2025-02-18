using System;
using System.Collections.Generic;

namespace WebApplicationTest.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Name { get; set; }

    public int? Age { get; set; }
}
