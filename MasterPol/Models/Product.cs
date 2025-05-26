using System;
using System.Collections.Generic;

namespace MasterPol.Models;

public partial class Product
{
    public int Id { get; set; }

    public int TypeId { get; set; }

    public string Name { get; set; } = null!;

    public int Article { get; set; }

    public decimal MinPrice { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();

    public virtual ProductType Type { get; set; } = null!;
}
