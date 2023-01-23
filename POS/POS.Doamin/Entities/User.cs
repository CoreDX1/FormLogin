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
    // Remove la ejecucion query en el entities
    public byte Status { get; set; } = 1;
    // Remove la ejecucion query en el entities
    public DateTime DateRegister { get; set; } = DateTime.Now;
    // Remove la ejecucion query en el entities
    public int RolId { get; set; } = 2;
    public virtual Rol Rol { get; set; } = null!;
}
