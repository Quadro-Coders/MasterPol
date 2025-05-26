using System;
using System.Collections.Generic;

namespace MasterPol.Models;

public partial class Partner
{
    public int Id { get; set; }

    public string Type { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string DirectorName { get; set; } = null!;

    public string DirectorMail { get; set; } = null!;

    public string DirectorPhone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public long Inn { get; set; }

    public string? Avatar { get; set; }

    public short Rank { get; set; }

    public virtual ICollection<History> Histories { get; set; } = new List<History>();
}
