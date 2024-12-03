using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreEtage
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un code-barres et un étage.
    /// </summary>
    public int CodeBarreEtageId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;étage avec ce code-barres est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? CodeBarreEtageEtageId { get; set; }

    public virtual Etage? CodeBarreEtageEtage { get; set; }
}
