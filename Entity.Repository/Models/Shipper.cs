using System;
using System.Collections.Generic;

namespace Entity.Repository.Models;

public partial class Shipper
{
    public string ShipperId { get; set; } = null!;

    public string? Name { get; set; }

    public string? Phone { get; set; }

    public string? Region { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
