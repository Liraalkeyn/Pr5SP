using System;
using System.Collections.Generic;

namespace Pr5SP.Models;

public partial class TypeOfExhibit
{
    public int TypeOfExhibitId { get; set; }

    public string NameOfType { get; set; } = null!;

    public virtual ICollection<Exhibit> Exhibits { get; set; } = new List<Exhibit>();
}
