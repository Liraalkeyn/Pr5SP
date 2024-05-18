using System;
using System.Collections.Generic;

namespace Pr5SP.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string NameOfCountry { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
