using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreRack
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un code-barres et un rack.
    /// </summary>
    public int CodeBarreRackId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du rack avec ce code-barres est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? CodeBarreRackRackId { get; set; }

    public virtual Rack? CodeBarreRackRack { get; set; }
}
