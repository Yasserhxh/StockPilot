using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class TypeInventaire
{
    /// <summary>
    /// Identifiant unique pour chaque type d&apos;inventaire.
    /// </summary>
    public int TypeInventaireId { get; set; }

    /// <summary>
    /// Libellé du type d&apos;inventaire (ex: &quot;Inventaire simple&quot;, &quot;Inventaire double avec arbitrage&quot;.).
    /// </summary>
    public string? TypeInventaireLibelle { get; set; }

    public virtual ICollection<Inventaire> Inventaires { get; set; } = new List<Inventaire>();
}
