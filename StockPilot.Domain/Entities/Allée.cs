using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Allée
{
    /// <summary>
    /// Identifiant unique pour chaque allée.
    /// </summary>
    public int AlléeId { get; set; }

    /// <summary>
    /// Nom de l&apos;allée
    /// </summary>
    public string? AlléeNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de la zone à laquelle l&apos;allée appartient. C&apos;est une clé étrangère.
    /// </summary>
    public int? AlléeZoneId { get; set; }

    public virtual Zone? AlléeZone { get; set; }

    public virtual ICollection<CodeBarreAllée> CodeBarreAllées { get; set; } = new List<CodeBarreAllée>();

    public virtual ICollection<Rack> Racks { get; set; } = new List<Rack>();
}
