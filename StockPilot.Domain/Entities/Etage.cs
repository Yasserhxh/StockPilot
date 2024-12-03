using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Etage
{
    /// <summary>
    /// Identifiant unique pour chaque étage
    /// </summary>
    public int EtageId { get; set; }

    /// <summary>
    /// Nom de l&apos;étage
    /// </summary>
    public string? EtageNom { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de la rangée dans laquelle l&apos;étage est situé. C&apos;est une clé étrangère.
    /// </summary>
    public int? EtageRangéeId { get; set; }

    public virtual ICollection<CodeBarreEtage> CodeBarreEtages { get; set; } = new List<CodeBarreEtage>();

    public virtual Rangée? EtageRangée { get; set; }

    public virtual ICollection<Produit> Produits { get; set; } = new List<Produit>();
}
