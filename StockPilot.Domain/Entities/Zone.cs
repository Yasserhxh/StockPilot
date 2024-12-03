using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Zone
{
    /// <summary>
    /// Identifiant unique pour chaque zone.
    /// </summary>
    public int ZoneId { get; set; }

    /// <summary>
    /// Nom de la zone.
    /// </summary>
    public string? ZoneNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du site auquel appartient la zone. C&apos;est une clé étrangère.
    /// </summary>
    public int? ZoneSiteId { get; set; }

    public virtual ICollection<Allée> Allées { get; set; } = new List<Allée>();

    public virtual ICollection<CodeBarreZone> CodeBarreZones { get; set; } = new List<CodeBarreZone>();

    public virtual ICollection<OperationInventaire> OperationInventaires { get; set; } = new List<OperationInventaire>();

    public virtual Site? ZoneSite { get; set; }
}
