using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class CodeBarreOperateur
{
    /// <summary>
    /// Identifiant unique pour chaque association entre un opérateur et un code-barres.
    /// </summary>
    public int CodeBarreOperateurId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;opérateur, lié à la table Operateur.
    /// </summary>
    public int? CodeBarreOperateurOperateurId { get; set; }

    public virtual Operateur? CodeBarreOperateurOperateur { get; set; }
}
