using System;
using System.Collections.Generic;

namespace Model_Persistence.Domain;

public partial class Order
{
    public int Id { get; set; }

    public int? OrderTime { get; set; }

    public string? Details { get; set; }

    public string? Status { get; set; }

    public int? SolutionPharmacist { get; set; }

    public int? SolutionTime { get; set; }

    public virtual ICollection<OrderMedicine> OrderMedicines { get; set; } = new List<OrderMedicine>();
}
