using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreAllée
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un code-barres et une allée.
    /// </summary>
    public int CodeBarreAlléeId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;allée avec ce code-barres est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? CodeBarreAlléeAlléeId { get; set; }

    public virtual Allée? CodeBarreAlléeAllée { get; set; }
}
