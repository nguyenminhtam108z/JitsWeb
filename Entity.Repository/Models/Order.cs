using System;
using System.Collections.Generic;

namespace Entity.Repository.Models;

public partial class Order
{
    public string OrderId { get; set; } = null!;

    public DateTime? OrderDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public decimal? ShippingFee { get; set; }

    public Guid CustomerId { get; set; }

    public Guid EmployeeId { get; set; }

    public string? ShipAddress { get; set; }

    public string? Note { get; set; }

    public string? ShipperId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual Shipper? Shipper { get; set; }
}
