using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreZone
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un code-barres et une zone.
    /// </summary>
    public int CodeBarreZoneId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de la zone avec ce code-barres est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? CodeBarreZoneZoneId { get; set; }

    public virtual Zone? CodeBarreZoneZone { get; set; }
}
