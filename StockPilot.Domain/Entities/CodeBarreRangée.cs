using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreRangée
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un code-barres et une rangée.
    /// </summary>
    public int CodeBarreRangéeId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de la rangée avec ce code-barres est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? CodeBarreRangéeRangéeId { get; set; }

    public virtual Rangée? CodeBarreRangéeRangée { get; set; }
}
