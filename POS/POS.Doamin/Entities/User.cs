using System;
using System.Collections.Generic;

namespace POS.Doamin.Entities;

public partial class User
{
    public int UserId { get; set; }
    public string Name { get; set; } = null!;
    public string Password { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public byte Status { get; set; }
    public DateTime? DateRegister { get; set; }
    public int RolId { get; set; }
    public virtual Rol Rol { get; set; } = null!;
}
