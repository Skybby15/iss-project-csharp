using System;
using System.Collections.Generic;

namespace Hospital_App.Domain;

public partial class User
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Password { get; set; }

    public byte[]? Salt { get; set; }

    public string? UserType { get; set; }
}
