using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Rangée
{
    /// <summary>
    /// Identifiant unique pour chaque rangée
    /// </summary>
    public int RangéeId { get; set; }

    /// <summary>
    /// Nom de la rangée
    /// </summary>
    public string? RangéeNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du rack dans lequel la rangée est située. C&apos;est une clé étrangère
    /// </summary>
    public int? RangéeRackId { get; set; }

    public virtual ICollection<CodeBarreRangée> CodeBarreRangées { get; set; } = new List<CodeBarreRangée>();

    public virtual ICollection<Etage> Etages { get; set; } = new List<Etage>();

    public virtual Rack? RangéeRack { get; set; }
}
