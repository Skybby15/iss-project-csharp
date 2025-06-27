using System;
using System.Collections.Generic;

namespace Model_Persistence.Domain;

public partial class Medicine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<OrderMedicine> OrderMedicines { get; set; } = new List<OrderMedicine>();
}
