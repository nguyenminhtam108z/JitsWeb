using System;
using System.Collections.Generic;

namespace Entity.Repository.Models;

public partial class Supplier
{
    public Guid SupplierId { get; set; }

    public string? CompanyName { get; set; }

    public string? Address { get; set; }

    public string? City { get; set; }

    public string? Country { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
