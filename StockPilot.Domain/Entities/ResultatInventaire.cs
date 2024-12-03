using System;
using System.Collections.Generic;

namespace StockPilot.Domain.Entities;

public partial class ResultatInventaire
{
    /// <summary>
    /// Identifiant unique pour chaque enregistrement de résultat d&apos;inventaire.
    /// </summary>
    public int ResultatInventaireId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant du produit formulé, lié à la table FormProduit.
    /// </summary>
    public int? ResultatInventaireFormProduitId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;équipe responsable de l&apos;inventaire, liée à la table Equipe.
    /// </summary>
    public int? ResultatInventaireEquipeId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;inventaire, liée à la table Inventaire.
    /// </summary>
    public int? ResultatInventaireInventaireId { get; set; }

    /// <summary>
    /// Référence à l&apos;identifiant de l&apos;opérateur qui a participé à l&apos;inventaire, liée à la table Operateur.
    /// </summary>
    public int? ResultatInventaireOperateurId { get; set; }

    public virtual Equipe? ResultatInventaireEquipe { get; set; }

    public virtual FormProduit? ResultatInventaireFormProduit { get; set; }

    public virtual Inventaire? ResultatInventaireInventaire { get; set; }

    public virtual Operateur? ResultatInventaireOperateur { get; set; }
}
