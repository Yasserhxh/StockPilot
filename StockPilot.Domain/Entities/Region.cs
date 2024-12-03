using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Region
{
    /// <summary>
    /// Identifiant unique pour chaque région. C&apos;est la clé primaire.
    /// </summary>
    public int RegionId { get; set; }

    /// <summary>
    /// Nom de la région.
    /// </summary>
    public string? RegionNom { get; set; }

    public virtual ICollection<Ville> Villes { get; set; } = new List<Ville>();
}
