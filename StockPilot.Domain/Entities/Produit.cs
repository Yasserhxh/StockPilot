using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class Produit
{
    /// <summary>
    /// Identifiant unique pour chaque produit.
    /// </summary>
    public int ProduitId { get; set; }

    /// <summary>
    /// Libellé ou nom du produit.
    /// </summary>
    public string? ProduitLibelle { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;étage où le produit est stocké. C&apos;est une clé étrangère.
    /// </summary>
    public int? ProduitEtageId { get; set; }

    /// <summary>
    /// Prix du produit.
    /// </summary>
    public decimal? ProduitPrix { get; set; }

    public virtual ICollection<FormProduit> FormProduits { get; set; } = new List<FormProduit>();

    public virtual Etage? ProduitEtage { get; set; }
}
