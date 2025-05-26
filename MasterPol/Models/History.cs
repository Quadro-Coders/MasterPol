using System;
using System.Collections.Generic;

namespace MasterPol.Models;

public partial class History
{
    public int Id { get; set; }

    public int PartnerId { get; set; }

    public int ProductId { get; set; }

    public decimal Count { get; set; }

    public DateTime Date { get; set; }

    public virtual Partner Partner { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
