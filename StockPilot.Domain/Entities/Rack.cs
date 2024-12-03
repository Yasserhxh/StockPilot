using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Rack
{
    /// <summary>
    /// Identifiant unique pour chaque rack
    /// </summary>
    public int RackId { get; set; }

    /// <summary>
    /// Nom du rack
    /// </summary>
    public string? RackNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;allée dans laquelle le rack est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? RackAlléeId { get; set; }

    public virtual ICollection<CodeBarreRack> CodeBarreRacks { get; set; } = new List<CodeBarreRack>();

    public virtual Allée? RackAllée { get; set; }

    public virtual ICollection<Rangée> Rangées { get; set; } = new List<Rangée>();
}
