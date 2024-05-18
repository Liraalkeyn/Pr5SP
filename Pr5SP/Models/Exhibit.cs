using System;
using System.Collections.Generic;

namespace Pr5SP.Models;

public partial class Exhibit
{
    public int ExhibitId { get; set; }

    public string NameOfExhibit { get; set; } = null!;

    public int TypeOfExhibit { get; set; }

    public int Country { get; set; }

    public virtual Country CountryNavigation { get; set; } = null!;

    public virtual TypeOfExhibit TypeOfExhibitNavigation { get; set; } = null!;
}
