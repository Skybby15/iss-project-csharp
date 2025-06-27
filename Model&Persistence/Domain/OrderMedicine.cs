using System;
using System.Collections.Generic;

namespace Model_Persistence.Domain;

public partial class OrderMedicine
{
    public int Id { get; set; }

    public int? OrderId { get; set; }

    public int? MedicineId { get; set; }

    public int? Quantity { get; set; }

    public virtual Medicine? Medicine { get; set; }

    public virtual Order? Order { get; set; }
}
