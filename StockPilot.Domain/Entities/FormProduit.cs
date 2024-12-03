using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class FormProduit
{
    /// <summary>
    /// Identifiant unique pour chaque forme de produit
    /// </summary>
    public int FormProduitId { get; set; }

    /// <summary>
    /// Code-barres unique pour identifier cette forme spécifique du produit.
    /// </summary>
    public string? FormProduitCodeBarre { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du produit parent. C&apos;est une clé étrangère.
    /// </summary>
    public int? FormProduitProduitId { get; set; }

    /// <summary>
    /// Quantité disponible de cette forme du produit.
    /// </summary>
    public int? FormProduitQuantite { get; set; }

    public virtual Produit? FormProduitProduit { get; set; }

    public virtual ICollection<ResultatInventaire> ResultatInventaires { get; set; } = new List<ResultatInventaire>();
}
