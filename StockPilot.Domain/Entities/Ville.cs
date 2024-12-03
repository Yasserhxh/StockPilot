using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Ville
{
    /// <summary>
    /// Identifiant unique pour chaque ville
    /// </summary>
    public int VilleId { get; set; }

    /// <summary>
    /// Nom de la ville
    /// </summary>
    public string? VilleNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de la région à laquelle appartient la ville.
    /// </summary>
    public int? VilleRegionId { get; set; }

    public virtual ICollection<Site> Sites { get; set; } = new List<Site>();

    public virtual ICollection<Societé> Societés { get; set; } = new List<Societé>();

    public virtual Region? VilleRegion { get; set; }
}
