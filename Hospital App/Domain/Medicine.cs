using System;
using System.Collections.Generic;

namespace Hospital_App.Domain;

public partial class Medicine
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<OrderMedicine> OrderMedicines { get; set; } = new List<OrderMedicine>();
}
