using System;
using System.Collections.Generic;

namespace Entity.Repository.Models;

public partial class OrderDetail
{
    public string OrderId { get; set; } = null!;

    public Guid ProductId { get; set; }

    public decimal Price { get; set; }

    public int Quantity { get; set; }

    public float? Discount { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
